using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class SearchResultsPage : EmployerBasePage
    {
        protected override string PageTitle => "SEARCH RESULTS";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By Keywords => By.CssSelector("#Keywords");
        
        private By Search => By.CssSelector("#employer-apprenticeship-search");

        private By Apprenticeship => By.CssSelector($".das-search-results__list-item[id='{objectContext.GetCourseId()}'] .das-search-result__heading-link");

        public SearchResultsPage(ScenarioContext context) : base(context) => _context = context;

        public EmployerFavouritesPage AddFavouriteApprenticeship()
        {
            AddFavourite();
            GoToBasket();
            return new EmployerFavouritesPage(_context);
        }

        public SummaryOfThisApprenticeshipPage SearchApprenticeship()
        {
            formCompletionHelper.EnterText(Keywords, "Software");
            formCompletionHelper.ClickElement(Search);
            AddFavourite();
            formCompletionHelper.ClickElement(Apprenticeship);
            return new SummaryOfThisApprenticeshipPage(_context);
        }

        private void AddFavourite() => AddFavourite((a) => { campaignsDataHelper.CourseId.Add(a); objectContext.SetCourseId(a); });

    }
}
