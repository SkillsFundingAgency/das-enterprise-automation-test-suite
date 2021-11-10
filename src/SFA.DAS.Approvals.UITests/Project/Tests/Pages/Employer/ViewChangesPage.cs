using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ViewChangesPage : ApprovalsBasePage
    {
        protected override string PageTitle => "View changes";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ProviderReviewingTheRequestLink => By.LinkText("reviewing the request");
        
        private By ReviewRequestedChangesLink=> By.Id("review-requested-changes-link");

        private By UndoChangesSelector => By.CssSelector("#UndoChanges");

        private By ContinueUndoChangesSelector => By.CssSelector("#continue-button");

        public ViewChangesPage(ScenarioContext context) : base(context) => _context = context;

        public ViewApprenticePage ClickProviderReviewingTheRequestLink()
        {
            formCompletionHelper.ClickElement(ProviderReviewingTheRequestLink);
            return new ViewApprenticePage(_context);
        }

        public ReviewYourCohortPage ClickReviewTheApprenticeDetailsToUpdateLink()
        {
            formCompletionHelper.ClickElement(ReviewRequestedChangesLink);
            return new ReviewYourCohortPage(_context);
        }


        public ApprenticeDetailsPage UndoChanges()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(UndoChangesSelector));
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ContinueUndoChangesSelector));
            return new ApprenticeDetailsPage(_context);
        }
    }
}
