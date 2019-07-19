using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.OrganizationsAndAgreements
{
    class DetailsUpdatedPage : BasePage
    {
        private const string PageTitle = "Details updated";
        private By _goToOrgsPageRadioButton = By.XPath("//div[@class=\'multiple-choice\']/child::input[@value=\'dashboard\']");
        private By _continueButton = By.XPath("//button[@type=\'submit\']");
        private By _getMessageDisplayed = By.XPath("(//p)[3]");

        public DetailsUpdatedPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
            IsPagePresented();
        }

        public bool IsPagePresented()
        {
            return pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PageTitle);
        }

        public bool CheckMessageDisplayed(string expectedMessage)
        {
            return (pageInteractionHelper.GetText(WebBrowserDriver, _getMessageDisplayed).Contains(expectedMessage));
        }

        public void SelectGoToOrgsRadioButtionAndContinue()
        {
            formCompletionHelper.ClickElementExecutingJavaScript(WebBrowserDriver, _goToOrgsPageRadioButton);
            formCompletionHelper.ClickElement(WebBrowserDriver, _continueButton);
        }
    }
}