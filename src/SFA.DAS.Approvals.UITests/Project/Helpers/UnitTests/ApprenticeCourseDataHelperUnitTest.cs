using System;
using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.UnitTests
{
    [TestFixture]
    public class ApprenticeCourseDataHelperUnitTest
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        [TestCase(16)]
        [TestCase(17)]
        [TestCase(18)]
        [TestCase(19)]
        public void WaitingTostartApprentice(int i)
        {
            //Arrange 
            var randomcourseHelper = new RandomCourseDataHelper(new UI.FrameworkHelpers.RandomDataGenerator(), false);
            var apprentice = new ApprenticeCourseDataHelper(randomcourseHelper, ApprenticeStatus.WaitingToStart);

            Console.WriteLine($"CourseStartDate : {apprentice.CourseStartDate}, Course {apprentice.Course}");

            //Assert
            Assert.IsTrue(apprentice.CourseStartDate > DateTime.Now.Date && (apprentice.CourseStartDate.Month != DateTime.Now.Month ? true : apprentice.CourseStartDate.Year != DateTime.Now.Year) && apprentice.CourseStartDate < new DateTime(2021, 7, 31));
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        [TestCase(16)]
        [TestCase(17)]
        [TestCase(18)]
        [TestCase(19)]
        public void LiveApprentice(int x)
        {
            //Arrange 
            var randomcourseHelper = new RandomCourseDataHelper(new UI.FrameworkHelpers.RandomDataGenerator(), false);
            var apprentice = new ApprenticeCourseDataHelper(randomcourseHelper, ApprenticeStatus.Live);

            Console.WriteLine($"CourseStartDate : {apprentice.CourseStartDate}, Course {apprentice.Course}");

            //Assert
            Assert.IsTrue(apprentice.CourseStartDate < DateTime.Now.Date && apprentice.CourseStartDate.Date >= new DateTime(2020, 8, 1).Date);
        }
    }
}
