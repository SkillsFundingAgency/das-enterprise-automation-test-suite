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

        private By ChangeTypeOptions => By.CssSelector(".selection-button-radio");
        protected override By ContinueButton => By.CssSelector("#submit-change-status");

        public PauseApprenticePage SelectPauseAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(ChangeTypeOptions, "ChangeType-Pause");
            Continue();
            return new PauseApprenticePage(_context);
        }

        public ResumeApprenticePage SelectResumeAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(ChangeTypeOptions, "ChangeType-Resume");
            Continue();
            return new ResumeApprenticePage(_context);
        }

        internal ThisApprenticeshipTrainingStopPage SelectStopAndContinueForAStartedApprentice()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(ChangeTypeOptions, "ChangeType-Stop");
            Continue();
            return new ThisApprenticeshipTrainingStopPage(_context);
        }

        public StopApprenticeshipPage SelectStopAndContinueForANonStartedApprentice()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(ChangeTypeOptions, "ChangeType-Stop");
            Continue();
            return new StopApprenticeshipPage(_context);
        }
    }
}