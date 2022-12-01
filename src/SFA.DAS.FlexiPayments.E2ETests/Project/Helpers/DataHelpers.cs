using System;

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

        public static T ToEnum<T>(this string value, bool ignoreCase = true)
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }
    }
}
