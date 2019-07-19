using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.OrganizationsAndAgreements
{
    class ReviewYourDetailsPage : BasePage
    {
        private const string PageTitle = "Review your details";
        private By _goToOrgsPageRadioButton = By.XPath("//div[@class=\'multiple-choice\']/child::input[@value=\'dashboard\']");
        private By _updateDetailsRadioButton = By.XPath("(//div[@class=\'multiple-choice\'])[1]");
        private By _continueButton = By.XPath("//button[@type=\'submit\']");
        private By _getMessageDisplayed = By.XPath("(//p)[3]");

        public ReviewYourDetailsPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
            IsPagePresented();
        }

        public bool IsPagePresented()
        {
            return pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PageTitle);
        }

        public bool CheckMessageDisplayed(string expectedMessage)
        {
            return (pageInteractionHelper.GetText(_getMessageDisplayed).Contains(expectedMessage));
        }

        public void SelectGoToOrgsRadioButtionAndContinue()
        {
            formCompletionHelper.ClickElementExecutingJavaScript(_goToOrgsPageRadioButton);
            formCompletionHelper.ClickElement(_continueButton);
        }

        public void SelectUpdateDetailsRadioButtionAndContinue()
        {
            formCompletionHelper.ClickElement(_updateDetailsRadioButton);
            formCompletionHelper.ClickElement(_continueButton);
        }
    }
}