using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderApprenticeRequestsWithEmployerPage : ProviderApprenticeRequestsSubPage
    {
        protected override string PageTitle => "Apprentice requests";

        protected override bool TakeFullScreenShot => false;
        private static By SortByDateReceivedLink => By.PartialLinkText("Date sent to employer");

        public ProviderApprenticeRequestsWithEmployerPage(ScenarioContext context) : base(context)  
        {
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(SortByDateReceivedLink), "Validate SortByDateSentToEmployer link on 'With employers' page");
        }

        internal ProvideViewApprenticesDetailsPage SelectViewCurrentCohortDetails()
        {
            SelectCurrentCohortDetailsFromTable();
            return new ProvideViewApprenticesDetailsPage(context);
        }
    }
}
