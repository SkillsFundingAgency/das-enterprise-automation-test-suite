using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.PocProject.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework
{
    [Binding]
    public class MongoDbSetupHooks
    {
        private readonly ScenarioContext _context;
        private readonly FrameworkConfig _config;
        private readonly IWebDriver _webDriver;
        private MongoDbHelper _mongoDbHelper;
        private readonly MongoDbConfig _mongoDbConfig;
        private readonly PayeAccountDetails _payeAccountDetails;
        private readonly ObjectContext _objectContext;
        private DataHelper _dataHelper;

        public MongoDbSetupHooks(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.Get<FrameworkConfig>();
            _mongoDbConfig = _context.GetConfigSection<MongoDbConfig>();
            _objectContext = context.Get<ObjectContext>();
            _payeAccountDetails = _context.GetConfigSection<PayeAccountDetails>();

        }

        [BeforeScenario(Order = 21)]
        public void Navigate()
        {
            var url = _config.BaseUrl;
            _webDriver.Navigate().GoToUrl(url);
        }

        [BeforeScenario(Order = 22)]
        public void SetUpDataHelpers()
        {
            _dataHelper = new DataHelper(_payeAccountDetails.TwoDigitProjectCode);
            _context.Set(_dataHelper);
        }

        [BeforeScenario(Order = 23)]
        [Scope(Tag = "addpayedetails")]
        public void SetUpMongoDbHelpers()
        {
            var mongoDbDataHelper = new MongoDbDataHelper(_dataHelper);
            TestContext.Progress.WriteLine($"Gateway Id : {mongoDbDataHelper.GatewayId}");
            _objectContext.SetGatewayCreds(mongoDbDataHelper.GatewayId, mongoDbDataHelper.GatewayPassword, mongoDbDataHelper.EmpRef);
            _mongoDbHelper = new MongoDbHelper(_mongoDbConfig, mongoDbDataHelper);
        }

        [BeforeScenario(Order = 24)]
        [Scope(Tag = "addpayedetails")]
        public void AddPayeDetails()
        {
            _mongoDbHelper.AsyncCreateData().Wait();
            TestContext.Progress.WriteLine($"Gateway User Created, EmpRef: {_objectContext.GetGatewayPaye()}");
        }

        [AfterScenario(Order = 21)]
        [Scope(Tag = "addpayedetails")]
        public void DeletePayeDetails()
        {
            var results = _mongoDbHelper.AsyncDeleteData();
            results.Wait();
            TestContext.Progress.WriteLine($"Gateway User Deleted, EmpRef: {_objectContext.GetGatewayPaye()}");
        }
    }
}
