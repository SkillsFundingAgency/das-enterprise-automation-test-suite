using Dynamitey;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCoEOverlappingTrainingDateConfirmDatesPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Save and send')]");

        protected override string PageTitle => "Confirm dates before sending your request";

        protected override bool TakeFullScreenShot => false;


        public ProviderCoEOverlappingTrainingDatePlannedStartDateOverlapsPage SaveAndSend()
        {
            Continue();
            return new ProviderCoEOverlappingTrainingDatePlannedStartDateOverlapsPage(context);
        }

    }
}
