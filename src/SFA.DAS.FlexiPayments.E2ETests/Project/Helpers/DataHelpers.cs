using SFA.DAS.FlexiPayments.E2ETests.Project.Tests.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Helpers
{
    public static class DataHelpers
    {
        public static DateTime TryParse(string text)
        {
            return DateTime.TryParse(text, out DateTime date) ? date : DateTime.Today;
        }

        public static DateTime? TryParseDate(string text)
        {
            return DateTime.TryParse(text, out DateTime date) ? date : null;
        }

        public static DateTime? ParseExact(string text)
        {
            return DateTime.ParseExact(text, "dd/MM/yyyy HH:mm:ss", null);
        }

        public static DateTime CalculatePlannedEndDate(DateTime date, string months, FundingPlatform funding)
        {
            var numberOfMonths = Convert.ToInt32(new String(months.Where(Char.IsDigit).ToArray()));

            var endDate = date.AddMonths(numberOfMonths);

            if (IsLastDayOfTheMonth(endDate)) endDate = endDate.AddDays(-1);

            return (int)funding != 1 ? new DateTime(endDate.Year, endDate.Month, 1) : endDate;
        }

        public static DateTime GetFirstDateOfCurrentMonth()
        {
            DateTime today = DateTime.Today;
            return new DateTime(today.Year, today.Month, 1);
        }

        public static DateTime GetFirstDateOfPreviousMonth()
        {
            DateTime date = DateTime.Today;

            if (date.Month == 1) date = new DateTime(date.Year - 1, 12, 1);
            else date = new DateTime(date.Year, date.Month - 1, 1);

            return date;
        }

        public static T ToEnum<T>(this string value, bool ignoreCase = true)
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }

        public static byte CalculatePeriod(byte numberOfMonthsToAdd)
        {
            string currentMonth = DateTime.Now.AddMonths(numberOfMonthsToAdd).ToString("MMMM");

            if (Period.TryGetValue(currentMonth, out byte value))
            {
                return value;
            }
            else
            {
                throw new ArgumentException($"The month '{currentMonth}' is not recognized."); // Handle unexpected cases
            }
        }

        public static string CalculateAcademicYear(byte numberOfMonthsToAdd, DateTime date = default)
        {
            if (date == default) date = DateTime.Now;

            var month = date.AddMonths(numberOfMonthsToAdd).Month;
            var Year = date.AddMonths(numberOfMonthsToAdd).Year;

            if (month < 8) return $"{(Year - 1) % 100:00}{Year % 100:00}";
            else return $"{Year % 100:00}{(Year + 1) % 100:00}";
        }

        internal static DateTime CalculateStartDate(bool isStartInPreviousMonth = false)
        {
            DateTime date = DateTime.Today;

            if (isStartInPreviousMonth)
            {
                if (date.Month == 1) date = new DateTime(date.Year - 1, 12, date.Day);
                else date = new DateTime(date.Year, date.Month - 1, date.Day);
            }

            return IsLastDayOfTheMonth(date) ? date.AddDays(-1) : date;
        }
        private static bool IsLastDayOfTheMonth(DateTime date) => DateTime.DaysInMonth(date.Year, date.Month) == date.Day;

        public static Dictionary<string, byte> Period = new()
        {
        { "January", 6 },
        { "February", 7 },
        { "March", 8 },
        { "April", 9 },
        { "May", 10 },
        { "June", 11 },
        { "July", 12 },
        { "August", 1 },
        { "September", 2 },
        { "October", 3 },
        { "November", 4 },
        { "December", 5 }
        };
    }
}
