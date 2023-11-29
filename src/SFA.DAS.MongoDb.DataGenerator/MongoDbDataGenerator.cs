using SFA.DAS.FrameworkHelpers;
using SFA.DAS.MongoDb.DataGenerator.Helpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SFA.DAS.MongoDb.DataGenerator
{
    public class MongoDbDataGenerator
    {
        public string EmpRef { get; set; }

        private readonly ScenarioContext _context;

        private readonly ObjectContext _objectContext;

        private readonly MongoDbConnectionHelper _mongodbConnectionHelper;

        private readonly MongoDbDataHelper _mongoDbDataHelper;

        private readonly string _gatewayId;

        private readonly string _mongoDbDatabase;

        private MongoDbHelper _addGatewayUserData;

        private MongoDbHelper _addempRefLinksData;

        public MongoDbDataGenerator(ScenarioContext context, string empref)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            var mongoDbConfig = _context.GetMongoDbConfig();
            var dataHelper = _objectContext.GetDataHelper();
            _mongodbConnectionHelper = new MongoDbConnectionHelper(mongoDbConfig);
            _mongoDbDataHelper = new MongoDbDataHelper(dataHelper, empref);
            _gatewayId = _mongoDbDataHelper.GatewayId;
            EmpRef = _mongoDbDataHelper.EmpRef;
            _mongoDbDatabase = mongoDbConfig.Database;
        }

        public GatewayCreds AddGatewayUsers(int index)
        {
            _objectContext.SetMongoDbDataHelper(_mongoDbDataHelper, EmpRef);

            _objectContext.SetGatewayCreds(_mongoDbDataHelper.GatewayId, _mongoDbDataHelper.GatewayPassword, _mongoDbDataHelper.EmpRef, index);

            _addGatewayUserData = new MongoDbHelper(_mongodbConnectionHelper, new GatewayUserDataGenerator(_mongoDbDataHelper));

            SetDebugInformation($"Connecting to MongoDb Database : {_mongoDbDatabase}");

            _addGatewayUserData.AsyncCreateData().Wait();
            SetDebugInformation($"Gateway Id Created : {_gatewayId}");
            SetDebugInformation($"Gateway User Created, EmpRef: {EmpRef}");

            _addempRefLinksData = new MongoDbHelper(_mongodbConnectionHelper, new EmpRefLinksDataGenerator(_mongoDbDataHelper));
            _addempRefLinksData.AsyncCreateData().Wait();
            SetDebugInformation($"EmpRef Links Created, EmpRef: {EmpRef}");

            _context.Set(_addGatewayUserData, $"{typeof(GatewayUserDataGenerator).FullName}_{EmpRef}");
            _context.Set(_addempRefLinksData, $"{typeof(EmpRefLinksDataGenerator).FullName}_{EmpRef}");

            return _objectContext.GetGatewayCreds(index);
        }

        public void AddLevyDeclarations(decimal fraction, DateTime calculatedAt, Table table)
        {
            var set = table.CreateDynamicSet().ToList();

            var mongoDbHelper = new MongoDbHelper(_mongodbConnectionHelper, new DeclarationsDataGenerator(_mongoDbDataHelper, set));

            mongoDbHelper.AsyncCreateData().Wait();

            SetDebugInformation($"Declarations Created for, EmpRef: {EmpRef}");

            _context.Set(mongoDbHelper, $"{typeof(DeclarationsDataGenerator).FullName}_{EmpRef}");

            EnglishFraction(fraction, calculatedAt);
        }

        private void EnglishFraction(decimal fraction, DateTime calculatedAt)
        {
            var mongoDbHelper = new MongoDbHelper(_mongodbConnectionHelper, new EnglishFractionDataGenerator(_mongoDbDataHelper, fraction, calculatedAt));

            mongoDbHelper.AsyncCreateData().Wait();

            SetDebugInformation($"English fraction Created for, EmpRef: {EmpRef}");

            _context.Set(mongoDbHelper, $"{typeof(EnglishFractionDataGenerator).FullName}_{EmpRef}");
        }

        private void SetDebugInformation(string x) => _objectContext.SetDebugInformation(x);
    }
}
