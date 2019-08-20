using NUnit.Framework;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    public class MongoDbDataGenerator
    {
        private readonly ScenarioContext _context;

        private readonly MongoDbConnectionHelper _mongodbConnectionHelper;

        private readonly MongoDbDataHelper _mongoDbDataHelper;

        private readonly ObjectContext _objectContext;

        private readonly DataHelper _dataHelper;

        private string _empRef;

        private readonly MongoDbConfig _mongoDbConfig;

        private MongoDbHelper _addGatewayUserData;

        private MongoDbHelper _addempRefLinksData;

        public MongoDbDataGenerator(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _mongoDbConfig = _context.GetMongoDbConfig();
            _dataHelper = _context.Get<DataHelper>();
            _mongodbConnectionHelper = new MongoDbConnectionHelper(_mongoDbConfig);
            _mongoDbDataHelper = new MongoDbDataHelper(_dataHelper);
        }

        public void AddGatewayUsers()
        {
            _objectContext.SetGatewayCreds(_mongoDbDataHelper.GatewayId, _mongoDbDataHelper.GatewayPassword, _mongoDbDataHelper.EmpRef);

            _empRef = _objectContext.GetGatewayPaye();

            _addGatewayUserData = new MongoDbHelper(_mongodbConnectionHelper, new GatewayUserDataGenerator(_mongoDbDataHelper));

            TestContext.Progress.WriteLine($"Connecting to MongoDb Database : {_mongoDbConfig.Database}");

            _addGatewayUserData.AsyncCreateData().Wait();
            TestContext.Progress.WriteLine($"Gateway Id Created : {_objectContext.GetGatewayId()}");
            TestContext.Progress.WriteLine($"Gateway User Created, EmpRef: {_empRef}");

            _addempRefLinksData = new MongoDbHelper(_mongodbConnectionHelper, new EmpRefLinksDataGenerator(_mongoDbDataHelper));
            _addempRefLinksData.AsyncCreateData().Wait();
            TestContext.Progress.WriteLine($"EmpRef Links Created, EmpRef: {_empRef}");

            _context.Set(_addGatewayUserData, typeof(GatewayUserDataGenerator).FullName);
            _context.Set(_addempRefLinksData, typeof(EmpRefLinksDataGenerator).FullName);

        }

        public void AddLevyDeclarations(int noOfMonths)
        {

        }

        public void AddLevyDeclarations(decimal fraction, DateTime calculatedAt, Table table)
        {
            var set = table.CreateDynamicSet().ToList();

            var mongoDbHelper = new MongoDbHelper(_mongodbConnectionHelper, new DeclarationsDataGenerator(_mongoDbDataHelper, set));

            mongoDbHelper.AsyncCreateData().Wait();

            TestContext.Progress.WriteLine($"Declarations Created for, EmpRef: {_objectContext.GetGatewayPaye()}");

            _context.Set(mongoDbHelper, typeof(DeclarationsDataGenerator).FullName);

            EnglishFraction(fraction, calculatedAt);
        }

        private void EnglishFraction(decimal fraction, DateTime calculatedAt)
        {
            var mongoDbHelper = new MongoDbHelper(_mongodbConnectionHelper, new EnglishFractionDataGenerator(_mongoDbDataHelper, fraction, calculatedAt));

            mongoDbHelper.AsyncCreateData().Wait();

            TestContext.Progress.WriteLine($"English fraction Created for, EmpRef: {_objectContext.GetGatewayPaye()}");

            _context.Set(mongoDbHelper, typeof(EnglishFractionDataGenerator).FullName);
        }

    }
}
