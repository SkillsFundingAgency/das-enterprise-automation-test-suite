using SFA.DAS.TestDataExport;
using System;

namespace SFA.DAS.FrameworkHelpers
{
    public class RetryLogging
    {
        private readonly ObjectContext objectContext;

        private readonly string uniqueIdentifier;

        public RetryLogging(ObjectContext objectContext, string uniqueIdentifier) 
        {
            this.objectContext = objectContext;

            this.uniqueIdentifier = uniqueIdentifier;
        }

        public void Report(int retryCount, TimeSpan timeSpan, Exception exception, string scenarioTitle, Action retryAction = null) => objectContext.SetRetryInformation(Logging.Message(retryCount, timeSpan, exception, scenarioTitle, uniqueIdentifier, retryAction));

    }
}
