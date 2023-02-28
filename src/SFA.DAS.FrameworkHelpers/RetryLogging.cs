using SFA.DAS.TestDataExport;
using System;

namespace SFA.DAS.FrameworkHelpers
{
    public class RetryLogging
    {
        private readonly ObjectContext objectContext;

        public RetryLogging(ObjectContext objectContext) => this.objectContext = objectContext;

        public void Report(int retryCount, Exception exception, string scenarioTitle, Action retryAction = null) => objectContext.SetRetryInformation(Logging.Message(retryCount, exception, scenarioTitle, retryAction));

    }
}
