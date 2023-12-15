using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderOverlappingTrainingDateThereMayBeProblemPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        protected override string PageTitle => "There may be a problem with the proposed training details";

        protected override bool TakeFullScreenShot => false;

        private static By SelectYesCheckBox => By.CssSelector("#checkbox-acknowledgement");

        public ProviderOverlappingTrainingDateExistingApprenticeshipRecordPage SelectYesTheseDetailsAreCorrect()
        {
            formCompletionHelper.SelectCheckbox(SelectYesCheckBox);
            Continue();
            return new ProviderOverlappingTrainingDateExistingApprenticeshipRecordPage(context);
        }
    }
}
