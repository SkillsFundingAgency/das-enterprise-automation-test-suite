using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.ProviderFeedback.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ProviderFeedbackConfig _providerFeedbackConfig;
        private ProviderFeedbackSqlHelper _providerFeedbackSqlHelper;
        private readonly ScenarioContext _context;
        private TabHelper _tabHelper;
        private readonly ObjectContext _objectContext;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _providerFeedbackConfig = context.GetProviderFeedbackConfig<ProviderFeedbackConfig>();
        }

        [BeforeScenario(Order = 21)]
        public void SetUpHelpers()
        {
            _providerFeedbackSqlHelper = new ProviderFeedbackSqlHelper(_providerFeedbackConfig);

            _context.Set(_providerFeedbackSqlHelper);
        }

        [BeforeScenario(Order = 22)]
        public void NavigateToProviderFeedbackpage()
        {
            _tabHelper = _context.Get<TabHelper>();

            var uniqueSurveyCode = _providerFeedbackSqlHelper.GetUniqueSurveyCode();

            _objectContext.SetUniqueSurveyCode(uniqueSurveyCode);

            _tabHelper.GoToUrl(_providerFeedbackConfig.ProviderFeedbackUrl, uniqueSurveyCode);
        }
    }
}
