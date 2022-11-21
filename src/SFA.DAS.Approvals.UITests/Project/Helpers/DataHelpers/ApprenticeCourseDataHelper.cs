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
        {
            _apprenticeStatus = apprenticeStatus;
            _currentAcademicYearStartDate = AcademicYearDatesHelper.GetCurrentAcademicYearStartDate();
            _currentAcademicYearEndDate = AcademicYearDatesHelper.GetAcademicYearEndDate();
            _nextAcademicYearStartDate = AcademicYearDatesHelper.GetNextAcademicYearStartDate();
            _nextAcademicYearEndDate = AcademicYearDatesHelper.GetAcademicYearEndDate(_nextAcademicYearStartDate);
            CourseStartDate = GenerateCourseStartDate();
            CourseDetails = randomCourseHelper.RandomCourse();
            CourseLarsCode = CourseDetails.Course.larsCode;
            OtherCourseDetails = randomCourseHelper.RandomCourse(CourseLarsCode);
            OtherCourseLarsCode = OtherCourseDetails.Course.larsCode;
            PortableFlexiJobCourseDetails = randomCourseHelper.GetPortableFlexiJobCourseDetails();
            CourseEndDate = CourseStartDate.AddMonths(CourseDurationInMonths);
        }

        public ApprenticeCourseDataHelper(RandomCourseDataHelper randomCourseHelper, ApprenticeStatus apprenticeStatus, DateTime courseStartDate, DateTime courseEndDate, string larsCode)
        {
            _apprenticeStatus = apprenticeStatus;
            _currentAcademicYearStartDate = AcademicYearDatesHelper.GetCurrentAcademicYearStartDate();
            _currentAcademicYearEndDate = AcademicYearDatesHelper.GetAcademicYearEndDate();
            _nextAcademicYearStartDate = AcademicYearDatesHelper.GetNextAcademicYearStartDate();
            _nextAcademicYearEndDate = AcademicYearDatesHelper.GetAcademicYearEndDate(_nextAcademicYearStartDate);
            CourseStartDate = courseStartDate;
            CourseEndDate = courseEndDate;
            CourseDetails = randomCourseHelper.SelectASpecificCourse(larsCode);
            CourseLarsCode = larsCode;
        }

        public CourseDetails PortableFlexiJobCourseDetails { get; private set; }

        public CourseDetails CourseDetails { get; private set; }

        public CourseDetails OtherCourseDetails { get; private set; }

        public string CourseLarsCode { get; private set; }

        public string OtherCourseLarsCode { get; private set; }

        public int CourseDurationInMonths => CourseDetails.Course.proposedTypicalDuration;

        public DateTime CourseStartDate { get; internal set; }

        public DateTime CourseEndDate { get; internal set; }

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