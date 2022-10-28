using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderOverlappingTrainingDateThereMayBeProblemPage : ApprovalsBasePage
    {
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        protected override string PageTitle => "";

        protected override bool TakeFullScreenShot => false;

        public ProviderOverlappingTrainingDateThereMayBeProblemPage(ScenarioContext context) : base(context) { }

        private static By SelectYesCheckBox => By.CssSelector("#checkbox-acknowledgement");

        public void SelectYesTheseDetailsAreCorrect()
        {
            formCompletionHelper.SelectCheckbox(SelectYesCheckBox);
            Continue();
        }
    }
}
