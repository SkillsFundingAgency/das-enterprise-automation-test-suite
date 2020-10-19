using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ChangeApprenticeStatusPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Which status change would you like to make?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly JavaScriptHelper _javaScriptHelper;
        #endregion


        public ChangeApprenticeStatusPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _javaScriptHelper = _context.Get<JavaScriptHelper>();
        }

        private By ChangeTypeOptions => By.CssSelector(".selection-button-radio");
        private By ChangeTypeOptions1 => By.CssSelector(".govuk-radios__item");
        private By SelectPauseApprentice => By.Id("SelectedStatusChange-Pause");
        private By SelectStopApprentice => By.Id("SelectedStatusChange-Stop");
        protected override By ContinueButton => By.Id("continue-button");

        public PauseApprenticePage SelectPauseAndContinue()
        {
            _javaScriptHelper.ClickElement(SelectPauseApprentice);
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
        public HasTheApprenticeBeenMadeRedundantPage SelectStopAndContinueForAWaitingToStartApprentice()
        {
            _javaScriptHelper.ClickElement(SelectStopApprentice);
            Continue();
            return new HasTheApprenticeBeenMadeRedundantPage(_context);
        }
    }
}