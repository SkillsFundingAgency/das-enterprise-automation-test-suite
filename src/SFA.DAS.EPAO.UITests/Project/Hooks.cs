using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project
{
    [Binding]
    class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly EPAOConfig _config;
        private readonly IWebDriver _webDriver;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.GetEPAOConfig<EPAOConfig>();
        }

        [BeforeScenario(Order = 21)]
        public void VisitAssessmentServiceApplication()
        {
            var url = _config.EPAOAssessmentServiceUrl;
            _webDriver.Navigate().GoToUrl(url);
        }
    }
}
