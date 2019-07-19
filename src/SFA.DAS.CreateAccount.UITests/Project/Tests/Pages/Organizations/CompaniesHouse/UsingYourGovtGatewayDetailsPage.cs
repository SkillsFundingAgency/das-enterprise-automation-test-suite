using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.CompaniesHouse
{
    public class UsingYourGovtGatewayDetailsPage : BasePage
    {
        private const string PageTitle = "Using your Government Gateway details";
        private By _agreeAndContinueButton = By.XPath("//*[contains(@id, 'agree_and_continue')]");

        public UsingYourGovtGatewayDetailsPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
            IsPagePresented();
        }

        internal bool IsPagePresented()
        {
            return pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PageTitle);
        }

        internal SignInGovernmentPage Continue()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _agreeAndContinueButton);
            return new SignInGovernmentPage(WebBrowserDriver);
        }
    }
}