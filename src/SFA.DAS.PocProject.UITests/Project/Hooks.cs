using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.PocProject.UITests.Project.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.PocProject.UITests.Project
{
    [Binding]
    public class Hooks          
    {
        private readonly ScenarioContext _context;
        private readonly FrameworkConfig _config;
        private readonly IWebDriver _webDriver;
        private MongoDbHelper _mongoDbHelper;
        private readonly ObjectContext _objectContext;
        private DataHelper _dataHelper;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.Get<FrameworkConfig>();
            _objectContext = context.Get<ObjectContext>();
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
            var projectspecificConfig = _context.GetConfigSection<ProjectSpecificConfig>();

            _dataHelper = new DataHelper(projectspecificConfig.TwoDigitProjectCode);
            _context.Set(_dataHelper);
        }

        [BeforeScenario(Order = 23)]
        [Scope(Tag = "addpayedetails")]
        public void SetUpMongoDbHelpers()
        {
            var mongoDbConfig = _context.GetConfigSection<MongoDbConfig>();

            var mongoDbDataHelper = new MongoDbDataHelper(_dataHelper);
            _context.Set(mongoDbDataHelper);

            TestContext.Progress.WriteLine($"Gateway Id : {mongoDbDataHelper.GatewayId}");

            _objectContext.SetGatewayCreds(mongoDbDataHelper.GatewayId, mongoDbDataHelper.GatewayPassword, mongoDbDataHelper.EmpRef);

            _mongoDbHelper = new MongoDbHelper(mongoDbConfig, mongoDbDataHelper);
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
