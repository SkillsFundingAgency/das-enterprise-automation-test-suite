using NUnit.Framework;
using SFA.DAS.MongoDb.DataGenerator.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.ConfigurationBuilder;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SFA.DAS.MongoDb.DataGenerator
{
    public class MongoDbDataGenerator
    {
        private readonly ScenarioContext _context;

        private readonly ObjectContext _objectContext;

        private readonly MongoDbConnectionHelper _mongodbConnectionHelper;

        private readonly MongoDbDataHelper _mongoDbDataHelper;

        private readonly string _gatewayId;

        private readonly string _empRef;

        private readonly string _mongoDbDatabase;

        private MongoDbHelper _addGatewayUserData;

        private MongoDbHelper _addempRefLinksData;

        public MongoDbDataGenerator(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            var mongoDbConfig = _context.GetMongoDbConfig();
            var dataHelper = _objectContext.GetDataHelper();
            _mongodbConnectionHelper = new MongoDbConnectionHelper(mongoDbConfig);
            _mongoDbDataHelper = new MongoDbDataHelper(dataHelper);
            _gatewayId = _mongoDbDataHelper.GatewayId;
            _empRef = _mongoDbDataHelper.EmpRef;
            _mongoDbDatabase = mongoDbConfig.Database;
        }

        public void AddGatewayUsers()
        {
            _objectContext.SetMongoDbDataHelper(_mongoDbDataHelper, _empRef);

            _objectContext.SetGatewayCreds(_mongoDbDataHelper.GatewayId, _mongoDbDataHelper.GatewayPassword, _mongoDbDataHelper.EmpRef);

            _addGatewayUserData = new MongoDbHelper(_mongodbConnectionHelper, new GatewayUserDataGenerator(_mongoDbDataHelper));

            TestContext.Progress.WriteLine($"Connecting to MongoDb Database : {_mongoDbDatabase}");

            _addGatewayUserData.AsyncCreateData().Wait();
            TestContext.Progress.WriteLine($"Gateway Id Created : {_gatewayId}");
            TestContext.Progress.WriteLine($"Gateway User Created, EmpRef: {_empRef}");

            _addempRefLinksData = new MongoDbHelper(_mongodbConnectionHelper, new EmpRefLinksDataGenerator(_mongoDbDataHelper));
            _addempRefLinksData.AsyncCreateData().Wait();
            TestContext.Progress.WriteLine($"EmpRef Links Created, EmpRef: {_empRef}");

            _context.Set(_addGatewayUserData, $"{typeof(GatewayUserDataGenerator).FullName}_{_empRef}");
            _context.Set(_addempRefLinksData, $"{typeof(EmpRefLinksDataGenerator).FullName}_{_empRef}");
        }

        public void AddLevyDeclarations(decimal fraction, DateTime calculatedAt, Table table)
        {
            var set = table.CreateDynamicSet().ToList();

            var mongoDbHelper = new MongoDbHelper(_mongodbConnectionHelper, new DeclarationsDataGenerator(_mongoDbDataHelper, set));

            mongoDbHelper.AsyncCreateData().Wait();

            TestContext.Progress.WriteLine($"Declarations Created for, EmpRef: {_empRef}");

            _context.Set(mongoDbHelper, $"{typeof(DeclarationsDataGenerator).FullName}_{_empRef}");

            EnglishFraction(fraction, calculatedAt);
        }

        private void EnglishFraction(decimal fraction, DateTime calculatedAt)
        {
            var mongoDbHelper = new MongoDbHelper(_mongodbConnectionHelper, new EnglishFractionDataGenerator(_mongoDbDataHelper, fraction, calculatedAt));

            mongoDbHelper.AsyncCreateData().Wait();

            TestContext.Progress.WriteLine($"English fraction Created for, EmpRef: {_empRef}");

            _context.Set(mongoDbHelper, $"{typeof(EnglishFractionDataGenerator).FullName}_{_empRef}");
        }
    }
}
