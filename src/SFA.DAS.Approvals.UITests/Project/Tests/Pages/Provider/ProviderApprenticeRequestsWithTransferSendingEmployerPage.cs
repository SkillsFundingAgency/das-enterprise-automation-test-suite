using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderApprenticeRequestsWithTransferSendingEmployerPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Apprentice requests";
        protected override bool TakeFullScreenShot => false;
        private static By SortByDateReceivedLink => By.PartialLinkText("Date sent to employer");

        public ProviderApprenticeRequestsWithTransferSendingEmployerPage(ScenarioContext context) : base(context)  
        {
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(SortByDateReceivedLink), "Validate SortByDateSentToEmployer link on 'With Transfer Sending Employers' page");
        }

        internal ProvideViewApprenticesDetailsPage SelectViewCurrentCohortDetails()
        {
            tableRowHelper.SelectRowFromTableDescending("Details", objectContext.GetCohortReference());
            return new ProvideViewApprenticesDetailsPage(context);
        }
    }
}

