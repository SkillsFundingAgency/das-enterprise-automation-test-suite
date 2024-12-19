using System;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public enum ApprenticeStatus
    {
        Live,
        OneMonthBeforeCurrentAcademicYearStartDate,
        CurrentAcademicYearStartDate,
        WaitingToStart,
        StartDateIsFewMonthsBeforeNow,
        StartedInCurrentMonth,
        Random
    }

    public class ApprenticeCourseDataHelper
    {
        private readonly DateTime _currentAcademicYearStartDate;
        private readonly DateTime _currentAcademicYearEndDate;
        private readonly DateTime _nextAcademicYearStartDate;
        private readonly ApprenticeStatus _apprenticeStatus;

        public ApprenticeCourseDataHelper(RandomCourseDataHelper randomCourseHelper, ApprenticeStatus apprenticeStatus, string[] tags)
            : this(apprenticeStatus) => SetCourseDetails(randomCourseHelper, GenerateCourseStartDate(), default, string.Empty, tags);

        public ApprenticeCourseDataHelper(RandomCourseDataHelper randomCourseHelper, DateTime courseStartDate, int durationInMonths, string larsCode)
            : this(courseStartDate > DateTime.Now ? ApprenticeStatus.WaitingToStart : ApprenticeStatus.Live) => SetCourseDetails(randomCourseHelper, courseStartDate, durationInMonths, larsCode, default);

        private ApprenticeCourseDataHelper(ApprenticeStatus apprenticeStatus)
        {
            _apprenticeStatus = apprenticeStatus;
            _currentAcademicYearStartDate = AcademicYearDatesHelper.GetCurrentAcademicYearStartDate();
            _currentAcademicYearEndDate = AcademicYearDatesHelper.GetCurrentAcademicYearEndDate();
            _nextAcademicYearStartDate = AcademicYearDatesHelper.GetNextAcademicYearStartDate();
        }

        private void SetCourseDetails(RandomCourseDataHelper randomCourseHelper, DateTime courseStartDate, int durationInMonths, string larsCode, string[] tags)
        {
            CourseDetails = string.IsNullOrEmpty(larsCode) ? randomCourseHelper.RandomCourse() : randomCourseHelper.SelectASpecificCourse(larsCode);

            CourseStartDate = courseStartDate;

            if (tags.IsSelectStandardWithMultipleOptionsAndVersions())
            {
                var courseEarliestStartDate = CourseDetails.Course.versionEarliestStartDate;
                CourseStartDate = new DateTime(courseEarliestStartDate.Year, courseEarliestStartDate.Month, 1).AddMonths(-1);
            }

            CourseDurationInMonths = durationInMonths == default ? CourseDetails.Course.proposedTypicalDuration : durationInMonths;
            CourseLarsCode = CourseDetails.Course.larsCode;
            OtherCourseDetails = randomCourseHelper.RandomCourse(CourseLarsCode);
            OtherCourseLarsCode = OtherCourseDetails.Course.larsCode;
        }

        internal ApprenticeStatus GetApprenticeStatus() => _apprenticeStatus;

        public CourseDetails CourseDetails { get; private set; }

        public CourseDetails OtherCourseDetails { get; private set; }

        public string CourseLarsCode { get; private set; }

        public string OtherCourseLarsCode { get; private set; }

        public int CourseDurationInMonths { get; private set; }

        public DateTime CourseStartDate { get; internal set; }

        public DateTime CourseEndDate => CourseStartDate.AddMonths(CourseDurationInMonths);

        public DateTime GenerateCourseStartDate(ApprenticeStatus apprenticeStatus)
        {
            DateTime start = _currentAcademicYearStartDate;
            DateTime end = RandomDataGenerator.GenerateRandomNumberBetweenTwoValues(1, 10) % 2 == 0 ? _currentAcademicYearEndDate : DateTime.Now;
            int range = (end - start).Days;
            var randomStartDate = start.AddDays(new Random().Next(range));
            return apprenticeStatus == ApprenticeStatus.Live ? GetLiveApprenticeStartDate(randomStartDate) :
                   apprenticeStatus == ApprenticeStatus.OneMonthBeforeCurrentAcademicYearStartDate ? GetOneMonthBeforeCurrentAcademicYearStartDate(randomStartDate) :
                   apprenticeStatus == ApprenticeStatus.CurrentAcademicYearStartDate ? _currentAcademicYearStartDate :
                   apprenticeStatus == ApprenticeStatus.WaitingToStart ? GetWaitingToStartApprenticeStartDate(randomStartDate) :
                   apprenticeStatus == ApprenticeStatus.StartedInCurrentMonth ? DateTime.Now :
                   apprenticeStatus == ApprenticeStatus.StartDateIsFewMonthsBeforeNow ? GetStartDateFewMonthsBeforeNow() : randomStartDate;
                    
        }

        private DateTime GenerateCourseStartDate() => GenerateCourseStartDate(_apprenticeStatus);

        private DateTime GetLiveApprenticeStartDate(DateTime dateTime) => dateTime.Date >= DateTime.Now.Date ? _currentAcademicYearStartDate : dateTime;

        private DateTime GetOneMonthBeforeCurrentAcademicYearStartDate(DateTime dateTime) => dateTime.Date >= DateTime.Now.Date ? _currentAcademicYearStartDate.AddMonths(-1) : dateTime;

        private DateTime GetWaitingToStartApprenticeStartDate(DateTime dateTime)
        {
            var now = DateTime.Now;
            DateTime RandomStartDate()
            {
                var start = now.AddMonths(1);
                int range = (_nextAcademicYearStartDate - start).Days;
                range = (range > 0) ? range - 1 : 0;
                return start.AddDays(new Random().Next(range));
            }

            return dateTime.Date <= now.Date ? RandomStartDate() : IsThisMonthAndYear(dateTime) ? RandomStartDate() : dateTime;
        }

        private static DateTime GetStartDateFewMonthsBeforeNow() => DateTime.Now.AddMonths(-1).AddDays(new Random().Next(-210, -1));

        private static bool IsThisMonthAndYear(DateTime dateTime) => dateTime.Month == DateTime.Now.Month && dateTime.Year == DateTime.Now.Year;
    }
}