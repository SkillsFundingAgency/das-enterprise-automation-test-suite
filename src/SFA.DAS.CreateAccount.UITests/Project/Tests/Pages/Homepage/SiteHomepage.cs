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

        public SiteHomepage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
            IsPagePresented();
        }

        internal bool IsPagePresented()
        {
            return pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PageTitle);
        }

        internal SetUpAsAUserPage ClickCreateAccountButton()
        {
            formCompletionHelper.ClickElement(_createAccountButton);
            return new SetUpAsAUserPage(WebBrowserDriver);
        }

        public SignInPage ClickSignInLink()
        {
            formCompletionHelper.ClickElement(_signInLink);
            return new SignInPage(WebBrowserDriver);
        }

        public string GetSingInInfoText()
        {
            return formCompletionHelper.GetText(_directSignInInfoText);
        }
    }
}