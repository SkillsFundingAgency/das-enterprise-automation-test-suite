using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Organizations
{
    public class RemoveOrganizationConfirmPage : BasePage
    {
        private const string PageTitle = "Remove organisation";
        private By _continueButton = By.XPath("//button");
        private By _yesRadiobutton = By.XPath("//label[@class='block-label selection-button-radio']/child::input[@value='2']");

        public RemoveOrganizationConfirmPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
            IsPagePresented();
        }

        public bool IsPagePresented()
        {
            return pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PageTitle);
        }

        public YourOrganizationsBasePage SelectYesRadiobuttonAndContinue()
        {
            formCompletionHelper.ClickElementExecutingJavaScript(WebBrowserDriver, _yesRadiobutton);
            formCompletionHelper.ClickElement(WebBrowserDriver, _continueButton);
            return new YourOrganizationsBasePage(WebBrowserDriver);
        }
    }
}