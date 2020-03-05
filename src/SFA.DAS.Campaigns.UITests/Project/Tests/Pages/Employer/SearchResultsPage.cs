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

        public SearchResultsPage(ScenarioContext context) : base(context) => _context = context;

        public EmployerFavouritesPage AddFavouriteApprenticeship()
        {
            AddFavourite((a) =>
            {
                campaignsDataHelper.CourseId.Add(a);
                objectContext.SetCourseId(a);
            });

            GoToBasket();
            return new EmployerFavouritesPage(_context);
        }
    }
}
