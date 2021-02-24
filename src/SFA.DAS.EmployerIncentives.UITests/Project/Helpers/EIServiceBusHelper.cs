using System.Threading.Tasks;
using NServiceBus;
using SFA.DAS.NServiceBus.Configuration;
using SFA.DAS.NServiceBus.Configuration.AzureServiceBus;
using SFA.DAS.NServiceBus.Configuration.NewtonsoftJsonSerializer;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Helpers
{
    public class EIServiceBusHelper
    {
        private IEndpointInstance _endpoint;

        public EIServiceBusHelper(EIConfig config)
        {
            var endpointConfiguration = new EndpointConfiguration("SFA.DAS.EmployerIncentives.Functions.DomainMessageHandlers")
                .UseMessageConventions()
                .UseNewtonsoftJsonSerializer();

            var transport = endpointConfiguration.UseTransport<AzureServiceBusTransport>();
            var ruleNameShortener = new RuleNameShortener();

            transport.ConnectionString(config.EI_ServiceBusConnectionString);
            transport.Routing().AddRouting();
            transport.RuleNameShortener(ruleNameShortener.Shorten);
            transport.Transactions(TransportTransactionMode.ReceiveOnly);

            _endpoint = Endpoint.Start(endpointConfiguration).GetAwaiter().GetResult();
        }

        public async Task Publish<T>(T message) where T : class
        {
            await _endpoint.Send(message);
        }
    }
}
