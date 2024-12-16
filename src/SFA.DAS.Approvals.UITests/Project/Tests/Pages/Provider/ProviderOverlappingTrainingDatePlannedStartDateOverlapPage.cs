using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderOverlappingTrainingDatePlannedStartDateOverlapPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Submit')]");

        protected override string PageTitle => "Planned start date overlaps with existing training";

        protected override bool TakeFullScreenShot => false;

        private static By ChangeEmployerLater => By.CssSelector("#overlap-option-2");

        private static By SendStopEmailButton => By.CssSelector("#overlap-option-1");

        public ProviderApproveApprenticeDetailsPage SelectIWillChangeEmployerLater()
        {
            formCompletionHelper.SelectRadioOptionByLocator(ChangeEmployerLater);
            Continue();
            return new ProviderApproveApprenticeDetailsPage(context);
        }

        public ProviderCoEOverlappingTrainingDateStopDateRequestSentPage SendStopEmail()
        {
            formCompletionHelper.SelectRadioOptionByLocator(SendStopEmailButton);
            Continue();
            return new ProviderCoEOverlappingTrainingDateStopDateRequestSentPage(context);
        }
    }
}
