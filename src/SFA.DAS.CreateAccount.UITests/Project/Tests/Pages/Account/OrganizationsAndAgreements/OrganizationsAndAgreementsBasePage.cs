using System.Linq;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.OrganizationsAndAgreements
{
    internal class OrganizationsAndAgreementsBasePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//h1[@class=\"heading-xlarge\"]")] private IWebElement _pageHeader;
        [FindsBy(How = How.XPath, Using = "(//td[@data-label=\"Action\"]//a)[1]")] private IWebElement _signOrViewAgreementLink;

        public OrganizationsAndAgreementsBasePage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        public bool IsPagePresented()
        {
            return _pageHeader.Text == "Your organisations and agreements";
        }

        public void SignAgreementForLastOrganizationFromList()
        {
            var elements =
                WebBrowserDriver.FindElements(By.XPath("//td[@data-label=\"Action\"]//a"));
            formCompletionHelper.ClickElement(elements.Last());
        }

        public string GetNotification()
        {
            var elements = WebBrowserDriver.FindElements(By.XPath(".//h1[@class=\"bold-large\"]"));
            var element = elements.LastOrDefault();
            return element == null ? "" : element.Text;
        }

        public string GetActionColumnStatusOfLastOrganization()
        {
            var elements =
                WebBrowserDriver.FindElements(By.XPath("//td[@data-label=\"Action\"]//a"));
            return elements.Last().Text;
        }

        public string GetAgreementStatusOfLastOrganization()
        {
            var elements =
                WebBrowserDriver.FindElements(By.XPath(".//table[@class=\"organisations\"]//tr//td[2]//span"));
            return elements.Last().Text;
        }

        public void ClickSignOrViewAgreementLink()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver,_signOrViewAgreementLink);
        }
    }
}