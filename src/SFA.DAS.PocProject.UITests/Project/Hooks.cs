using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.PocProject.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.PocProject.UITests.Project
{
    [Binding]
    public class Hooks          
    {
        private readonly ScenarioContext _context;
        private readonly ProjectSpecificConfig _config;
        private readonly MongoDbConfig _mongoDbConfig;
        private readonly IWebDriver _webDriver;
        private MongoDbHelper _mongoDbHelper;
        private MongoDbConnectionHelper _mongodbConnectionHelper;
        private readonly ObjectContext _objectContext;
        private DataHelper _dataHelper;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.GetConfigSection<ProjectSpecificConfig>();
            _mongoDbConfig = _context.GetConfigSection<MongoDbConfig>();
            _objectContext = context.Get<ObjectContext>();
        }

        [BeforeScenario(Order = 21)]
        public void Navigate()
        {
            var url = _config.PP_BaseUrl;
            _webDriver.Navigate().GoToUrl(url);
        }

        [BeforeScenario(Order = 22)]
        public void SetUpDataHelpers()
        {
            _dataHelper = new DataHelper(_config.TwoDigitProjectCode);
            _context.Set(_dataHelper);
        }

        [BeforeScenario(Order = 23)]
        [Scope(Tag = "addpayedetails")]
        public void SetUpMongoDbHelpers()
        {
            var mongoDbDataHelper = new MongoDbDataHelper(_dataHelper);

            TestContext.Progress.WriteLine($"Gateway Id : {mongoDbDataHelper.GatewayId}");

            _objectContext.SetGatewayCreds(mongoDbDataHelper.GatewayId, mongoDbDataHelper.GatewayPassword, mongoDbDataHelper.EmpRef);

            _mongodbConnectionHelper = new MongoDbConnectionHelper(_mongoDbConfig);

            _mongoDbHelper = new MongoDbHelper(_mongodbConnectionHelper, mongoDbDataHelper);
        }

        [BeforeScenario(Order = 24)]
        [Scope(Tag = "addpayedetails")]
        public void AddPayeDetails()
        {
            TestContext.Progress.WriteLine($"Connecting to MongoDb Database : {_mongoDbConfig.Database}");
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
