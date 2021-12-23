using OpenQA.Selenium;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderApprenticeRequestsPage : Navigate
    {
        protected override string PageTitle => "Apprentice requests";

        protected override string Linktext => "Apprentice requests";

        private By NumberOfCohortsForReview => By.CssSelector("#Review span.das-tabs-boxes__figure");
        private By NumberOfCohortsWithEmployers => By.CssSelector("#WithEmployer span.das-tabs-boxes__figure");
        private By NumberOfDraftCohorts => By.CssSelector("#Draft span.das-tabs-boxes__figure");
        private By NumberOfCohortsWithTransferSendingEmployers => By.CssSelector("#WithTransferSender span.das-tabs-boxes__figure");

        public ProviderApprenticeRequestsPage(ScenarioContext context, bool navigate = false) : base(context, navigate) => VerifyPage();

        public ProviderApprenticeDetailsReadyToReviewPage GoToCohortsToReviewPage()
        {
            var providerReadyForReviewCohorts = Convert.ToInt32(pageInteractionHelper.GetText(NumberOfCohortsForReview));
            if (providerReadyForReviewCohorts > 0)
            {
                formCompletionHelper.ClickElement(NumberOfCohortsForReview);
                return new ProviderApprenticeDetailsReadyToReviewPage(context);
            }

            throw new Exception("No cohorts available for review");
        }

        internal ProviderApprenticeDetailsWithEmployersPage GoToCohortsWithEmployers()
        {
            var providerWithEmployerCohorts = Convert.ToInt32(pageInteractionHelper.GetText(NumberOfCohortsWithEmployers));
            if (providerWithEmployerCohorts > 0)
            {
                formCompletionHelper.ClickElement(NumberOfCohortsWithEmployers);
                return new ProviderApprenticeDetailsWithEmployersPage(context);
            }

            throw new Exception("No cohorts available with employers");
        }

        internal ProviderDraftApprenticeDetailsPage GoToDraftCohorts()
        {
            var providerWithDraftCohorts = Convert.ToInt32(pageInteractionHelper.GetText(NumberOfDraftCohorts));
            if (providerWithDraftCohorts > 0)
            {
                formCompletionHelper.ClickElement(NumberOfDraftCohorts);
                return new ProviderDraftApprenticeDetailsPage(context);
            }

            throw new Exception("No draft cohorts are available");
        }

        internal ProviderApprenticeDetailsWithTransferSendingEmployersPage GoToCohortsWithTransferSendingEmployers()
        {
            var providerWithTransferSendingEmployerCohorts = Convert.ToInt32(pageInteractionHelper.GetText(NumberOfCohortsWithTransferSendingEmployers));
            if (providerWithTransferSendingEmployerCohorts > 0)
            {
                formCompletionHelper.ClickElement(NumberOfCohortsWithTransferSendingEmployers);
                return new ProviderApprenticeDetailsWithTransferSendingEmployersPage(context);
            }

            throw new Exception("No cohorts available with employers");
        }

        public ProviderApproveApprenticeDetailsPage SelectViewCurrentCohortDetails()
        {
            tableRowHelper.SelectRowFromTable("Details", objectContext.GetCohortReference());
            return new ProviderApproveApprenticeDetailsPage(context);
        }
    }
}