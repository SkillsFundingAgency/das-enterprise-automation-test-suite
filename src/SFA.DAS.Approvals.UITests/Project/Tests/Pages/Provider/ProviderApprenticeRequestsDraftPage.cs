using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderApprenticeRequestsDraftPage : ApprenticeRequestsSubPage
    {   
        protected override string PageTitle => "Apprentice requests";
        protected override bool TakeFullScreenShot => false;
        private static By SortByDateReceivedLink => By.PartialLinkText("Date created");

        public ProviderApprenticeRequestsDraftPage(ScenarioContext context) : base(context)  
        {
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(SortByDateReceivedLink), "Validate SortByDateCreated link on 'Drafts' page");
        }

        internal ProviderApproveApprenticeDetailsPage SelectViewCurrentCohortDetails()
        {
            SelectCurrentCohortDetailsFromTable();
            return new ProviderApproveApprenticeDetailsPage(context);
        }
    }
}
