using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account
{
    class SkippyHomePage : BasePage
    {
        private const string PageTitle = "Your employer account";
        private By _addYourPAYELink = By.XPath("//a[contains(text(),'Add your PAYE scheme')]");

        public SkippyHomePage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
            IsPagePresented();
        }

        public bool IsPagePresented()
        {
            return pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PageTitle);
        }

        public void ClickOnAddYourPAYESchemeLink()
        {
            formCompletionHelper.ClickElement(_addYourPAYELink);
        }
    }
}