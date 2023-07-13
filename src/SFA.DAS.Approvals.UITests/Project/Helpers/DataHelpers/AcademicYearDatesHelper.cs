using System;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public class AcademicYearDatesHelper
    {
        private const int StartMonth = 8;
        private const int EndMonth = 7;
        private const int StartDay = 1;
        private const int EndDay = 31;

        private static readonly DateTime _currentAcademicYearStartDate;

        static AcademicYearDatesHelper() => _currentAcademicYearStartDate = GetCurrentAcademicYearStartDate();

        public static DateTime GetCurrentAcademicYearStartDate()
        {
            var now = DateTime.Now;
            var cutoff = new DateTime(now.Year, StartMonth, StartDay);
            return now >= cutoff ? cutoff : new DateTime(now.Year - 1, StartMonth, StartDay);
        }

        public static DateTime GetCurrentAcademicYearEndDate() => GetAcademicYearEndDate(_currentAcademicYearStartDate);

        public static DateTime GetNextAcademicYearStartDate() => new(_currentAcademicYearStartDate.Year + 1, StartMonth, StartDay);

        public static DateTime GetNextAcademicYearEndDate() => GetAcademicYearEndDate(GetNextAcademicYearStartDate());

        public static int GetCurrentAcademicYear() => Convert.ToInt32(_currentAcademicYearStartDate.ToString("yy") + _currentAcademicYearStartDate.AddYears(1).ToString("yy"));

        private static DateTime GetAcademicYearEndDate(DateTime academicYearStartDate) => new(academicYearStartDate.Year + 1, EndMonth, EndDay);
    }
}