using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ThisApprenticeshipTrainingStopPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "When did this apprenticeship training stop?";

        protected override bool TakeFullScreenShot => false;

        private static By MonthField => By.Id("stop-month");
        private static By YearField => By.Id("stop-year");
        protected override By ContinueButton => By.Id("continue-button");
        private static By NewStopDate_Month => By.Id("stop-month");
        private static By NewStopDate_Year => By.Id("stop-year");

        public HasTheApprenticeBeenMadeRedundantPage EditStopDateToThisMonthAndSubmit()
        {
            EnterTheStopDate();
            Continue();
            return new HasTheApprenticeBeenMadeRedundantPage(context);
        }

        public ApprenticeDetailsPage EditStopDateToCourseStartDateAndSubmit()
        {
            formCompletionHelper.EnterText(NewStopDate_Month, apprenticeCourseDataHelper.CourseStartDate.Month);
            formCompletionHelper.EnterText(NewStopDate_Year, apprenticeCourseDataHelper.CourseStartDate.Year);
            formCompletionHelper.Click(ContinueButton);
            return new ApprenticeDetailsPage(context);
        }

        public ApprenticeDetailsPage EditStopDateToCourseStartDateAndSubmit(string month, string year)
        {
            formCompletionHelper.EnterText(NewStopDate_Month, month);
            formCompletionHelper.EnterText(NewStopDate_Year, year);
            formCompletionHelper.Click(ContinueButton);
            return new ApprenticeDetailsPage(context);
        }

        private void EnterTheStopDate()
        {
            DateTime stopDate = DateTime.Now;
            formCompletionHelper.EnterText(MonthField, stopDate.Month);
            formCompletionHelper.EnterText(YearField, stopDate.Year);
        }
    }
}