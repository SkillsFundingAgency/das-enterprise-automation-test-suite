using SFA.DAS.CreateAccount.UITests.Project.Framework.Helpers;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Organizations;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.PublicSectorOrganization
{
    internal class PublicSectorSearchPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \'add it manually here\')]")] private IWebElement _addManuallyButton;

        public PublicSectorSearchPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        public FindOrganizationAddressPage PickFirstOrganization()
        {
            var link = WebBrowserDriver.FindElement(By.XPath(".//ol[@class=\"search-results\"]/li[1]//button"));
            formCompletionHelper.ClickElement(WebBrowserDriver, link);
            return new FindOrganizationAddressPage(WebBrowserDriver);
        }

        public string GetFirstOrganizationName()
        {
            var link = WebBrowserDriver.FindElement(By.XPath(".//ol[@class=\"search-results\"]/li[1]"));
            formCompletionHelper.ClickElement(WebBrowserDriver, link);
            return link.Text;
        }

        public EnterOrganizationNamePage SetOrganizationManually()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _addManuallyButton);
            return new EnterOrganizationNamePage(WebBrowserDriver);
        }
    }
}