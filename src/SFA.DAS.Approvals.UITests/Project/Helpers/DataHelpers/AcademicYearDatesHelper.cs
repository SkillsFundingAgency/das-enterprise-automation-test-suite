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

    public static class DateTimeExtensions
    {
        public static string ToGdsHumanisedDate(this DateTime date)
        {
            string ordinal;

            switch (date.Day)
            {
                case 1:
                case 21:
                case 31:
                    ordinal = "st";
                    break;
                case 2:
                case 22:
                    ordinal = "nd";
                    break;
                case 3:
                case 23:
                    ordinal = "rd";
                    break;
                default:
                    ordinal = "th";
                    break;
            }

            // Eg 12th January 2024
            return string.Format("{0}{1} {2:MMMM yyyy}", date.Day, ordinal, date);
        }

    }
}