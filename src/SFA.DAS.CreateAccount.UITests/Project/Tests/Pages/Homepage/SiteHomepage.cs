using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Homepage
{
    public class SiteHomepage : BasePage
    {
        private const string PageTitle = "Create an account to manage apprenticeships";
        private By _createAccountButton = By.Id("service-start");
        private By _directSignInInfoText = By.XPath("(//p)[2]");
        private By _signInLink = By.XPath("//a[text()='sign in']");

        public SiteHomepage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            IsPagePresented();
        }

        internal bool IsPagePresented()
        {
            return pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PageTitle);
        }

        internal SetUpAsAUserPage ClickCreateAccountButton()
        {
            _formCompletionHelper.ClickElement(_createAccountButton);
            return new SetUpAsAUserPage(WebBrowserDriver);
        }

        public SignInPage ClickSignInLink()
        {
            _formCompletionHelper.ClickElement(_signInLink);
            return new SignInPage(WebBrowserDriver);
        }

        public string GetSingInInfoText()
        {
            return _formCompletionHelper.GetText(_directSignInInfoText);
        }
    }
}