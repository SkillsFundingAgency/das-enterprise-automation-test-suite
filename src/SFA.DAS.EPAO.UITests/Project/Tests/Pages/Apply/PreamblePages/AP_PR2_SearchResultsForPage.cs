using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.PreamblePages
{
    public class AP_PR2_SearchResultsForPage : EPAO_BasePage
    {
        protected override string PageTitle => "Search results for";
        private readonly ScenarioContext _context;

        #region Locators
        private By OrgLink => By.XPath($"//button[text()='{ApplyOrganisationName}']");
        private By InvalidSearchResultText => By.CssSelector("#main-content .govuk-heading-m");
        private By SearchTextBox => By.Id("SearchString");
        #endregion

        public AP_PR2_SearchResultsForPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_PR3_SelectOrganisationTypePage ClickOrgLinkFromSearchResultsForPage()
        {
            formCompletionHelper.Click(OrgLink);
            return new AP_PR3_SelectOrganisationTypePage(_context);
        }

        public AP_PR2_SearchResultsForPage VerifyInvalidSearchResultText()
        {
            pageInteractionHelper.VerifyText(InvalidSearchResultText, "We cannot find your organisation details");
            return this;
        }

        public AP_PR2_SearchResultsForPage EnterInvalidOrgNameAndSearchInSearchResultsForPage(string searchTerm)
        {
            formCompletionHelper.EnterText(SearchTextBox, searchTerm);
            Continue();
            return this;
        }
    }
}
