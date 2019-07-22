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

        private readonly IWebDriver _webdriver;

        public GrantAuthorityPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _webdriver = context.GetWebDriver();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal bool CheckCompaniesHouseNumberFromSummary(string number)
        {
            var results = _webdriver.FindElements(By.XPath($".//dd[contains (text(), \'{number}\')]"));
            return results.Count == 1;
        }

        internal bool IsSchemeInUse()
        {
            var pageHeaderText = GetPageHeading();
            return pageHeaderText == "PAYE scheme already in use";
        }

        internal void UseDifferentDetailsButton()
        {
            var pageHeaderText = GetPageHeading();
            if (pageHeaderText != "PAYE scheme already in use")
                return;
            var useDifferentDetailsButton =
                _webdriver.FindElement(By.XPath(".//a[contains (text(), \'Use different details\')]"));
            useDifferentDetailsButton.Click();
        }
    }
}