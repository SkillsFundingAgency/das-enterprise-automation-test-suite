using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderYourCohortsPage : Navigate
    {
        protected override string PageTitle => "Apprentice requests";

        protected override string Linktext => "Apprentice requests";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion

        private By NumberOfCohortsForReview => By.CssSelector("#Review span.das-card-figure");
        private By NumberOfCohortsWithEmployers => By.CssSelector("#WithEmployer span.das-card-figure");
        private By NumberOfDraftCohorts => By.CssSelector("#Draft span.das-card-figure");
        private By NumberOfCohortsWithTransferSendingEmployers => By.CssSelector("#WithTransferSender span.das-card-figure");

        public ProviderYourCohortsPage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            VerifyPage();
        }

        public ProviderCohortsToReviewPage GoToCohortsToReviewPage()
        {
            var providerReadyForReviewCohorts = Convert.ToInt32(pageInteractionHelper.GetText(NumberOfCohortsForReview));
            if (providerReadyForReviewCohorts > 0)
            {
                formCompletionHelper.ClickElement(NumberOfCohortsForReview);
                return new ProviderCohortsToReviewPage(_context);
            }

            throw new Exception("No cohorts available for review");
        }

        internal ProviderCohortsWithEmployersPage GoToCohortsWithEmployers()
        {
            var providerWithEmployerCohorts = Convert.ToInt32(pageInteractionHelper.GetText(NumberOfCohortsWithEmployers));
            if (providerWithEmployerCohorts > 0)
            {
                formCompletionHelper.ClickElement(NumberOfCohortsWithEmployers);
                return new ProviderCohortsWithEmployersPage(_context);
            }

            throw new Exception("No cohorts available with employers");
        }

        internal ProviderCohortsDraftsPage GoToDraftCohorts()
        {
            var providerWithDraftCohorts = Convert.ToInt32(pageInteractionHelper.GetText(NumberOfDraftCohorts));
            if (providerWithDraftCohorts > 0)
            {
                formCompletionHelper.ClickElement(NumberOfDraftCohorts);
                return new ProviderCohortsDraftsPage(_context);
            }

            throw new Exception("No cohorts available with employers");
        }

        internal ProviderCohortsWithTransferSendingEmployers GoToCohortsWithTransferSendingEmployers()
        {
            var providerWithTransferSendingEmployerCohorts = Convert.ToInt32(pageInteractionHelper.GetText(NumberOfCohortsWithTransferSendingEmployers));
            if (providerWithTransferSendingEmployerCohorts > 0)
            {
                formCompletionHelper.ClickElement(NumberOfCohortsWithTransferSendingEmployers);
                return new ProviderCohortsWithTransferSendingEmployers(_context);
            }

            throw new Exception("No cohorts available with employers");
        }

        public ProviderReviewYourCohortPage SelectViewCurrentCohortDetails()
        {
            tableRowHelper.SelectRowFromTable("Details", _objectContext.GetCohortReference());
            return new ProviderReviewYourCohortPage(_context);
        }
    }
}