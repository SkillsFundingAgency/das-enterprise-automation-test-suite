using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class YourCohortRequestsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Your cohort requests";

        #region Helpers and Context
        private readonly ScenarioContext _context;
       #endregion

        private By NumberofCohortsForReview => By.CssSelector("a[href*='review'] span[class*='das-card-figure']");
        private By NumberOfTransferRejectedCohorts => By.CssSelector(".block-one .bold-xxlarge");
        private By NumberOfDraftCohorts => By.CssSelector("a[href*='draft'] span[class*='das-card-figure']");

        public YourCohortRequestsPage(ScenarioContext context) : base(context) => _context = context;

        public CohortsForReviewPage GoToCohortsReadyForReview()
        {
            var employerReadyForReviewCohorts = Convert.ToInt32(pageInteractionHelper.GetText(NumberofCohortsForReview));
            if (employerReadyForReviewCohorts > 0)
            {
                formCompletionHelper.ClickElement(NumberofCohortsForReview);
                return new CohortsForReviewPage(_context);
            }

            throw new Exception("No cohorts available for review");
        }
        public DraftCohortsPage GoToDraftCohorts()
        {
            var employerDraftCohorts = Convert.ToInt32(pageInteractionHelper.GetText(NumberOfDraftCohorts));
            if (employerDraftCohorts > 0)
            {
                formCompletionHelper.ClickElement(NumberOfDraftCohorts);
                return new DraftCohortsPage(_context);
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

