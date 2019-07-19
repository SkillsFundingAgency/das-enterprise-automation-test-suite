using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.PublicSectorOrganization;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Organizations
{
    internal class FindOrganizationAddressPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \'Enter address manually\')]")] private IWebElement _enterManuallyButton;

        public FindOrganizationAddressPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        public OrganizationAddressPage EnterManually()
        {
            formCompletionHelper.ClickElement(_enterManuallyButton);
            return new OrganizationAddressPage(WebBrowserDriver);
        }
    }
}