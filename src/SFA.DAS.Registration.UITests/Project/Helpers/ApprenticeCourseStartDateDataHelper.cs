using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class ApprenticeCourseStartDateDataHelper
    {
        protected readonly ApprenticeStatus _apprenticeStatus;
        private readonly DateTime _currentAcademicYearStartDate;
        private readonly DateTime _currentAcademicYearEndDate;
        private readonly DateTime _nextAcademicYearStartDate;
        private readonly DateTime _nextAcademicYearEndDate;

        private const int acadamicYearStartMonth = 8;
        private const int acadamicYearEndMonth = 7;
        private const int acadamicYearStartDay = 1;
        private const int acadamicYearEndDay = 31;

        public ApprenticeCourseStartDateDataHelper(ApprenticeStatus apprenticeStatus)
        {
            _apprenticeStatus = apprenticeStatus;
            _currentAcademicYearEndDate = GetAcademicYearEndDate(_currentAcademicYearStartDate);
            _nextAcademicYearStartDate = GetNextAcademicYearStartDate(_currentAcademicYearStartDate);
            _nextAcademicYearEndDate = GetAcademicYearEndDate(_nextAcademicYearStartDate);
            CourseStartDate = GenerateCourseStartDate();
            _currentAcademicYearStartDate = GetCurrentAcademicYearStartDate();
        }

        public DateTime CourseStartDate { get; set; }

        private DateTime GenerateCourseStartDate()
        {
            DateTime start = _currentAcademicYearStartDate;
            DateTime end = new RandomDataGenerator().GenerateRandomNumberBetweenTwoValues(1, 10) % 2 == 0 ? _currentAcademicYearEndDate : DateTime.Now;
            int range = (end - start).Days;
            var randomStartDate = start.AddDays(new Random().Next(range));
            return _apprenticeStatus == ApprenticeStatus.Live ? GetLiveApprenticeStartDate(randomStartDate) :
                   _apprenticeStatus == ApprenticeStatus.CurrentAcademicYearStartDate ? _currentAcademicYearStartDate :
                   _apprenticeStatus == ApprenticeStatus.WaitingToStart ? GetWaitingToStartApprenticeStartDate(randomStartDate) : randomStartDate;
        }


        private DateTime GetCurrentAcademicYearStartDate()
        {
            var now = DateTime.Now;
            var cutoff = new DateTime(now.Year, acadamicYearStartMonth, acadamicYearStartDay);
            return now >= cutoff ? cutoff : new DateTime(now.Year - 1, acadamicYearStartMonth, acadamicYearStartDay);
        }


        private DateTime GetLiveApprenticeStartDate(DateTime dateTime) => dateTime.Date >= DateTime.Now.Date ? _currentAcademicYearStartDate : dateTime;

        private DateTime GetWaitingToStartApprenticeStartDate(DateTime dateTime)
        {
            var now = DateTime.Now;
            DateTime RandomStartDate()
            {
                var start = now.AddMonths(1);
                int range = (_nextAcademicYearStartDate - start).Days;
                range = range > 0 ? range - 1 : 0;
                return start.AddDays(new Random().Next(range));
            }

            return dateTime.Date <= now.Date ? RandomStartDate() : IsThisMonthAndYear(dateTime) ? RandomStartDate() : dateTime;
        }

        private bool IsThisMonthAndYear(DateTime dateTime) => dateTime.Month == DateTime.Now.Month && dateTime.Year == DateTime.Now.Year;


        private DateTime GetAcademicYearEndDate(DateTime academicYearStartDate) => new DateTime(academicYearStartDate.Year + 1, acadamicYearEndMonth, acadamicYearEndDay);

        private DateTime GetNextAcademicYearStartDate(DateTime currentAcademicYearStartDate) => new DateTime(currentAcademicYearStartDate.Year + 1, acadamicYearStartMonth, acadamicYearStartDay);
    }
}
