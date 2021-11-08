using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class GroundForAppealPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Tell us about the grounds for your appeal";

        private By AppealOnPolicyOrProcessesTextBox = By.Id("HowFailedOnPolicyOrProcesses");
        private By AppealOnEvidenceSubmittedTextBox = By.Id("HowFailedOnEvidenceSubmitted");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public GroundForAppealPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AppealSubmittedPage EnterText_UploadFileForAppealOnEvidenceSubmittedAndAppealOnPolicyOrProcesses()
        {
            formCompletionHelper.EnterText(AppealOnPolicyOrProcessesTextBox, "Appeal on policy test");
            formCompletionHelper.EnterText(AppealOnEvidenceSubmittedTextBox, "Appeal on evidence test");
            UploadFile();
            formCompletionHelper.ClickButtonByText(ContinueButton, "Submit your appeal");
            return new AppealSubmittedPage(_context);
        }

    }
}
