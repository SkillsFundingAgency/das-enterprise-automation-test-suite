using SFA.DAS.Approvals.ServiceBusIntegrationTests.Project.Helpers.NServiceBusHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.ServiceBusIntegrationTests.Project.Tests.StepDefinitions
{
    [Binding]
    public class NServiceBusSteps(ScenarioContext context)
    {
        private readonly PublishPaymentEvent _publishPaymentEvent = context.Get<PublishPaymentEvent>();
        private readonly ApprenticeDataHelper _dataHelper = context.Get<ApprenticeDataHelper>();

        [When(@"PaymentsCompletion event is received")]
        public void WhenPaymentsCompletionEventIsReceived() => _publishPaymentEvent.PublishRecordedAct1CompletionPaymentEvent(_dataHelper.ApprenticeshipId());
    }
}
