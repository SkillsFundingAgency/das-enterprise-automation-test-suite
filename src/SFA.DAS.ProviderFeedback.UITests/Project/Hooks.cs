using OpenQA.Selenium;
using SFA.DAS.ProviderFeedback.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly IWebDriver _webDriver;
        private readonly ProviderFeedbackConfig _config;
        private ProviderFeedbackSqlHelper _providerFeedbackSqlHelper;
        private readonly ScenarioContext _context;
        private TabHelper _tabHelper;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _config = context.GetProviderFeedbackConfig<ProviderFeedbackConfig>();
        }

        [BeforeScenario(Order = 21)]
        public void SetUpHelpers()
        {
            _providerFeedbackSqlHelper = new ProviderFeedbackSqlHelper(_config);

            _context.Set(_providerFeedbackSqlHelper);
        }

        [BeforeScenario(Order = 22)]
        public void NavigateToProviderFeedbackpage()
        {
            _tabHelper = _context.Get<TabHelper>();

            _tabHelper.GoToUrl(_config.ProviderFeedbackUrl, _providerFeedbackSqlHelper.GetUniqueSurveyCode());
        }
    }
}
