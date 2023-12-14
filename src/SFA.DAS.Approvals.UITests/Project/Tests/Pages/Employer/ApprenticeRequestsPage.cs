using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticeRequestsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Apprentice requests";

        protected override bool TakeFullScreenShot => false;

        private static By NumberOfReadyForReview => By.CssSelector("span[id='Review'] span[class*='das-tabs-boxes__figure']");
        private static By NumberOfWithTrainingProviders => By.CssSelector("a[id='WithProvider'] span[class*='das-tabs-boxes__figure']");
        private static By NumberOfDrafts => By.CssSelector("a[id='Draft'] span[class*='das-tabs-boxes__figure']");
        private static By NumberOfWithTransferSendingEmployers => By.CssSelector("a[id='WithTransferSender'] span[class*='das-tabs-boxes__figure']");

        public ApprenticeRequestsPage(ScenarioContext context) : base(context) { }

        public ApprenticeRequestsReadyForReviewPage GoToReadyToReview() => AssertPage<ApprenticeRequestsReadyForReviewPage>(NumberOfReadyForReview, "Ready to review", () => new(context));

        public ApprenticeRequestsWithTrainingProvidersPage GoToWithTrainingProviders() => AssertPage<ApprenticeRequestsWithTrainingProvidersPage>(NumberOfWithTrainingProviders, "With training providers", () => new(context));

        public ApprenticeRequestDraftsPage GoToDrafts() => AssertPage<ApprenticeRequestDraftsPage>(NumberOfDrafts, "Drafts", () => new(context));

        public ApprenticeRequestsWithTransferSendingEmployersPage GoToWithTransferSendingEmployers() => AssertPage<ApprenticeRequestsWithTransferSendingEmployersPage>(NumberOfWithTransferSendingEmployers, "With transfer sending employers", () => new(context));

        private T AssertPage<T>(By by, string columnName, Func<T> returnfunc)
        {
            context.Get<RetryAssertHelper>().RetryOnNUnitException(() =>
            {
                Assert.That(Convert.ToInt32(pageInteractionHelper.GetText(by)) > 0, $"No cohorts available in '{columnName}' column");

                formCompletionHelper.ClickElement(by);
            }, () => pageInteractionHelper.RefreshPage());

            return returnfunc();
        }
    }
}

