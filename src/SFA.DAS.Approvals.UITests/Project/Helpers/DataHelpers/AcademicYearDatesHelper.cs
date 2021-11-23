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

        public static DateTime GetAcademicYearEndDate() => GetAcademicYearEndDate(_currentAcademicYearStartDate);

        public static DateTime GetAcademicYearEndDate(DateTime academicYearStartDate) => new DateTime(academicYearStartDate.Year + 1, EndMonth, EndDay);

        public static DateTime GetNextAcademicYearStartDate() => new DateTime(_currentAcademicYearStartDate.Year + 1, StartMonth, StartDay);
    }
}