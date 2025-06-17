using Dynamitey;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCoEOverlappingTrainingDateConfirmDatesPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override By ContinueButton => By.Id("confirm-button");

        protected override string PageTitle => "Confirm details";

        public ProviderOverlappingTrainingDatePlannedStartDateOverlapPage SaveAndSend()
        {
            Continue();
            return new ProviderOverlappingTrainingDatePlannedStartDateOverlapPage(context);
        }

    }
}
