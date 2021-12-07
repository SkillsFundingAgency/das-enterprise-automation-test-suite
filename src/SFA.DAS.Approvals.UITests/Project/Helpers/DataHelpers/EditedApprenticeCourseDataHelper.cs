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

            EditedCourse = _randomCourseHelper.RandomCourse(_apprenticeCourseDataHelper.Course).Course.larsCode;
        }

        public string EditedCourse { get; private set; }

        public void SelectAnyStandardCourse(string selectedCourseName)
        {
            var availableCourses = new List<string> { "Abattoir worker, Level: 2", "Able seafarer (deck), Level: 2", "Software tester, Level: 4" };

            availableCourses = availableCourses.Where(x => !x.ContainsCompareCaseInsensitive(selectedCourseName) && x.Contains("Level")).ToList();

            EditedCourse = RandomDataGenerator.GetRandomElementFromListOfElements(availableCourses);
        }
    }
}
