using System.Linq;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.OrganizationsAndAgreements
{
    internal class AcceptTheAgreementPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//*[@class=\"agreement-title\"]//h1")] private IWebElement _pageHeader;
        [FindsBy(How = How.XPath, Using = ".//input[@type=\"submit\"]")] private IWebElement _acceptAndFinish;

        public AcceptTheAgreementPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        public bool IsPagePresented()
        {
            return _pageHeader.Text.Contains("ESFA Apprenticeship Agreement for Employers");
        }

        public void ScrollToLast()
        {
            var elements = WebBrowserDriver.FindElements(By.XPath(".//*[@class=\"agreement-contents\"]//p"));
            var target = elements.Last();
            var action = new Actions(WebBrowserDriver);
            action.MoveToElement(target);
            action.Perform();
        }

        public OrganizationsAndAgreementsBasePage AcceptAndFinish()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _acceptAndFinish);
            return new OrganizationsAndAgreementsBasePage(WebBrowserDriver);
        }
    }
}