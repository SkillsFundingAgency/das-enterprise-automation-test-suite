using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
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

        public ConfirmApprenticeshipStopPage SelectStopAndContinueForANonStartedApprentice()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ChangeTypeOptions, "ChangeType-Stop");
            _formCompletionHelper.ClickElement(ContinueButton);
            return new ConfirmApprenticeshipStopPage(_context);
        }
    }

    internal class ThisApprenticeshipTrainingStopPage : BasePage
    {
        protected override string PageTitle => "When did this apprenticeship training stop?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ApprenticeCourseDataHelper _dataHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By MonthField => By.Id("DateOfChange_Month");
        private By YearField => By.Id("DateOfChange_Year");
        private By ContinueButton => By.CssSelector(".button");
        private By NewStopDate_Month => By.Id("NewStopDate_Month");
        private By NewStopDate_Year => By.Id("NewStopDate_Year");

        public ThisApprenticeshipTrainingStopPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<ApprenticeCourseDataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public ConfirmApprenticeshipStopPage ChooseRandomStopMonthAndSubmit()
        {
            EnterTheStopDate();
            _formCompletionHelper.ClickElement(ContinueButton);
            return new ConfirmApprenticeshipStopPage(_context);
        }

        public ApprenticeDetailsPage EditStopDateAndSubmit()
        {
            _formCompletionHelper.EnterText(NewStopDate_Month, _dataHelper.CourseStartDate.Month);
            _formCompletionHelper.EnterText(NewStopDate_Year, _dataHelper.CourseStartDate.Year);
            _formCompletionHelper.ClickElement(ContinueButton);
            return new ApprenticeDetailsPage(_context);
        }

        private void EnterTheStopDate()
        {
            DateTime stopDate = DateTime.Now;
            _formCompletionHelper.EnterText(MonthField, stopDate.Month);
            _formCompletionHelper.EnterText(YearField, stopDate.Year);
        }
    }
}