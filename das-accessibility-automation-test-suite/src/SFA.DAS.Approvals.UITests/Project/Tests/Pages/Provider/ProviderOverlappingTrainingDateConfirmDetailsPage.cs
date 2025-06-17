using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderOverlappingTrainingDateConfirmDetailsPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        protected override string PageTitle => "Confirm details";

        protected override bool TakeFullScreenShot => false;


        public ProviderOverlappingTrainingDatePlannedStartDateOverlapPage SelectYesTheseDetailsAreCorrect()
        {
            Continue();
            return new ProviderOverlappingTrainingDatePlannedStartDateOverlapPage(context);
        }
    }
}
