using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ApprenticeCommitmentsEditApprenticePage : EditApprenticePage
    {
        private readonly string selectedCourse;

        public ApprenticeCommitmentsEditApprenticePage(ScenarioContext context, string selectedCourse) : base(context) => this.selectedCourse = selectedCourse;
        
        protected override void SelectCourse() => formCompletionHelper.SelectFromDropDownByText(CourseOption, GetAnyStandardCourse(selectedCourse));

        private string GetAnyStandardCourse(string selectedCourseName)
        {
            var availableCourses = new List<string> { "Abattoir worker, Level: 2", "Actuary, Level: 7", "Software tester, Level: 4" };

            availableCourses = availableCourses.Where(x => !x.ContainsCompareCaseInsensitive(selectedCourseName) && x.Contains("Level")).ToList();

            return RandomDataGenerator.GetRandomElementFromListOfElements(availableCourses);
        }
    }
}