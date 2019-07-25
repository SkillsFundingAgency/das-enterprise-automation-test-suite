using MongoDB.Bson;
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
        private readonly FrameworkConfig _config;
        private readonly IWebDriver _webDriver;
        private readonly MongoDbHelper _mongoDbHelper;

        public Hooks(ScenarioContext context)
        {
            _webDriver = context.GetWebDriver();
            _config = context.Get<FrameworkConfig>();
            _mongoDbHelper = new MongoDbHelper(context);
        }

        [BeforeScenario(Order = 21)]
        public void Navigate()
        {
            var url = _config.BaseUrl;
            _webDriver.Navigate().GoToUrl(url);
        }

        [BeforeScenario(Order = 22)]
        [Scope(Tag = "addpayedetails")]
        public void AddPayeDetails()
        {
            _mongoDbHelper.AsyncCreateGatewayUserData().Wait();
        }
    }
}
