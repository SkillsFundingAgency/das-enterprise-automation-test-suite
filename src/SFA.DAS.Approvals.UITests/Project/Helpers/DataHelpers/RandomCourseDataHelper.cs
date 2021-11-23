using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public class RandomCourseDataHelper
    {
        public int RandomNumber { get; private set; }

        public List<string> AvailableCourses;

        public RandomCourseDataHelper()
        {
            AvailableCourses = new List<string> { AbleSeafarerStandardCourseOption, SoftwareTesterStandardCourseOption };

            RandomNumber = RandomDataGenerator.GenerateRandomNumberBetweenTwoValues(1, 10);
        }

        public string RandomCourse() => RandomNumber % 2 == 0 ? AvailableCourses[0] : AvailableCourses[1];

        public string OtherCourse(string selectedCourse) => SelectACourse(AvailableCourses, selectedCourse);

        private string SelectACourse(List<string> list, string except)
        {
            var newlist = list.Where(x => x != except).ToList();

            var randomNumber = RandomDataGenerator.GenerateRandomNumberBetweenTwoValues(1, newlist.Count);

            return newlist[randomNumber - 1];
        }

        private string AbleSeafarerStandardCourseOption => "34";

        private string SoftwareTesterStandardCourseOption => "91";
    }
}
