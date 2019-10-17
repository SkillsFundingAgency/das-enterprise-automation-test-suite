using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
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
        private readonly ApprenticeDataHelper _dataHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion


        public ChangeApprenticeStatusPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        private By ChangeTypeOptions => By.CssSelector(".selection-button-radio");
        private By ContinueButton => By.CssSelector(".button");

        public PauseApprenticePage SelectPauseAndContinue()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ChangeTypeOptions, "ChangeType-Pause");
            _formCompletionHelper.ClickElement(ContinueButton);
            return new PauseApprenticePage(_context);
        }

        public ResumeApprenticePage SelectResumeAndContinue()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ChangeTypeOptions, "ChangeType-Resume");
            _formCompletionHelper.ClickElement(ContinueButton);
            return new ResumeApprenticePage(_context);
        }

        internal ThisApprenticeshipTrainingStopPage SelectStopAndContinueForAStartedApprentice()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ChangeTypeOptions, "ChangeType-Stop");
            _formCompletionHelper.ClickElement(ContinueButton);
            return new ThisApprenticeshipTrainingStopPage(_context);
        }

        public StopApprenticeshipPage SelectStopAndContinueForANonStartedApprentice()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ChangeTypeOptions, "ChangeType-Stop");
            _formCompletionHelper.ClickElement(ContinueButton);
            return new StopApprenticeshipPage(_context);
        }
    }
}