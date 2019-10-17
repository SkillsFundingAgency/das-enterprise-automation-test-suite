using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

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
            var randomcourseHelper = new RandomCourseHelper(new UI.FrameworkHelpers.RandomDataGenerator(), false);
            var apprentice = new ApprenticeCourseDataHelper(randomcourseHelper, ApprenticeStatus.WaitingToStart);

            //Assert
            Assert.IsTrue(apprentice.CourseStartDate > DateTime.Now.Date && (apprentice.CourseStartDate.Month != DateTime.Now.Month ? true : apprentice.CourseStartDate.Year != DateTime.Now.Year) && apprentice.CourseStartDate < new DateTime(2020, 7, 31));

            Console.WriteLine($"CourseStartDate : {apprentice.CourseStartDate}, Course {apprentice.Course}");
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
            var randomcourseHelper = new RandomCourseHelper(new UI.FrameworkHelpers.RandomDataGenerator(), false);
            var apprentice = new ApprenticeCourseDataHelper(randomcourseHelper, ApprenticeStatus.Live);

            //Assert
            Assert.IsTrue(apprentice.CourseStartDate < DateTime.Now.Date);

            Console.WriteLine($"CourseStartDate : {apprentice.CourseStartDate}, Course {apprentice.Course}");
        }
    }
}
