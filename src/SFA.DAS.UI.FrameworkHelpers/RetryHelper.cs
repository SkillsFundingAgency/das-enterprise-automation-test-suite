using System;
using Polly;
using NUnit.Framework;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class RetryHelper
    {
        internal bool RetryOnException(Func<bool> func, Action beforeAction = null)
        {
            return Policy
                 .Handle<Exception>((x) => x.Message.Contains("verification failed"))
                 .WaitAndRetry(TimeOut, (exception, timeSpan, retryCount, context) =>
                 {
                     TestContext.Progress.WriteLine($"Retry Count : {retryCount}, Exception : {exception.Message}");
                 })
                 .Execute(() =>
                 {
                     using (var testcontext = new NUnit.Framework.Internal.TestExecutionContext.IsolatedContext())
                     {
                         beforeAction?.Invoke();
                         return func();
                     }
                 });
        }
        private static TimeSpan[] TimeOut => new[]
        {
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(2),
            TimeSpan.FromSeconds(3)
        };
    }
}