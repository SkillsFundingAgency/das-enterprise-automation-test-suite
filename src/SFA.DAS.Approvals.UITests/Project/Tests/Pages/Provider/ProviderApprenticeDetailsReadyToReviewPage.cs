using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderApprenticeDetailsReadyToReviewPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Apprentice requests";
        protected override bool TakeFullScreenShot => false;
        private By SortByDateReceivedLink => By.PartialLinkText("Date received");

        public ProviderApprenticeDetailsReadyToReviewPage(ScenarioContext context) : base(context)  
        {
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(SortByDateReceivedLink), "Validate SortByDateReceived link on 'Ready to review' page");
        }

        public ProviderApproveApprenticeDetailsPage SelectViewCurrentCohortDetails()
        {
            javaScriptHelper.ScrollToTheBottom();
            tableRowHelper.SelectRowFromTableDescending("Details", objectContext.GetCohortReference());
            return new ProviderApproveApprenticeDetailsPage(context);
        }        
    }
}