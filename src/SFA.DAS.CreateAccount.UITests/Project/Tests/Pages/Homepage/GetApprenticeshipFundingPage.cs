using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Homepage
{
    class GetApprenticeshipFundingPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private const string PageTitle = "Get apprenticeship funding";
        private By _yesRadioOption = By.XPath("//*[@id='do-you-want-to-add-paye-scheme-form']/fieldset/label[1]");
        private By _noRadioOption = By.XPath("//*[@id='do-you-want-to-add-paye-scheme-form']/fieldset/label[2]");
        private By _continueButton = By.XPath("//*[contains(@id,'submit-confirm-who-you-are-button')]");

        public GetApprenticeshipFundingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            IsPagePresented();
        }

        public bool IsPagePresented()
        {
            return _pageInteractionHelper.VerifyPage(GetPageHeading(), PageTitle);
        }

        public void SelectYesAddMyPAYESchemeDetailsNowRadioButton()
        {
            _formCompletionHelper.ClickElement(_yesRadioOption);
        }

        public void SelectNoIWillDoThisLaterRadioButton()
        {
            _formCompletionHelper.ClickElement(_noRadioOption);
        }

        public void ClickContinueButton()
        {
            _formCompletionHelper.ClickElement(_continueButton);
        }
    }
}
