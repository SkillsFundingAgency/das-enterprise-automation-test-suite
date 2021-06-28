using SFA.DAS.Payments.ProviderPayments.Messages;
using SFA.DAS.UI.FrameworkHelpers;
using System;


namespace SFA.DAS.Approvals.UITests.Project.Helpers.NServiceBusHelpers
{
    public class PublishPaymentEvent
    {
        private const string EndpointName = "SFA.DAS.Approvals.RegressionTests";

        private readonly NServiceBusHelper _nServiceBusHelper;

        public PublishPaymentEvent(NServiceBusHelper nServiceBusHelper) => _nServiceBusHelper = nServiceBusHelper;
        
        public void PublishRecordedAct1CompletionPaymentEvent(int apprenticeshipId) => _nServiceBusHelper.Publish(EndpointName, new RecordedAct1CompletionPayment { ApprenticeshipId = apprenticeshipId, EventTime = DateTimeOffset.UtcNow }).Wait();

    }
}
