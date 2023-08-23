using System;
using Polly;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SFA.DAS.FrameworkHelpers
{
    public class RetryAssertHelper
    {
        private readonly string _title;

        private readonly ObjectContext objectContext;

        public RetryAssertHelper(ScenarioInfo scenarioInfo, ObjectContext objectContext)
        {
            _title = scenarioInfo.Title;
            this.objectContext = objectContext;
        }

        public void RetryOnNUnitException(Action action) => RetryOnNUnitException(action, RetryTimeOut.DefaultTimeout());

        public void RetryOnNUnitExceptionWithLongerTimeOut(Action action) => RetryOnNUnitException(action, RetryTimeOut.LongerTimeout());

        public void RetryOnNUnitException(Action action, TimeSpan[] timespan) => RetryOnNUnitException(action, timespan, null);

        public void RetryOnNUnitException(Action action, Action retryaction) => RetryOnNUnitException(action, RetryTimeOut.GetTimeSpan(new int[] { 5, 8, 13, 20, 30 }), retryaction);

        public void RetryOnNUnitException(Action action, TimeSpan[] timespan, Action retryaction)
        {
            Policy
                 .Handle<AssertionException>()
                 .Or<MultipleAssertException>()
                 .WaitAndRetry(timespan, (exception, timeSpan, retryCount, context) =>
                 {
                     new RetryLogging(objectContext, "RetryOnNUnitException").Report(retryCount, timeSpan, exception, _title, null);
                     retryaction?.Invoke();
                 })
                 .Execute(() =>
                 {
                     using (var testcontext = new NUnit.Framework.Internal.TestExecutionContext.IsolatedContext())
                     {
                         action.Invoke();
                     }
                 });
        }
    }
}