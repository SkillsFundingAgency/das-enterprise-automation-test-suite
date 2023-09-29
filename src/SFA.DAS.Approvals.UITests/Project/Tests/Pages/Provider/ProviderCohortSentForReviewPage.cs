using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCohortSentForReviewPage : ApprovalsBasePage
    {
        private static By CohortRefTableCell => By.XPath("//*[@id='main-content']/div/div/dl/div[1]/dd");

        protected override string PageTitle => "Cohort sent to employer for review";

        protected override bool TakeFullScreenShot => false;

        public ProviderCohortSentForReviewPage(ScenarioContext context) : base(context)
        {
        }

        public string CohortReference() => pageInteractionHelper.GetText(CohortRefTableCell);
    }
}