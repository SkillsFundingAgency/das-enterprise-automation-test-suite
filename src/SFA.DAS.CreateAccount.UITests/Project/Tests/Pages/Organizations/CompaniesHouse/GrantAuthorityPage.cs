using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.CompaniesHouse
{
    public class GrantAuthorityPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        [FindsBy(How = How.CssSelector, Using = "h1")] private IWebElement _pageHeader;

        public GrantAuthorityPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal bool CheckCompaniesHouseNumberFromSummary(string number)
        {
            var results = WebBrowserDriver.FindElements(By.XPath($".//dd[contains (text(), \'{number}\')]"));
            return results.Count == 1;
        }

        internal bool IsSchemeInUse()
        {
            var pageHeaderText = _pageHeader.Text;
            return pageHeaderText == "PAYE scheme already in use";
        }

        internal void UseDifferentDetailsButton()
        {
            var pageHeaderText = _pageHeader.Text;
            if (pageHeaderText != "PAYE scheme already in use")
                return;
            var useDifferentDetailsButton =
                WebBrowserDriver.FindElement(By.XPath(".//a[contains (text(), \'Use different details\')]"));
            useDifferentDetailsButton.Click();
        }
    }
}