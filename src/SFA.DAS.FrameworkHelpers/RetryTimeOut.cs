using System;

namespace SFA.DAS.FrameworkHelpers
{
    public static class RetryTimeOut
    {
        internal static TimeSpan[] LongerTimeout() => new TimeSpan[] { TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(8), TimeSpan.FromSeconds(13) };

        public static TimeSpan[] DefaultTimeout() => new TimeSpan[] { TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(3) };

        public static TimeSpan[] ShorterTimeout() => new TimeSpan[] { TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1) };

        internal static TimeSpan[] Timeout() => new TimeSpan[] { TimeSpan.FromSeconds(1) };
    }
}
