using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;

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

        private readonly CourseDetails _courseDetails;
        private readonly CourseDetails _otherCourseDetails;

        public ApprenticeCourseDataHelper(RandomCourseDataHelper randomCourseHelper, ApprenticeStatus apprenticeStatus)
        {
            _apprenticeStatus = apprenticeStatus;
            _currentAcademicYearStartDate = AcademicYearDatesHelper.GetCurrentAcademicYearStartDate();
            _currentAcademicYearEndDate = AcademicYearDatesHelper.GetAcademicYearEndDate();
            _nextAcademicYearStartDate = AcademicYearDatesHelper.GetNextAcademicYearStartDate();
            _nextAcademicYearEndDate = AcademicYearDatesHelper.GetAcademicYearEndDate(_nextAcademicYearStartDate);
            CourseStartDate = GenerateCourseStartDate();
            _courseDetails = randomCourseHelper.RandomCourse();
            Course = _courseDetails.Course.larsCode;
            _otherCourseDetails = randomCourseHelper.RandomCourse(Course);
            OtherCourse = _otherCourseDetails.Course.larsCode;
        }

        public int RandomCourse(List<string> availablecourses)
        {
            var random = new Random().Next(1, availablecourses.Count);
            Course = availablecourses[random];
            return random;
        }

        public string Course { get; private set; }

        public string OtherCourse { get; private set; }

        public int CourseDurationInMonths => _courseDetails.Course.proposedTypicalDuration;

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