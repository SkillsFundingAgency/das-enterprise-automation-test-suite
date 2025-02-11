using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class GroundForAppealPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Tell us about the grounds for your appeal";

        private static By AppealOnPolicyOrProcessesTextBox => By.Id("HowFailedOnPolicyOrProcesses");
        private static By AppealOnEvidenceSubmittedTextBox => By.Id("HowFailedOnEvidenceSubmitted");

        public GroundForAppealPage(ScenarioContext context) : base(context) => VerifyPage();

        public AppealSubmittedPage EnterText_UploadFileForAppealOnEvidenceSubmittedAndAppealOnPolicyOrProcesses()
        {
            formCompletionHelper.EnterText(AppealOnPolicyOrProcessesTextBox, "Appeal on policy test");
            formCompletionHelper.EnterText(AppealOnEvidenceSubmittedTextBox, "Appeal on evidence test");
            UploadFile();
            formCompletionHelper.ClickButtonByText(ContinueButton, "Submit your appeal");
            return new AppealSubmittedPage(context);
        }

    }
}
