using Polly;
using System;

namespace SFA.DAS.FrameworkHelpers
{
    public abstract class SqlDbRetryHelper
    {
        protected T RetryOnException<T>(Func<T> func) => RetryOnException(func, "Exception occurred while executing SQL query", string.Empty);

        protected T RetryOnException<T>(Func<T> func, string exception, string title, TimeSpan[] timeSpans = null)
        {
            timeSpans ??= Logging.Timeout();

            return Policy
                .Handle<Exception>((x) => x.Message.Contains(exception))
                 .WaitAndRetry(timeSpans, (exception, timeSpan, retryCount, context) =>
                 {
                     Logging.Report(retryCount, exception, title);
                 })
                 .Execute(func);
        }
    }
}
