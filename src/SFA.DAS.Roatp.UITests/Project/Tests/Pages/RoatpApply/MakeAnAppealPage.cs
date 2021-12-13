using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class MakeAnAppealPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Make an appeal";

        private By AppealOnPolicyOrProcessesRadio => By.Id("AppealOnPolicyOrProcesses");
        private By AppealOnEvidenceSubmittedRadio => By.Id("AppealOnEvidenceSubmitted");

        public MakeAnAppealPage(ScenarioContext context) : base(context) => VerifyPage();

        public GroundForAppealPage SelectAppealOnAppealOnEvidenceSubmittedAndAppealOnPolicyOrProcesses ()
        {
            formCompletionHelper.SelectCheckbox(AppealOnPolicyOrProcessesRadio);
            formCompletionHelper.SelectCheckbox(AppealOnEvidenceSubmittedRadio);
            Continue();
            return new GroundForAppealPage(context);
        }

    }
}
