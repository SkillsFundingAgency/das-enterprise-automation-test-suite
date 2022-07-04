using System;

namespace SFA.DAS.FrameworkHelpers
{
    public class AornDataHelper
    {
        public AornDataHelper() => AornNumber = $"A{GetDateTimeValue()}";

        public string AornNumber { get; }

        public static string InvalidAornNumber => $"A{GetDateTimeValue()}";

        private static string GetDateTimeValue() => DateTime.Now.ToString("ddMMyyHHmmss");
    }
}
