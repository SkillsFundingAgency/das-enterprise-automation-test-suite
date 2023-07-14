using System;
using System.Linq;
using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.UnitTests
{
    [TestFixture]
    [Category("Unittests")]
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
            bool IsItJuly() => DateTime.Now.Month == 7;

            //Arrange 
            var apprentice = new ApprenticeCourseDataHelper(GetRandomCourseDataHelper(), ApprenticeStatus.WaitingToStart);

            var nextAcademicYear = IsItJuly() ? AcademicYearDatesHelper.GetNextAcademicYearEndDate(): AcademicYearDatesHelper.GetNextAcademicYearStartDate();

            var courseStartDate = apprentice.CourseStartDate;

            Console.WriteLine($"CourseStartDate : {courseStartDate}, Course {apprentice.CourseLarsCode}");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(courseStartDate, Is.GreaterThan(DateTime.Now.Date), $"Course start date - {courseStartDate} is not greater than today date - {DateTime.Now.Date}");

                if (courseStartDate.Month == DateTime.Now.Month)
                {
                    Assert.IsTrue(courseStartDate.Year != DateTime.Now.Year, 
                        $"if Course start month ({courseStartDate.Month}) == this month ({DateTime.Now.Month}) then Course Start Year ({courseStartDate.Year}) should not be equal to this year ({DateTime.Now.Year})");
                }

                Assert.That(courseStartDate, Is.LessThan(nextAcademicYear), $"Course start date ({courseStartDate}) is not less than {(IsItJuly() ? "NextAcademicYearEndDate" : "NextAcademicYearStartDate")} ({nextAcademicYear})");

                Assert.IsTrue(AvailableCourses.GetAvailableCourses().Any(x => x.Course.larsCode == apprentice.CourseDetails.Course.larsCode),
                    $"lars code {apprentice.CourseDetails.Course.larsCode} is not available from {string.Join(",", AvailableCourses.GetAvailableCourses().Select(x => x.Course.larsCode).ToList())}");
            });
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
            var apprentice = new ApprenticeCourseDataHelper(GetRandomCourseDataHelper(), ApprenticeStatus.Live);

            Console.WriteLine($"CourseStartDate : {apprentice.CourseStartDate}, Course {apprentice.CourseLarsCode}");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.IsTrue(apprentice.CourseStartDate < DateTime.Now.Date && apprentice.CourseStartDate.Date >= new DateTime(2020, 8, 1).Date);

                Assert.IsTrue(AvailableCourses.GetAvailableCourses().Any(x => x.Course.larsCode == apprentice.CourseDetails.Course.larsCode));
            });
        }

        [TestCase(2022, 8, 2, 12, ApprenticeStatus.Live)]
        [TestCase(2023, 8, 2, 12, ApprenticeStatus.WaitingToStart)]
        public void SpecficlarsCode(int year, int month, int day, int durationInMonths, ApprenticeStatus apprenticeStatus)
        {
            //Arrange 
            var startDate = new DateTime(year, month, day);
            var courseDetails = RandomDataGenerator.GetRandomElementFromListOfElements(AvailableCourses.GetAvailableCourses());
            var expectedLarsCode = courseDetails.Course.larsCode;
            var apprentice = new ApprenticeCourseDataHelper(GetRandomCourseDataHelper(), startDate, durationInMonths, expectedLarsCode);
            

            Console.WriteLine($"CourseStartDate : {apprentice.CourseStartDate}, Course {apprentice.CourseLarsCode}");

            //Assert
            Assert.Multiple(() => 
            {
                Assert.IsTrue(apprentice.CourseStartDate == startDate);
                Assert.IsTrue(apprentice.CourseDetails.Course.larsCode == expectedLarsCode);
                Assert.IsTrue(apprentice.CourseDurationInMonths == durationInMonths);
                Assert.IsTrue(apprentice.CourseEndDate == apprentice.CourseStartDate.AddMonths(durationInMonths));
                Assert.IsTrue(apprentice.GetApprenticeStatus() == apprenticeStatus);
            });
        }

        private RandomCourseDataHelper GetRandomCourseDataHelper() => new RandomCourseDataHelper();
    }
}
