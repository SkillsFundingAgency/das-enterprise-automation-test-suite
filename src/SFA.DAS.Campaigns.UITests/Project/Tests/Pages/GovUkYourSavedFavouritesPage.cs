using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class GovUkYourSavedFavouritesPage : CampaingnsBasePage
    {
        protected override string PageTitle => "Your saved favourites";

        protected override By PageHeader => By.CssSelector(".govuk-caption-xl");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By RemoveFromFav(string id) => By.CssSelector($".app-task-list__training-provider-content[href*='{id}/delete']");

        public GovUkYourSavedFavouritesPage(ScenarioContext context) : base(context) => _context = context;
            
        public GovUKConfirmRemovalPage RemoveFromFavourites(string courseId)
        {
            formCompletionHelper.Click(RemoveFromFav(courseId));
            return new GovUKConfirmRemovalPage(_context);
        }
    }
}
