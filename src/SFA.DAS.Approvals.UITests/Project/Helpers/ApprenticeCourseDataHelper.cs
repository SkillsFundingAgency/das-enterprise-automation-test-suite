using System;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers
{
    public enum ApprenticeStatus
    {
        Live,
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
        private readonly RandomCourseHelper _randomCourseHelper;

        private const int acadamicYearStartMonth = 8;
        private const int acadamicYearEndMonth = 7;
        private const int acadamicYearStartDay = 1;
        private const int acadamicYearEndDay = 31;

        public ApprenticeCourseDataHelper(RandomCourseHelper randomCourseHelper, ApprenticeStatus apprenticeStatus)
        {
            _randomCourseHelper = randomCourseHelper;
            _apprenticeStatus = apprenticeStatus;
            _currentAcademicYearStartDate = GetCurrentAcademicYearStartDate();
            _currentAcademicYearEndDate = GetAcademicYearEndDate(_currentAcademicYearStartDate);
            _nextAcademicYearStartDate = GetNextAcademicYearStartDate(_currentAcademicYearStartDate);
            _nextAcademicYearEndDate = GetAcademicYearEndDate(_nextAcademicYearStartDate);
            CourseStartDate = GenerateCourseStartDate();
            CourseEndDate = GetCourseEndDate();
            Course = randomCourseHelper.RandomCourse();
        }

        public string Course { get; }

        public int CourseDurationInMonths => 15;

        public DateTime CourseStartDate { get; }

        public DateTime CourseEndDate { get; }

        private DateTime GenerateCourseStartDate()
        {
            DateTime start = _currentAcademicYearStartDate;
            DateTime end = (_randomCourseHelper.RandomNumber % 2 == 0) ? _currentAcademicYearEndDate : DateTime.Now;
            int range = (end - start).Days;
            var randomStartDate = start.AddDays(new Random().Next(range));
            return _apprenticeStatus == ApprenticeStatus.Live ? GetLiveApprenticeStartDate(randomStartDate) :
                   _apprenticeStatus == ApprenticeStatus.WaitingToStart ? GetWaitingToStartApprenticeStartDate(randomStartDate) : randomStartDate;
        }

        private DateTime GetLiveApprenticeStartDate(DateTime dateTime)
        {
            return dateTime.Date >= DateTime.Now.Date ? _currentAcademicYearStartDate : dateTime;
        }

        private DateTime GetWaitingToStartApprenticeStartDate(DateTime dateTime)
        {
            var now = DateTime.Now;
            DateTime RandomStartDate()
            {
                var start = new DateTime(now.Year, now.Month + 1, now.Day);
                int range = (_nextAcademicYearStartDate - start).Days - 1;
                return start.AddDays(new Random().Next(range));
            }
            
            return dateTime.Date <= now.Date ? RandomStartDate() : IsThisMonthAndYear(dateTime) ? RandomStartDate() : dateTime;
        }

        private bool IsThisMonthAndYear(DateTime dateTime)
        {
            return dateTime.Month == DateTime.Now.Month && dateTime.Year == DateTime.Now.Year;
        }

        private DateTime GetCourseEndDate()
        {
            return CourseStartDate.AddMonths(CourseDurationInMonths);
        }

        private DateTime GetCurrentAcademicYearStartDate()
        {
            var now = DateTime.Now;
            var cutoff = new DateTime(now.Year, acadamicYearStartMonth, acadamicYearStartDay);
            return now >= cutoff ? cutoff : new DateTime(now.Year - 1, acadamicYearStartMonth, acadamicYearStartDay);
        }

        private DateTime GetAcademicYearEndDate(DateTime academicYearStartDate)
        {
            return new DateTime(academicYearStartDate.Year + 1, acadamicYearEndMonth, acadamicYearEndDay);
        }

        private DateTime GetNextAcademicYearStartDate(DateTime currentAcademicYearStartDate)
        {
            return new DateTime(currentAcademicYearStartDate.Year + 1, acadamicYearStartMonth, acadamicYearStartDay);
        }
    }
}
