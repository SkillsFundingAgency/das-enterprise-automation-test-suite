using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ChangeApprenticeStatusPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Which status change would you like to make?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ChangeApprenticeStatusPage(ScenarioContext context) : base(context) => _context = context;
      
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Save and continue')]");

        public PauseApprenticePage SelectPauseAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByText("Pause this apprenticeship");
            Continue();
            return new PauseApprenticePage(_context);
        }

        public ResumeApprenticePage SelectResumeAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByText("Resume this apprenticeship");
            Continue();
            return new ResumeApprenticePage(_context);
        }

        internal ThisApprenticeshipTrainingStopPage SelectStopAndContinueForAStartedApprentice()
        {
            formCompletionHelper.SelectRadioOptionByText("Stop this apprenticeship");
            Continue();
            return new ThisApprenticeshipTrainingStopPage(_context);
        }

        public HasTheApprenticeBeenMadeRedundantPage SelectStopAndContinueForAWaitingToStartApprentice()
        {
            formCompletionHelper.SelectRadioOptionByText("Stop this apprenticeship");
            Continue();
            return new HasTheApprenticeBeenMadeRedundantPage(_context);
        }
    }
}