using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ThisApprenticeshipTrainingStopPage : BasePage
    {
        protected override string PageTitle => "When did this apprenticeship training stop?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ApprenticeCourseDataHelper _dataHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        private By MonthField => By.Id("DateOfChange_Month");
        private By YearField => By.Id("DateOfChange_Year");
        protected override By ContinueButton => By.CssSelector(".button");
        private By NewStopDate_Month => By.Id("NewStopDate_Month");
        private By NewStopDate_Year => By.Id("NewStopDate_Year");

        public ThisApprenticeshipTrainingStopPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<ApprenticeCourseDataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public StopApprenticeshipPage EditStopDateToThisMonthAndSubmit()
        {
            EnterTheStopDate();
            Continue();
            return new StopApprenticeshipPage(_context);
        }

        public NewStopDateApprenticeDetailsPage EditStopDateToCourseStartDateAndSubmit()
        {
            _formCompletionHelper.EnterText(NewStopDate_Month, _dataHelper.CourseStartDate.Month);
            _formCompletionHelper.EnterText(NewStopDate_Year, _dataHelper.CourseStartDate.Year);
            Continue();
            return new NewStopDateApprenticeDetailsPage(_context);
        }

        private void EnterTheStopDate()
        {
            DateTime stopDate = DateTime.Now;
            _formCompletionHelper.EnterText(MonthField, stopDate.Month);
            _formCompletionHelper.EnterText(YearField, stopDate.Year);
        }
    }
}