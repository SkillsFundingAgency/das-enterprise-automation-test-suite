using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Globalization;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderApprenticeshipTrainingPage : BasePage
    {
        protected override string PageTitle => "Apprenticeship training";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprenticeCourseDataHelper _apprenticeCourseDataHelper;
        #endregion

        private By CourseSearch => By.CssSelector("#course-search, #SelectedCourseId");
        
        public ProviderApprenticeshipTrainingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _apprenticeCourseDataHelper = context.Get<ApprenticeCourseDataHelper>();
        }

        internal ProviderCheckYourInformationPage AddTrainingCourseAndDate()
        {
            _formCompletionHelper.EnterText(CourseSearch, "Software Developer - Level 4");

            var option = _pageInteractionHelper.FindElements(RadioLabels).LastOrDefault();

            _formCompletionHelper.ClickElement(option);

            SetCourseDate(_pageInteractionHelper.GetText(option));

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
            _apprenticeCourseDataHelper.CourseStartDate = courseStartDate;
        }
    }
}
