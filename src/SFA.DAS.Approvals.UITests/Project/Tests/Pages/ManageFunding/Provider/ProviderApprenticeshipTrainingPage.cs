using OpenQA.Selenium;
using System;
using System.Globalization;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderApprenticeshipTrainingPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Apprenticeship training";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By CourseSearch => By.CssSelector("#course-search, #SelectedCourseId");
        
        public ProviderApprenticeshipTrainingPage(ScenarioContext context) : base(context) => _context = context;

        internal ProviderCheckYourInformationPage AddTrainingCourseAndDate()
        {
            formCompletionHelper.EnterText(CourseSearch, "Software Developer - Level 4");

            var option = pageInteractionHelper.FindElements(RadioLabels).LastOrDefault();

            formCompletionHelper.ClickElement(option);

            SetCourseDate(pageInteractionHelper.GetText(option));

            Continue();

            return new ProviderCheckYourInformationPage(_context);
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
