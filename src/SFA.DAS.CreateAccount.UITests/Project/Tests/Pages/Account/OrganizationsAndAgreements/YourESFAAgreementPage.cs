using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.OrganizationsAndAgreements
{
    internal class YourESFAAgreementPage : BasePage
    {
        private const string PageTitle = "Your ESFA agreement";
        private By _updateTheseDetailsLink = By.XPath("//a[contains(text(),\'Update these details\')]");

        public YourESFAAgreementPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        public bool IsPagePresented()
        {
            return pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PageTitle);
        }

        public bool IsUpdateDetailsLinkPresent()
        {
            return formCompletionHelper.IsElementDisplayed(WebBrowserDriver, _updateTheseDetailsLink);
        }

        public void ClickUpdateDetailsLink()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _updateTheseDetailsLink);
        }
    }
}