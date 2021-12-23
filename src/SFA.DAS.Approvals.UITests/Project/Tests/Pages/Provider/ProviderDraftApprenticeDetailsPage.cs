using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderDraftApprenticeDetailsPage : ApprovalsBasePage
    {   
        protected override string PageTitle => "Apprentice requests";
        protected override bool TakeFullScreenShot => false;
        private By SortByDateReceivedLink => By.PartialLinkText("Date created");

        public ProviderDraftApprenticeDetailsPage(ScenarioContext context) : base(context)  
        {
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(SortByDateReceivedLink), "Validate SortByDateCreated link on 'Drafts' page");
        }

        internal ProviderApproveApprenticeDetailsPage SelectViewCurrentCohortDetails()
        {
            tableRowHelper.SelectRowFromTableDescending("Details", objectContext.GetCohortReference());
            return new ProviderApproveApprenticeDetailsPage(context);
        }
    }
}
