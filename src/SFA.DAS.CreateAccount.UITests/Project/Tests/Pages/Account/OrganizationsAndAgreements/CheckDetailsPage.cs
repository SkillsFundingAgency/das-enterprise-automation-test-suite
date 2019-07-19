using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.OrganizationsAndAgreements
{
    class CheckDetailsPage : BasePage
    {
        private const string PageTitle = "Check details";
        private By _continueButton = By.XPath("//input[contains(@value, 'continue')]");

        public CheckDetailsPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
            IsPagePresented();
        }

        public bool IsPagePresented()
        {
            return pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PageTitle);
        }

        public void ClickOnContinueButton()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _continueButton);
        }
    }
}