using SFA.DAS.FlexiPayments.E2ETests.Project.Tests.TestSupport;
using System;
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

        public static DateTime CalculatePlannedEndDate(DateTime date, string months, FundingPlatform funding) 
        {
            var numberOfMonths = Convert.ToInt32(new String(months.Where(Char.IsDigit).ToArray()));

            var endDate = date.AddMonths(numberOfMonths);

            if (IsLastDayOfTheMonth(endDate)) endDate = endDate.AddDays(-1);

            return (int)funding != 1 ? new DateTime(endDate.Year, endDate.Month, 1) : endDate;
        }

        public static  DateTime GetFirstDateOfCurrentMonth()
        {
            DateTime today = DateTime.Today;
            return new DateTime(today.Year, today.Month, 1);
        }

        public static DateTime GetFirstDateOfPreviousMonth()
        {
            DateTime today = DateTime.Today;
            return new DateTime(today.Year, today.Month-1, 1);
        }

        public static T ToEnum<T>(this string value, bool ignoreCase = true)
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }

        internal static DateTime CalculateStartDate(bool isStartInPreviousMonth = false)
        {
            DateTime date = DateTime.Today;

            if (isStartInPreviousMonth) date = new DateTime(date.Year, date.Month-1, date.Day);

            return IsLastDayOfTheMonth(date) ? date.AddDays(-1) : date;
        }
           

        private static bool IsLastDayOfTheMonth(DateTime date) => DateTime.DaysInMonth(date.Year, date.Month) == date.Day;
    }
}
