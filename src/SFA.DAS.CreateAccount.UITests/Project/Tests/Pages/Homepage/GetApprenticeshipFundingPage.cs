using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.CompaniesHouse;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Homepage
{
    class GetApprenticeshipFundingPage : BasePage
    {
        private const string PageTitle = "Get apprenticeship funding";
        private By _yesRadioOption = By.XPath("//*[@id='do-you-want-to-add-paye-scheme-form']/fieldset/label[1]");
        private By _noRadioOption = By.XPath("//*[@id='do-you-want-to-add-paye-scheme-form']/fieldset/label[2]");
        private By _continueButton = By.XPath("//*[contains(@id,'submit-confirm-who-you-are-button')]");

        public GetApprenticeshipFundingPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
            IsPagePresented();
        }

        public bool IsPagePresented()
        {
            return pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PageTitle);
        }

        public void SelectYesAddMyPAYESchemeDetailsNowRadioButton()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _yesRadioOption);
        }

        public void SelectNoIWillDoThisLaterRadioButton()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _noRadioOption);
        }

        public void ClickContinueButton()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _continueButton);
        }
    }
}
