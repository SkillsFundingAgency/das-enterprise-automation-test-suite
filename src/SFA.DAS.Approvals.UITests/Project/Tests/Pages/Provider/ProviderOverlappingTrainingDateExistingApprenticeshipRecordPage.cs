using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderOverlappingTrainingDateExistingApprenticeshipRecordPage : ApprovalsBasePage
    {
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        protected override string PageTitle => "This apprentice already has an existing apprenticeship record";

        protected override bool TakeFullScreenShot => false;

        public ProviderOverlappingTrainingDateExistingApprenticeshipRecordPage(ScenarioContext context) : base(context) { }

        private static By IWillAddLaterRadionButton => By.CssSelector("#overlap-option-3");

        private static By ContactTheEmployerThemselves => By.CssSelector("#overlap-option-2");

        private static By SendStopEmailButton => By.CssSelector("#overlap-option-1");

        public void SelectIWillAddApprenticesLater()
        {
            formCompletionHelper.SelectRadioOptionByLocator(IWillAddLaterRadionButton);
            Continue();
        }

        public void SelectContactTheEmployerThemselves()
        {
            formCompletionHelper.SelectRadioOptionByLocator(ContactTheEmployerThemselves);
            Continue();
        }

        public void SendStopEmail()
        {
            formCompletionHelper.SelectRadioOptionByLocator(SendStopEmailButton);
            Continue();
        }
    }
}
