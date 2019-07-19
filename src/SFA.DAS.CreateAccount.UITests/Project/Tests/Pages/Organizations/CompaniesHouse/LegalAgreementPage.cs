using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.CompaniesHouse
{
    public class LegalAgreementPage : BasePage
    {
        private const string continuebtnid = "continue";
        [FindsBy(How = How.Id, Using = continuebtnid)] private IWebElement _continuebtn;

        public LegalAgreementPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        internal EmployerAccountHomepage Continue()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _continuebtn);
            return new EmployerAccountHomepage(WebBrowserDriver);
        }
    }
}