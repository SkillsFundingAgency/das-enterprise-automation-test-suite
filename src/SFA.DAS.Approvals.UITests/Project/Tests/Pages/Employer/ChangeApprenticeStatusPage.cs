using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ChangeApprenticeStatusPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Which status change would you like to make?";

        protected override bool TakeFullScreenShot => false;

        public ChangeApprenticeStatusPage(ScenarioContext context) : base(context)  { }
      
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Save and continue')]");

        public PauseApprenticePage SelectPauseAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByText("Pause this apprenticeship");
            Continue();
            return new PauseApprenticePage(context);
        }

        public ResumeApprenticePage SelectResumeAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByText("Resume this apprenticeship");
            Continue();
            return new ResumeApprenticePage(context);
        }

        internal ThisApprenticeshipTrainingStopPage SelectStopAndContinueForAStartedApprentice()
        {
            formCompletionHelper.SelectRadioOptionByText("Stop this apprenticeship");
            Continue();
            return new ThisApprenticeshipTrainingStopPage(context);
        }

        public HasTheApprenticeBeenMadeRedundantPage SelectStopAndContinueForAWaitingToStartApprentice()
        {
            formCompletionHelper.SelectRadioOptionByText("Stop this apprenticeship");
            Continue();
            return new HasTheApprenticeBeenMadeRedundantPage(context);
        }
    }
}