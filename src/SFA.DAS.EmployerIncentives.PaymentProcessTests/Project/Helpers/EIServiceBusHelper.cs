using System;
using NServiceBus;
using SFA.DAS.NServiceBus.Configuration;
using SFA.DAS.NServiceBus.Configuration.AzureServiceBus;
using SFA.DAS.NServiceBus.Configuration.NewtonsoftJsonSerializer;
using System.Threading.Tasks;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class EIServiceBusHelper
    {
        private readonly IEndpointInstance _endpoint;

        public EIServiceBusHelper(EIPaymentProcessConfig config)
        {
            var endpointConfiguration = new EndpointConfiguration("SFA.DAS.EmployerIncentives.Functions.DomainMessageHandlers")
                .UseMessageConventions()
                .UseNewtonsoftJsonSerializer();

            if (config.EI_ServiceBusConnectionString.Equals("UseLearningEndpoint=true", StringComparison.CurrentCultureIgnoreCase))
            {
                var transport = endpointConfiguration.UseTransport<LearningTransport>();
                transport.StorageDirectory(config.LearningTransportStorageDirectory);
                transport.Routing().AddRouting();
                transport.Transactions(TransportTransactionMode.ReceiveOnly);
            }
            else
            {
                var transport = endpointConfiguration.UseTransport<AzureServiceBusTransport>();
                var ruleNameShortener = new RuleNameShortener();

                transport.ConnectionString(config.EI_ServiceBusConnectionString);
                transport.Routing().AddRouting();
                transport.RuleNameShortener(ruleNameShortener.Shorten);
                transport.Transactions(TransportTransactionMode.ReceiveOnly);
            }

            _endpoint = Endpoint.Start(endpointConfiguration).GetAwaiter().GetResult();
        }

        public async Task Publish<T>(T message) where T : class
        {
            await _endpoint.Send(message);
        }
    }
}
