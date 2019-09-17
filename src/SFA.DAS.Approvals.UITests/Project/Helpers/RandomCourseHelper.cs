using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.Approvals.UITests.Project.Helpers
{
    public abstract class RandomCourseHelper
    {
        protected int RandomNumber { get; private set; }

        public RandomCourseHelper(RandomDataGenerator randomDataGenerator)
        {
            RandomNumber = randomDataGenerator.GenerateRandomNumberBetweenTwoValues(1, 10);
        }

        private string StandardCourseOption => "34";

        private string FrameworkCourseOption => "455-3-1";

        protected string RandomCourse()
        {
            return (RandomNumber % 2 == 0) ? StandardCourseOption : FrameworkCourseOption;
        }

        protected List<string> AvailableCourses()
        {
            return new List<string> { StandardCourseOption, FrameworkCourseOption };
        }
    }
}
