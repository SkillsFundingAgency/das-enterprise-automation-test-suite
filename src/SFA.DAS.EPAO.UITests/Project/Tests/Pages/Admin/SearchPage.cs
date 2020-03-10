using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class SearchPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Search";

        protected override By PageHeader => By.CssSelector(".govuk-label--xl");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LearnerSearchField => By.Id("SearchString");

        public SearchPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public SearchResultsPage SearchFor(string keyword)
        {
            formCompletionHelper.EnterText(LearnerSearchField, keyword);
            Continue();
            return new SearchResultsPage(_context);
        }
    }
}
