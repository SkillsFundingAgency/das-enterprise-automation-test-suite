using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Organizations
{
    public class RemoveOrganizationConfirmPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly JavaScriptHelper _javaScriptHelper;
        private readonly ScenarioContext _context;
        #endregion

        private const string PageTitle = "Remove organisation";
        private By _continueButton = By.XPath("//button");
        private By _yesRadiobutton = By.XPath("//label[@class='block-label selection-button-radio']/child::input[@value='2']");

        public RemoveOrganizationConfirmPage(ScenarioContext context) : base(context)
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

        public YourOrganizationsBasePage SelectYesRadiobuttonAndContinue()
        {
            _javaScriptHelper.ClickElement(_yesRadiobutton);
            _formCompletionHelper.ClickElement(_continueButton);
            return new YourOrganizationsBasePage(_context);
        }
    }
}