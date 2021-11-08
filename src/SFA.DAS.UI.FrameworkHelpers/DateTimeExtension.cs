using System;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public static class DateTimeExtension
    {
        public static string ToSeconds(this DateTime dateTime) => $"{dateTime:ddMMMyyyy_HHmmss}";

        public static string ToNanoSeconds(this DateTime dateTime) => dateTime.ToString("fffff");
    }
}
