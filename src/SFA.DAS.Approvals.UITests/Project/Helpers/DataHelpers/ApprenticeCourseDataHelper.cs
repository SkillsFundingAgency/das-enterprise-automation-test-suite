using SFA.DAS.FrameworkHelpers;
using System;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public enum ApprenticeStatus
    {
        Live,
        OneMonthBeforeCurrentAcademicYearStartDate,
        CurrentAcademicYearStartDate,
        WaitingToStart,
        Random
    }

    public class ApprenticeCourseDataHelper
    {
        private readonly DateTime _currentAcademicYearStartDate;
        private readonly DateTime _currentAcademicYearEndDate;
        private readonly DateTime _nextAcademicYearStartDate;
        private readonly DateTime _nextAcademicYearEndDate;
        private readonly ApprenticeStatus _apprenticeStatus;

        public ApprenticeCourseDataHelper(RandomCourseDataHelper randomCourseHelper, ApprenticeStatus apprenticeStatus) 
            : this(apprenticeStatus) => SetCourseDetails(randomCourseHelper, GenerateCourseStartDate(), default, string.Empty);

        public ApprenticeCourseDataHelper(RandomCourseDataHelper randomCourseHelper, DateTime courseStartDate, int durationInMonths , string larsCode) 
            : this(courseStartDate > DateTime.Now ? ApprenticeStatus.WaitingToStart : ApprenticeStatus.Live) => SetCourseDetails(randomCourseHelper, courseStartDate, durationInMonths, larsCode);

        private ApprenticeCourseDataHelper(ApprenticeStatus apprenticeStatus)
        {
            _apprenticeStatus = apprenticeStatus;
            _currentAcademicYearStartDate = AcademicYearDatesHelper.GetCurrentAcademicYearStartDate();
            _currentAcademicYearEndDate = AcademicYearDatesHelper.GetCurrentAcademicYearEndDate();
            _nextAcademicYearStartDate = AcademicYearDatesHelper.GetNextAcademicYearStartDate();
            _nextAcademicYearEndDate = AcademicYearDatesHelper.GetNextAcademicYearEndDate();
        }

        private void SetCourseDetails(RandomCourseDataHelper randomCourseHelper, DateTime courseStartDate, int durationInMonths, string larsCode)
        {
            CourseDetails = string.IsNullOrEmpty(larsCode) ? randomCourseHelper.RandomCourse() : randomCourseHelper.SelectASpecificCourse(larsCode);

            CourseStartDate = courseStartDate;
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
                   apprenticeStatus == ApprenticeStatus.WaitingToStart ? GetWaitingToStartApprenticeStartDate(randomStartDate) : randomStartDate;
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

        private bool IsThisMonthAndYear(DateTime dateTime) => dateTime.Month == DateTime.Now.Month && dateTime.Year == DateTime.Now.Year;
    }
}