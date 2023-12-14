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
        public void WaitingTostartApprentice(int _)
        {
            static bool IsItJuly() => DateTime.Now.Month == 7;

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
        public void LiveApprentice(int _)
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
        public void StartDateIsFewMonthsBeforeNow(int _)
        {
            //Arrange 
            var apprentice = new ApprenticeCourseDataHelper(GetRandomCourseDataHelper(), ApprenticeStatus.StartDateIsFewMonthsBeforeNow);

            Console.WriteLine($"CourseStartDate : {apprentice.CourseStartDate}, Course {apprentice.CourseLarsCode}");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.IsTrue(apprentice.CourseStartDate < DateTime.Now.Date.AddMonths(-1) && apprentice.CourseStartDate.Date >= DateTime.Now.Date.AddMonths(-1).AddDays(-210));

                Assert.IsTrue(AvailableCourses.GetAvailableCourses().Any(x => x.Course.larsCode == apprentice.CourseDetails.Course.larsCode));
            });
        }

        [TestCase(ApprenticeStatus.Live)]
        [TestCase(ApprenticeStatus.WaitingToStart)]
        public void SpecficlarsCode(ApprenticeStatus apprenticeStatus)
        {
            //Arrange 
            int durationInMonths = 12;
            var startDate = new DateTime(apprenticeStatus == ApprenticeStatus.Live ? DateTime.Now.Year : DateTime.Now.Year + 1, 8, 2);
            var courseDetails = RandomDataGenerator.GetRandomElementFromListOfElements(AvailableCourses.GetAvailableCourses());
            var expectedLarsCode = courseDetails.Course.larsCode;
            var apprentice = new ApprenticeCourseDataHelper(GetRandomCourseDataHelper(), startDate, durationInMonths, expectedLarsCode);
            

            Console.WriteLine($"CourseStartDate : {apprentice.CourseStartDate}, Course {apprentice.CourseLarsCode}");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(apprentice.CourseStartDate, Is.EqualTo(startDate), "Apprentice course start date is not equal");
                Assert.That(apprentice.CourseDetails.Course.larsCode, Is.EqualTo(expectedLarsCode), "Apprentice course lars code is not equal");
                Assert.That(apprentice.CourseDurationInMonths, Is.EqualTo(durationInMonths), "Apprentice course suration month is not equal");
                Assert.That(apprentice.CourseEndDate, Is.EqualTo(apprentice.CourseStartDate.AddMonths(durationInMonths)), "Apprentice course end date is not equal");
                Assert.That(apprentice.GetApprenticeStatus(), Is.EqualTo(apprenticeStatus), "Apprentice status is not equal");
            });
        }

        private static RandomCourseDataHelper GetRandomCourseDataHelper() => new();
    }
}
