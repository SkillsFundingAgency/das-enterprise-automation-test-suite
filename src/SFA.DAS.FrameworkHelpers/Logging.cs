using NUnit.Framework;
using System;

namespace SFA.DAS.FrameworkHelpers
{
    public static class Logging
    {
        public static void Report(int retryCount, TimeSpan timeSpan, Exception exception, string scenarioTitle, string uniqueIdentifier, Action retryAction = null) => TestContext.Progress.WriteLine(Message(retryCount, timeSpan, exception, scenarioTitle, uniqueIdentifier, retryAction));

        internal static string Message(int retryCount, TimeSpan timeSpan, Exception exception, string scenarioTitle, string uniqueIdentifier, Action retryAction = null)
        {
          return ($"{Environment.NewLine}" +
                 $"Retry Count : {retryCount}{Environment.NewLine}" +
                 $"UniqueIdentifier : {uniqueIdentifier}{Environment.NewLine}" +
                 $"TimeSpan : {timeSpan.TotalSeconds} seconds{Environment.NewLine}" +
                 $"Scenario Title : {scenarioTitle}{Environment.NewLine}" +
                 $"Exception : {exception.Message}{Environment.NewLine}" +
                 $"Retry Action : {HasRetryAction(retryAction)}");
        }


        private static string HasRetryAction(Action retryAction) => retryAction == null ? "No Retry Action" : "Retry Action Exists";
    }
}
