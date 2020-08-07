using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class SearchForAnApprenticeshipPage : EmployerBasePage
    {
        protected override string PageTitle => "FIND APPRENTICESHIP TRAINING";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By Search => By.CssSelector("#employer-apprenticeship-search");

        public SearchForAnApprenticeshipPage(ScenarioContext context) : base(context) => _context = context;

        public SearchResultsPage GoToSearchResultsPage()
        {
            formCompletionHelper.ClickElement(Search);
            return new SearchResultsPage(_context);
        }
    }
}

