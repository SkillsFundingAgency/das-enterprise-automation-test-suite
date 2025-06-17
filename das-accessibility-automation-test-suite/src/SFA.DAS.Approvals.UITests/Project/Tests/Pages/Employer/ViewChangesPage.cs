using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ViewChangesPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "View changes";

        protected override bool TakeFullScreenShot => false;

        private static By ProviderReviewingTheRequestLink => By.LinkText("reviewing the request");

        private static By ReviewRequestedChangesLink => By.Id("review-requested-changes-link");

        private static By UndoChangesSelector => By.CssSelector("#UndoChanges");

        private static By ContinueUndoChangesSelector => By.CssSelector("#continue-button");

        public ViewApprenticePage ClickProviderReviewingTheRequestLink()
        {
            formCompletionHelper.ClickElement(ProviderReviewingTheRequestLink);
            return new ViewApprenticePage(context);
        }

        public ApproveApprenticeDetailsPage ClickReviewTheApprenticeDetailsToUpdateLink()
        {
            formCompletionHelper.ClickElement(ReviewRequestedChangesLink);
            return new ApproveApprenticeDetailsPage(context);
        }

        public ApprenticeDetailsPage UndoChanges()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(UndoChangesSelector));
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ContinueUndoChangesSelector));
            return new ApprenticeDetailsPage(context);
        }
    }
}
