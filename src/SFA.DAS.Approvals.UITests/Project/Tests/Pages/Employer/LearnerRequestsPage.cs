using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class LearnerRequestsPage(ScenarioContext context) : ApprovalsApprenticeBasePage(context)
    {
        protected override string PageTitle => "Learner requests";

        protected override bool TakeFullScreenShot => false;

        private static By NumberOfReadyForReview => By.CssSelector("span[id='Review'] span[class*='das-tabs-boxes__figure']");
        private static By NumberOfWithTrainingProviders => By.CssSelector("a[id='WithProvider'] span[class*='das-tabs-boxes__figure']");
        private static By NumberOfDrafts => By.CssSelector("a[id='Draft'] span[class*='das-tabs-boxes__figure']");
        private static By NumberOfWithTransferSendingEmployers => By.CssSelector("a[id='WithTransferSender'] span[class*='das-tabs-boxes__figure']");

        public LearnerRequestsReadyForReviewPage GoToReadyToReview() => AssertPage<LearnerRequestsReadyForReviewPage>(NumberOfReadyForReview, "requests to review", () => new(context));

        public LearnerRequestsWithTrainingProvidersPage GoToWithTrainingProviders() => AssertPage<LearnerRequestsWithTrainingProvidersPage>(NumberOfWithTrainingProviders, "with training providers", () => new(context));

        public LearnerRequestDraftsPage GoToDrafts() => AssertPage<LearnerRequestDraftsPage>(NumberOfDrafts, "drafts", () => new(context));

        public LearnerRequestsWithTransferSendingEmployersPage GoToWithTransferSendingEmployers() => AssertPage<LearnerRequestsWithTransferSendingEmployersPage>(NumberOfWithTransferSendingEmployers, "with transfer sending employers", () => new(context));

        private T AssertPage<T>(By by, string columnName, Func<T> returnfunc)
        {
            context.Get<RetryAssertHelper>().RetryOnApprenticeRequestsPage(() =>
            {
                Assert.That(Convert.ToInt32(pageInteractionHelper.GetText(by)) > 0, $"No cohorts available in '{columnName}' column");

                formCompletionHelper.ClickElement(by);
            }, RefreshPage);

            return returnfunc();
        }
    }
}

