using System;
using Polly;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class AssertHelper
    {
        private readonly string _title;
        private readonly TimeSpan[] TimeOut;

        public AssertHelper(ScenarioInfo scenarioInfo)
        {
            _title = scenarioInfo.Title;
            TimeOut = Logging.SetTimeOut();
        }
        public void RetryOnNUnitException(Action action, Action retryAction = null)
        {
            Policy
                 .Handle<AssertionException>()
                 .Or<MultipleAssertException>()
                 .WaitAndRetry(TimeOut, (exception, timeSpan, retryCount, context) =>
                 {
                     Logging.Report(retryCount, exception, _title, retryAction);
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