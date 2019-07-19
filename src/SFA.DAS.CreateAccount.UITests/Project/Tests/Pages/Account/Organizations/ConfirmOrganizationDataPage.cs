using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.CompaniesHouse;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Organizations
{
    internal class ConfirmOrganizationDataPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//*[@type=\"submit\"]")] private IWebElement _confirmButton;

        public ConfirmOrganizationDataPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        internal LegalAgreementPage Confirm()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _confirmButton);
            return new LegalAgreementPage(WebBrowserDriver);
        }

        private By orgName = By.XPath("//tbody/tr[1]/td");
        internal string GetOrganizationInfo()
        {
            return pageInteractionHelper.GetText(WebBrowserDriver, orgName);
        }

        private By charityNumber = By.XPath("//tbody/tr[3]/td");
        internal string GetCharityNumber()
        {
            return pageInteractionHelper.GetText(WebBrowserDriver, charityNumber);
        }

        private By charityAddress = By.XPath("//tbody/tr[2]/td");
        internal string GetCharityAddress()
        {
            return pageInteractionHelper.GetText(WebBrowserDriver, charityAddress);
        }

    }
}