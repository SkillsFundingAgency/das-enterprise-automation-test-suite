using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    public class SaveTheTrainingProviderPage:BasePage
    {
       protected override string PageTitle => "";
        #region Constants
        private const string ExpectedPageTitle = "YOUR FAVOURITE APPRENTICESHIPS AND TRAINING PROVIDERS";

        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly TabHelper _tabHelper;
        #endregion

        #region Page Object Elements
        private readonly By _pageTitle = By.XPath("//h1[@class='hero-heading__heading heading-xl']");
        
        private readonly By _createAccountButton=By.XPath("//a[@class='button button--sparks button-employer']");
        #endregion


        public SaveTheTrainingProviderPage(ScenarioContext context):base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _tabHelper = context.Get<TabHelper>();
        }

        public ManageApprenticeshipLoginPage ClickonCreateAccountButton()
        {
            _tabHelper.OpenInNewTab(() => _formCompletionHelper.ClickElement(_createAccountButton));
            return new ManageApprenticeshipLoginPage(_context);
        }
    }
}
