using SFA.DAS.Approvals.ServiceBusIntegrationTests.Project.Helpers.NServiceBusHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.ServiceBusIntegrationTests.Project.Tests.StepDefinitions
{
    [Binding]
    public class NServiceBusSteps
    {
        private readonly ScenarioContext _context;
        private readonly PublishPaymentEvent _publishPaymentEvent;
        private readonly ApprenticeDataHelper _dataHelper;

        public NServiceBusSteps(ScenarioContext context)
        {
            _context = context;
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _publishPaymentEvent = context.Get<PublishPaymentEvent>();
        }

        [When(@"PaymentsCompletion event is received")]
        public void WhenPaymentsCompletionEventIsReceived() => _publishPaymentEvent.PublishRecordedAct1CompletionPaymentEvent(_dataHelper.ApprenticeshipId(_context.ScenarioInfo.Title));
    }
}
