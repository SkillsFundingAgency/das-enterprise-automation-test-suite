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

        public void RetryOnNUnitException(Action action, Action retryAction = null)
        {
            Policy
                 .Handle<AssertionException>()
                 .Or<MultipleAssertException>()
                 .WaitAndRetry(Logging.DefaultTimeout(), (exception, timeSpan, retryCount, context) =>
                 {
                     Logging.Report(retryCount, exception, _title, retryAction);
                     retryAction?.Invoke();
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