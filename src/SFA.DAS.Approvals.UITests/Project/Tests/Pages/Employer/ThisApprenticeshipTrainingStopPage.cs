using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ThisApprenticeshipTrainingStopPage : ApprovalsBasePage
    {
        protected override string PageTitle => "When did this apprenticeship training stop?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By MonthField => By.Id("DateOfChange_Month");
        private By YearField => By.Id("DateOfChange_Year");
        protected override By ContinueButton => By.CssSelector("#submit-apply-change");
        private By NewStopDate_Month => By.Id("NewStopDate_Month");
        private By NewStopDate_Year => By.Id("NewStopDate_Year");

        public ThisApprenticeshipTrainingStopPage(ScenarioContext context) : base(context) => _context = context;

        public StopApprenticeshipPage EditStopDateToThisMonthAndSubmit()
        {
            EnterTheStopDate();
            Continue();
            return new StopApprenticeshipPage(_context);
        }

        public NewStopDateApprenticeDetailsPage EditStopDateToCourseStartDateAndSubmit()
        {
            formCompletionHelper.EnterText(NewStopDate_Month, apprenticeCourseDataHelper.CourseStartDate.Month);
            formCompletionHelper.EnterText(NewStopDate_Year, apprenticeCourseDataHelper.CourseStartDate.Year);
            Continue();
            return new NewStopDateApprenticeDetailsPage(_context);
        }

        private void EnterTheStopDate()
        {
            DateTime stopDate = DateTime.Now;
            formCompletionHelper.EnterText(MonthField, stopDate.Month);
            formCompletionHelper.EnterText(YearField, stopDate.Year);
        }
    }
}