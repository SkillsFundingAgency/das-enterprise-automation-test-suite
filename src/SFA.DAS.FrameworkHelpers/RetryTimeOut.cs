namespace SFA.DAS.FrameworkHelpers
{
    public static class RetryTimeOut
    {
        public static TimeSpan[] LongerTimeout() => GetTimeSpan(5, 8, 13);

        public static TimeSpan[] DefaultTimeout() => GetTimeSpan(1, 2, 3);

        public static TimeSpan[] ShorterTimeout() => GetTimeSpan(1, 1, 1);

        internal static TimeSpan[] Timeout() => new TimeSpan[] { TimeSpan.FromSeconds(1) };

        internal static TimeSpan[] GetTimeSpan(int a, int b, int c) => GetTimeSpan([a, b, c]);

        public static TimeSpan[] GetTimeSpan(int[] x)
        {
            TimeSpan[] result = new TimeSpan[x.Length];

            for (int i = 0; i < result.Length; i++) result[i] = TimeSpan.FromSeconds(x[i]);

            return result;
        }
    }
}
