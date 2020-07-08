using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticeRequestsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Apprentice requests";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By NumberofApprenticeRequestsReadyForReview => By.CssSelector("span[id='Review'] span[class*='das-tabs-boxes__figure']");
        private By NumberOfTransferRejectedCohorts => By.CssSelector(".block-one .bold-xxlarge");
        private By NumberOfDrafts => By.CssSelector("a[href*='draft'] span[class*='das-tabs-boxes__figure']");

        public ApprenticeRequestsPage(ScenarioContext context) : base(context) => _context = context;

        public ApprenticeRequestsReadyToReview GoToReadyToReview()
        {
            var employerReadyForReviewCohorts = Convert.ToInt32(pageInteractionHelper.GetText(NumberofApprenticeRequestsReadyForReview));
            if (employerReadyForReviewCohorts > 0)
            {
                formCompletionHelper.ClickElement(NumberofApprenticeRequestsReadyForReview);
                return new ApprenticeRequestsReadyToReview(_context);
            }

            throw new Exception("No cohorts available for review");
        }
        public ApprenticeRequestDraftsPage GoToDrafts()
        {
            var employerDraftCohorts = Convert.ToInt32(pageInteractionHelper.GetText(NumberOfDrafts));
            if (employerDraftCohorts > 0)
            {
                formCompletionHelper.ClickElement(NumberOfDrafts);
                return new ApprenticeRequestDraftsPage(_context);
            }

            throw new Exception("No cohorts available in Draft");
        }

        public RejectedTransferRequestsPage GoToRejectedTransferRequests()
        {
            int employerRejectedTransferRequests = Convert.ToInt32(pageInteractionHelper.GetText(NumberOfTransferRejectedCohorts));
            if (employerRejectedTransferRequests > 0)
            {
                formCompletionHelper.ClickElement(NumberOfTransferRejectedCohorts);
                return new RejectedTransferRequestsPage(_context);
            }
            throw new Exception("No cohorts available with Employer in Rejected Transfers Request Status");
        }
    }
}

