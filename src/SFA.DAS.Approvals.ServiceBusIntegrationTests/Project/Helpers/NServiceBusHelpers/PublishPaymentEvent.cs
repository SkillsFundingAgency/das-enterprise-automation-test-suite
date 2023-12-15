using SFA.DAS.Payments.ProviderPayments.Messages;
using System;

namespace SFA.DAS.Approvals.ServiceBusIntegrationTests.Project.Helpers.NServiceBusHelpers
{
    public class PublishPaymentEvent(NServiceBusHelper nServiceBusHelper)
    {
        private const string EndpointName = "SFA.DAS.Approvals.RegressionTests";

        public void PublishRecordedAct1CompletionPaymentEvent(int apprenticeshipId) => nServiceBusHelper.Publish(EndpointName, new RecordedAct1CompletionPayment { ApprenticeshipId = apprenticeshipId, EventTime = DateTimeOffset.UtcNow }).Wait();

    }
}
