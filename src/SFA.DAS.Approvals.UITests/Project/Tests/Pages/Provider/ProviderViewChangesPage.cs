using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderViewChangesPage : ApprovalsBasePage
    {
        protected override string PageTitle => "View changes";
        private By ReviewNewDetails => By.LinkText("reviewing the new details");
        private By ReviewNewDetailsToUpdate => By.LinkText("Review the apprentice details to update");

        private readonly ScenarioContext _context;

        public ProviderViewChangesPage(ScenarioContext context) : base(context) => _context = context;
        
        public ProviderViewYourCohortPage ClickOnReviewNewDetailsLink()
        {
            formCompletionHelper.Click(ReviewNewDetails);
            return new ProviderViewYourCohortPage(_context);
        }

        public ProviderReviewYourCohortPage ClickOnReviewNewDetailsToUpdateLink()
        {
            formCompletionHelper.Click(ReviewNewDetailsToUpdate);
            return new ProviderReviewYourCohortPage(_context);
        }
    }
}
