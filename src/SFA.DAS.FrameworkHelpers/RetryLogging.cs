namespace SFA.DAS.FrameworkHelpers
{
    public class RetryLogging(ObjectContext objectContext, string uniqueIdentifier)
    {
        public void Report(int retryCount, TimeSpan timeSpan, Exception exception, string scenarioTitle, Action retryAction = null)
        {
            objectContext.SetDebugInformation($"RETRY Count : {retryCount}, UniqueIdentifier : {uniqueIdentifier}");

            objectContext.SetRetryInformation(Logging.Message(retryCount, timeSpan, exception, scenarioTitle, uniqueIdentifier, retryAction));
        }

    }
}
