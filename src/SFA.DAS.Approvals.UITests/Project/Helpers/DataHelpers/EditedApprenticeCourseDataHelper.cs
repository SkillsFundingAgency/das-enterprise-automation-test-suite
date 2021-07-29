using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public class EditedApprenticeCourseDataHelper
    {
        private readonly ApprenticeCourseDataHelper _apprenticeCourseDataHelper;
        private readonly RandomCourseDataHelper _randomCourseHelper;

        public EditedApprenticeCourseDataHelper(RandomCourseDataHelper randomCourseHelper, ApprenticeCourseDataHelper apprenticeCourseDataHelper)
        {
            _randomCourseHelper = randomCourseHelper;

            _apprenticeCourseDataHelper = apprenticeCourseDataHelper;

            EditedCourse = _randomCourseHelper.AvailableCourses.Where(x => x != _apprenticeCourseDataHelper.Course).FirstOrDefault();
        }

        public string EditedCourse { get; private set; }

        public void SelectAnyStandardCourse(string selectedCourseName)
        {
            var availableCourses = new List<string> { "Abattoir worker, Level: 2 (Standard)", "Able seafarer (deck), Level: 2 (Standard)", "Software tester, Level: 4 (Standard)" };

            availableCourses = availableCourses.Where(x => !x.ContainsCompareCaseInsensitive(selectedCourseName) && x.Contains("(Standard)")).ToList();

            var randomNumber = _randomCourseHelper.GetRandomNumber(0, availableCourses.Count);

            EditedCourse = availableCourses.ElementAt(randomNumber);
        }
    }
}
