using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.OrganizationsAndAgreements
{
    class ReviewYourDetailsPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly JavaScriptHelper _javaScriptHelper;
        private readonly ScenarioContext _context;
        #endregion

        private const string PageTitle = "Review your details";
        private By _goToOrgsPageRadioButton = By.XPath("//div[@class=\'multiple-choice\']/child::input[@value=\'dashboard\']");
        private By _updateDetailsRadioButton = By.XPath("(//div[@class=\'multiple-choice\'])[1]");
        private By _continueButton = By.XPath("//button[@type=\'submit\']");
        private By _getMessageDisplayed = By.XPath("(//p)[3]");

        public ReviewYourDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _javaScriptHelper = context.Get<JavaScriptHelper>();
            IsPagePresented();
        }

        public bool IsPagePresented()
        {
            return _pageInteractionHelper.VerifyPage(GetPageHeading(), PageTitle);
        }

        public bool CheckMessageDisplayed(string expectedMessage)
        {
            return (_pageInteractionHelper.GetText(_getMessageDisplayed).Contains(expectedMessage));
        }

        public void SelectGoToOrgsRadioButtionAndContinue()
        {
            _javaScriptHelper.ClickElement(_goToOrgsPageRadioButton);
            _formCompletionHelper.ClickElement(_continueButton);
        }

        public void SelectUpdateDetailsRadioButtionAndContinue()
        {
            _formCompletionHelper.ClickElement(_updateDetailsRadioButton);
            _formCompletionHelper.ClickElement(_continueButton);
        }
    }
}