using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ChangeApprenticeStatusPage : BasePage
    {
        protected override string PageTitle => "Which status change would you like to make?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion


        public ChangeApprenticeStatusPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        private By ChangeTypeOptions => By.CssSelector(".selection-button-radio");
        protected override By ContinueButton => By.CssSelector("#submit-change-status");

        public PauseApprenticePage SelectPauseAndContinue()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ChangeTypeOptions, "ChangeType-Pause");
            Continue();
            return new PauseApprenticePage(_context);
        }

        public ResumeApprenticePage SelectResumeAndContinue()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ChangeTypeOptions, "ChangeType-Resume");
            Continue();
            return new ResumeApprenticePage(_context);
        }

        internal ThisApprenticeshipTrainingStopPage SelectStopAndContinueForAStartedApprentice()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ChangeTypeOptions, "ChangeType-Stop");
            Continue();
            return new ThisApprenticeshipTrainingStopPage(_context);
        }

        public StopApprenticeshipPage SelectStopAndContinueForANonStartedApprentice()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ChangeTypeOptions, "ChangeType-Stop");
            Continue();
            return new StopApprenticeshipPage(_context);
        }
    }
}