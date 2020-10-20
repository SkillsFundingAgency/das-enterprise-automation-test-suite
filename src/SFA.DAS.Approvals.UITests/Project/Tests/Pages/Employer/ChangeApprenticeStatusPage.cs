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
        #endregion


        public ChangeApprenticeStatusPage(ScenarioContext context) : base(context) => _context = context;
      

        private By ChangeTypeOptions => By.CssSelector(".selection-button-radio");
        private By SelectPauseApprentice => By.Id("SelectedStatusChange-Pause");
        private By SelectStopApprentice => By.Id("SelectedStatusChange-Stop");
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Save and continue')]");

        public PauseApprenticePage SelectPauseAndContinue()
        {
            javaScriptHelper.ClickElement(SelectPauseApprentice);
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
            javaScriptHelper.ClickElement(SelectStopApprentice);
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
            javaScriptHelper.ClickElement(SelectStopApprentice);
            Continue();
            return new HasTheApprenticeBeenMadeRedundantPage(_context);
        }
    }
}