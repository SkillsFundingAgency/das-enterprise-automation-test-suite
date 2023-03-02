using SFA.DAS.FlexiPayments.E2ETests.Project.Tests.TestSupport;
using System;
using System.Linq;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Helpers
{
    public static class DataHelpers
    {
        public static DateTime TryParse(string text)
        {
            DateTime date;
            return DateTime.TryParse(text, out date) ? date : DateTime.Today;
        }

        public static DateTime? TryParseDate(string text)
        {
            DateTime date;
            return DateTime.TryParse(text, out date) ? date : null;
        }

        public static DateTime CalculatePlannedEndDate(DateTime date, string months, FundingPlatform funding) 
        {
            var numberOfMonths = Convert.ToInt32(new String(months.Where(Char.IsDigit).ToArray()));

            var endDate = date.AddMonths(numberOfMonths);

            return (int)funding != 1 ? new DateTime(endDate.Year, endDate.Month, 1) : endDate;
        }

        public static  DateTime GetFirstDateOfCurrentMonth()
        {
            DateTime today = DateTime.Today;
            return new DateTime(today.Year, today.Month, 1);
        }

        public static T ToEnum<T>(this string value, bool ignoreCase = true)
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }
    }
}
