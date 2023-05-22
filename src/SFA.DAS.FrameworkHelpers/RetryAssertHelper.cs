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

        public void RetryOnNUnitException(Action action) => RetryOnNUnitException(action, false);

        public void RetryOnNUnitExceptionWithLongerTimeOut(Action action) => RetryOnNUnitException(action, true);

        private void RetryOnNUnitException(Action action, bool longerTimeout)
        {
            Policy
                 .Handle<AssertionException>()
                 .Or<MultipleAssertException>()
                 .WaitAndRetry(longerTimeout == true ? RetryTimeOut.LongerTimeout() : RetryTimeOut.DefaultTimeout(), (exception, timeSpan, retryCount, context) =>
                 {
                     new RetryLogging(objectContext, "RetryOnNUnitException").Report(retryCount, exception, _title, null);
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