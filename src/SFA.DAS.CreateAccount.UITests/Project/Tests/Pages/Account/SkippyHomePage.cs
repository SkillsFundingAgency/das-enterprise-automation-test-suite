using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account
{
    class SkippyHomePage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private const string PageTitle = "Your employer account";
        private By _addYourPAYELink = By.XPath("//a[contains(text(),'Add your PAYE scheme')]");

        public SkippyHomePage(ScenarioContext context) : base(context)
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

        public void ClickOnAddYourPAYESchemeLink()
        {
            _formCompletionHelper.ClickElement(_addYourPAYELink);
        }
    }
}