using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticeRequestsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Apprentice requests";

        protected override bool TakeFullScreenShot => false;

        private By NumberOfReadyForReview => By.CssSelector("span[id='Review'] span[class*='das-tabs-boxes__figure']");
        private By NumberOfWithTrainingProviders => By.CssSelector("a[id='WithProvider'] span[class*='das-tabs-boxes__figure']");
        private By NumberOfDrafts => By.CssSelector("a[id='Draft'] span[class*='das-tabs-boxes__figure']");
        private By NumberOfWithTransferSendingEmployers => By.CssSelector("a[id='WithTransferSender'] span[class*='das-tabs-boxes__figure']");

        public ApprenticeRequestsPage(ScenarioContext context) : base(context)  { }

        public ApprenticeRequestsReadyForReviewPage GoToReadyToReview()
        {
            var employerReadyForReviewCohorts = Convert.ToInt32(pageInteractionHelper.GetText(NumberOfReadyForReview));
            if (employerReadyForReviewCohorts > 0)
            {
                formCompletionHelper.ClickElement(NumberOfReadyForReview);
                return new ApprenticeRequestsReadyForReviewPage(context);
            }

            throw new Exception("No cohorts available in Ready to review");
        }

        public ApprenticeRequestsWithTrainingProvidersPage GoToWithTrainingProviders()
        {
            var employerWithTrainingProviders = Convert.ToInt32(pageInteractionHelper.GetText(NumberOfWithTrainingProviders));
            if (employerWithTrainingProviders > 0)
            {
                formCompletionHelper.ClickElement(NumberOfWithTrainingProviders);
                return new ApprenticeRequestsWithTrainingProvidersPage(context);
            }

            throw new Exception("No cohorts available in With training providers");
        }

        public ApprenticeRequestDraftsPage GoToDrafts()
        {
            var employerDraftCohorts = Convert.ToInt32(pageInteractionHelper.GetText(NumberOfDrafts));
            if (employerDraftCohorts > 0)
            {
                formCompletionHelper.ClickElement(NumberOfDrafts);
                return new ApprenticeRequestDraftsPage(context);
            }

            throw new Exception("No cohorts available in Drafts");
        }

        public ApprenticeRequestsWithTransferSendingEmployersPage GoToWithTransferSendingEmployers()
        {
            var employerWithTransferSendingEmployersCohorts = Convert.ToInt32(pageInteractionHelper.GetText(NumberOfWithTransferSendingEmployers));
            if (employerWithTransferSendingEmployersCohorts > 0)
            {
                formCompletionHelper.ClickElement(NumberOfWithTransferSendingEmployers);
                return new ApprenticeRequestsWithTransferSendingEmployersPage(context);
            }

            throw new Exception("No cohorts available in With transfer sending employers");
        }
    }
}

