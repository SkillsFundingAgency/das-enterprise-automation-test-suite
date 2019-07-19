using SFA.DAS.CreateAccount.UITests.Project.Framework.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account
{
    class SignOutPage : BasePage
    {
        private const string PageTitle = "You've logged out";
        private By _continueBtn = By.XPath("//a[contains (text(), \'Continue\')]");

        public SignOutPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
            IsPagePresented();
        }

        public bool IsPagePresented()
        {
            return pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PageTitle);
        }

        internal void ClickContinue()
        {
            formCompletionHelper.ClickElement(_continueBtn);
        }
    }
}