using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ViewChangesPage : ApprovalsBasePage
    {
        protected override string PageTitle => "View changes";

        protected override bool TakeFullScreenShot => false;

        private By ProviderReviewingTheRequestLink => By.LinkText("reviewing the request");
        
        private By ReviewRequestedChangesLink=> By.Id("review-requested-changes-link");

        private By UndoChangesSelector => By.CssSelector("#UndoChanges");

        private By ContinueUndoChangesSelector => By.CssSelector("#continue-button");

        public ViewChangesPage(ScenarioContext context) : base(context)  { }

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
