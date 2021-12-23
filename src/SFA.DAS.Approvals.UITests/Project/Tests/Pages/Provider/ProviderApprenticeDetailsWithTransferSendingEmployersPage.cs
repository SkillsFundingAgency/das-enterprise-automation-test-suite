using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderApprenticeDetailsWithTransferSendingEmployersPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Apprentice requests";
        protected override bool TakeFullScreenShot => false;
        private By SortByDateReceivedLink => By.PartialLinkText("Date sent to employer");

        public ProviderApprenticeDetailsWithTransferSendingEmployersPage(ScenarioContext context) : base(context)  
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

