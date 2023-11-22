using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderApprenticeRequestsReadyForReviewPage : ApprenticeRequestsSubPage
    {
        protected override string PageTitle => "Apprentice requests";
        protected override bool TakeFullScreenShot => false;
        private static By SortByDateReceivedLink => By.PartialLinkText("Date received");

        public ProviderApprenticeRequestsReadyForReviewPage(ScenarioContext context) : base(context)  
        {
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(SortByDateReceivedLink), "Validate SortByDateReceived link on 'Ready to review' page");
        }

        public ProviderApproveApprenticeDetailsPage SelectViewCurrentCohortDetails()
        {
            SelectCurrentCohortDetailsFromTable();

            return new ProviderApproveApprenticeDetailsPage(context);
        }
    }
}