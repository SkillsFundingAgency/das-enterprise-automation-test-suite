using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.Approvals.UITests.Project.Helpers
{
    public class RandomCourseHelper
    {
        public int RandomNumber { get; private set; }

        public List<string> AvailableCourses;

        public RandomCourseHelper(RandomDataGenerator randomDataGenerator, bool isTransfersFunds)
        {
            AvailableCourses = isTransfersFunds ? TransferFundsCourses() : AllCourses();
            RandomNumber = randomDataGenerator.GenerateRandomNumberBetweenTwoValues(1, 10);
        }

        private string AbleSeafarerStandardCourseOption => "34";

        private string SoftwareTesterStandardCourseOption => "91";

        private string FrameworkCourseOption => "455-3-1";

        public string RandomCourse()
        {
            return (RandomNumber % 2 == 0) ? AvailableCourses[0] : AvailableCourses[1];
        }

        private List<string> AllCourses() => new List<string> { AbleSeafarerStandardCourseOption, FrameworkCourseOption };

        private List<string> TransferFundsCourses() => new List<string> { AbleSeafarerStandardCourseOption, SoftwareTesterStandardCourseOption };
    }
}
