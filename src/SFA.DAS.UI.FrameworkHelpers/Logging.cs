using NUnit.Framework;
using System;


namespace SFA.DAS.UI.FrameworkHelpers
{
    internal static class Logging
    {
        internal static void Report(int retryCount, Exception exception, string scenarioTitle, Action retryAction = null)
        {
            TestContext.Progress.WriteLine($"{Environment.NewLine}" +
                $"Retry Count : {retryCount}{Environment.NewLine}" +
                $"Scenario Title : {scenarioTitle}{Environment.NewLine}" +
                $"Exception : {exception.Message}{Environment.NewLine}" +
                $"Retry Action : {retryAction == null}");
        }

        internal static TimeSpan[] SetTimeOut() => new TimeSpan[] { TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(3) };
    }
}
