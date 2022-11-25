using System;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Helpers
{
    public static class DateHelpers
    {
        public static DateTime? TryParse(string text)
        {
            DateTime date;
            return DateTime.TryParse(text, out date) ? date : (DateTime?)null;
        }
    }
}
