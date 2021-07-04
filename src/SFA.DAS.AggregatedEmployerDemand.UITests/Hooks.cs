using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests
{
    [Binding]
    public class Hooks
    {
        private readonly IWebDriver _webDriver;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ProviderConfig _config;


        public Hooks(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.GetProviderConfig<ProviderConfig>();
            _objectContext = context.Get<ObjectContext>();
        }


        [BeforeScenario(Order = 21)]
        public void NavigateToFATHomepage() => _webDriver.Navigate().GoToUrl(UrlConfig.FATV2_BaseUrl);
    }
}
