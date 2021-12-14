using System;
using Polly;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class RetryAssertHelper
    {
        private readonly string _title;
        
        public RetryAssertHelper(ScenarioInfo scenarioInfo) => _title = scenarioInfo.Title;

        public void RetryOnNUnitException(Action action) => RetryOnNUnitException(action, false);

        public void RetryOnNUnitExceptionWithLongerTimeOut(Action action) => RetryOnNUnitException(action, true);

        private void RetryOnNUnitException(Action action, bool longerTimeout)
        {
            Policy
                 .Handle<AssertionException>()
                 .Or<MultipleAssertException>()
                 .WaitAndRetry(longerTimeout == true ? Logging.LongerTimeout() : Logging.DefaultTimeout(), (exception, timeSpan, retryCount, context) =>
                 {
                     Logging.Report(retryCount, exception, _title, null);
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