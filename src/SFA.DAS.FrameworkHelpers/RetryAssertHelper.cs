using NUnit.Framework;
using Polly;

namespace SFA.DAS.FrameworkHelpers
{
    public class RetryAssertHelper(ScenarioInfo scenarioInfo, ObjectContext objectContext)
    {
        private readonly string _title = scenarioInfo.Title;

        public void RetryOnNUnitException(Action action) => RetryOnNUnitException(action, RetryTimeOut.DefaultTimeout());

        public void RetryOnNUnitExceptionWithLongerTimeOut(Action action) => RetryOnNUnitException(action, RetryTimeOut.LongerTimeout());

        public void RetryOnNUnitException(Action action, TimeSpan[] timespan) => RetryOnNUnitException(action, timespan, null);

        public void RetryOnNUnitException(Action action, Action retryaction) => RetryOnNUnitException(action, RetryTimeOut.GetTimeSpan([5, 8, 13, 20, 30, 30, 30]), retryaction);

        private void RetryOnNUnitException(Action action, TimeSpan[] timespan, Action retryaction)
        {
            Policy
                 .Handle<AssertionException>()
                 .Or<MultipleAssertException>()
                 .WaitAndRetry(timespan, (exception, timeSpan, retryCount, context) =>
                 {
                     new RetryLogging(objectContext, "RetryOnNUnitException").Report(retryCount, timeSpan, exception, _title, retryaction);
                     retryaction?.Invoke();
                 })
                 .Execute(() =>
                 {
                     using var testcontext = new NUnit.Framework.Internal.TestExecutionContext.IsolatedContext();
                     action.Invoke();
                 });
        }
    }
}