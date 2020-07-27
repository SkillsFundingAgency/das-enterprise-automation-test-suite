using System;
using System.Collections.Generic;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public enum ApprenticeStatus
    {
        Live,
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
        private readonly RandomCourseDataHelper _randomCourseHelper;

        private const int acadamicYearStartMonth = 8;
        private const int acadamicYearEndMonth = 7;
        private const int acadamicYearStartDay = 1;
        private const int acadamicYearEndDay = 31;

        public ApprenticeCourseDataHelper(RandomCourseDataHelper randomCourseHelper, ApprenticeStatus apprenticeStatus)
        {
            _randomCourseHelper = randomCourseHelper;
            _apprenticeStatus = apprenticeStatus;
            _currentAcademicYearStartDate = GetCurrentAcademicYearStartDate();
            _currentAcademicYearEndDate = GetAcademicYearEndDate(_currentAcademicYearStartDate);
            _nextAcademicYearStartDate = GetNextAcademicYearStartDate(_currentAcademicYearStartDate);
            _nextAcademicYearEndDate = GetAcademicYearEndDate(_nextAcademicYearStartDate);
            CourseStartDate = GenerateCourseStartDate();
            Course = randomCourseHelper.RandomCourse();
        }

        public int RandomCourse(List<string> availablecourses)
        {
            var random = new Random().Next(1, availablecourses.Count);
            Course = availablecourses[random];
            return random;
        }

        public string Course { get; private set; }

        public int CourseDurationInMonths => 15;

        public DateTime CourseStartDate { get; internal set; }

        public DateTime CourseEndDate => CourseStartDate.AddMonths(CourseDurationInMonths);

        private DateTime GenerateCourseStartDate()
        {
            DateTime start = _currentAcademicYearStartDate;
            DateTime end = _randomCourseHelper.RandomNumber % 2 == 0 ? _currentAcademicYearEndDate : DateTime.Now;
            int range = (end - start).Days;
            var randomStartDate = start.AddDays(new Random().Next(range));
            return _apprenticeStatus == ApprenticeStatus.Live ? GetLiveApprenticeStartDate(randomStartDate) :
                   _apprenticeStatus == ApprenticeStatus.CurrentAcademicYearStartDate ? _currentAcademicYearStartDate :
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
                var start = now.AddMonths(1);
                int range = (_nextAcademicYearStartDate - start).Days;
                range = (range > 0) ? range - 1 : 0;
                return start.AddDays(new Random().Next(range));
            }

            return dateTime.Date <= now.Date ? RandomStartDate() : IsThisMonthAndYear(dateTime) ? RandomStartDate() : dateTime;
        }

        private bool IsThisMonthAndYear(DateTime dateTime)
        {
            return dateTime.Month == DateTime.Now.Month && dateTime.Year == DateTime.Now.Year;
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