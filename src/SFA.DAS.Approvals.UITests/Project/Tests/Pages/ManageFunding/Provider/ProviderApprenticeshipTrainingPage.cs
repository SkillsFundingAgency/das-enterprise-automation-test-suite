using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderApprenticeshipTrainingPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Apprenticeship training";

        private By CourseSearch => By.CssSelector("#course-search, #SelectedCourseId");

        private By SaveAndContinueButton => By.XPath("//button[contains(text(),'Save and continue')]");

        public ProviderApprenticeshipTrainingPage(ScenarioContext context) : base(context)  { }

        public ProviderApprenticeshipTrainingPage AddTrainingCourse()
        {
            formCompletionHelper.EnterText(CourseSearch, "Software Developer - Level 4");
            return this;
        }

        public ProviderApprenticeshipTrainingPage SelectDate()
        {
            var option = pageInteractionHelper.FindElements(RadioLabels).LastOrDefault();
            formCompletionHelper.ClickElement(option);
            SetCourseDate(pageInteractionHelper.GetText(option));
            return this;
        }

        public ProviderCheckYourInformationPage ClickSaveAndContinueButton()
        {
            formCompletionHelper.ClickElement(SaveAndContinueButton);
            return new ProviderCheckYourInformationPage(context);
        }

        public ProviderApprenticeshipTrainingPage ClickSaveAndContinueButtonAndExpectProblem()
        {
            formCompletionHelper.ClickElement(SaveAndContinueButton);
            return this;
        }

        public void VerifyReserveFromMonth(DateTime? reserveFromMonth)
        {
            if (reserveFromMonth != null)
            {
                var by = By.CssSelector(".govuk-inset-text p:nth-child(2)");
                pageInteractionHelper.VerifyText(by, reserveFromMonth?.ToString("MMMM yyyy"));
            }
        }

        public bool VerifySuggestedStartMonthOptions(DateTime? firstMonth, DateTime? secondMonth, DateTime? thirdMonth)
        {
            var expectedMonths = (new List<string> { firstMonth?.ToString("MMMM yyyy"), secondMonth?.ToString("MMMM yyyy"), thirdMonth?.ToString("MMMM yyyy") }).
                Where(p => !string.IsNullOrWhiteSpace(p));

            var actualMonths = pageInteractionHelper.
                GetAvailableRadioOptions().
                Select(p => p.Trim());

            if (actualMonths.SequenceEqual(expectedMonths))
                return true;

            throw new Exception("Suggested months verification failed: "
                + "\n Expected: '" + string.Join(",", expectedMonths)
                + "\n Found: '" + string.Join(",", actualMonths));
        }

        public void VerifyProblem(string problem)
        {
            var by = By.CssSelector(".govuk-error-summary__list li a[href^='#StartDate-']");
            pageInteractionHelper.VerifyText(by, problem);
        }

        private void SetCourseDate(string startDate)
        {
            string[] desireddate = startDate.Split(" ");
            string[] MonthNames = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
            int startMonth =  Array.IndexOf(MonthNames, desireddate[0]) + 1;
            int startYear = int.Parse(desireddate[1]);
            var courseStartDate = new DateTime(startYear, startMonth, 1);
            apprenticeCourseDataHelper.CourseStartDate = courseStartDate;
        }
    }
}
