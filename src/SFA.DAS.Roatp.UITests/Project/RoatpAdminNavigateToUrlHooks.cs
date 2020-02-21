using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project
{
    [Binding] [Scope(Tag = "roatpadmin")] [Scope(Tag = "notestdata")]
    public class RoatpAdminNavigateToUrlHooks
    {
        private readonly RoatpConfig _config;
        private readonly IWebDriver _webDriver;

        public RoatpAdminNavigateToUrlHooks(ScenarioContext context)
        {
            _webDriver = context.GetWebDriver();
            _config = context.GetRoatpConfig<RoatpConfig>();
        }

        [BeforeScenario(Order = 35)]
        public void NavigateToRoatpAdmin() => _webDriver.Navigate().GoToUrl(_config.AdminBaseUrl);
    }
}
