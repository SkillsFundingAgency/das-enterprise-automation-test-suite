using System;
using NServiceBus;
using SFA.DAS.NServiceBus.Configuration;
using SFA.DAS.NServiceBus.Configuration.AzureServiceBus;
using SFA.DAS.NServiceBus.Configuration.NewtonsoftJsonSerializer;
using System.Threading.Tasks;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    // ReSharper disable once InconsistentNaming
    public class EIServiceBusHelper
    {
        private readonly EIPaymentProcessConfig _config;

        public EIServiceBusHelper(EIPaymentProcessConfig config)
        {
            _config = config;
        }

        public async Task Send<T>(string queueName, T message) where T : class
        {
            var endpoint = SetupEndpoint(queueName);
            await endpoint.Send(message);
        }

        public async Task Publish<T>(string queueName, T message) where T : class
        {
            var endpoint = SetupEndpoint(queueName);
            await endpoint.Publish(message);
        }

        private IEndpointInstance SetupEndpoint(string queueName)
        {

            var endpointConfiguration = new EndpointConfiguration(queueName)
                .UseMessageConventions()
            .UseNewtonsoftJsonSerializer();

            if (_config.EI_ServiceBusConnectionString.Equals("UseLearningEndpoint=true", StringComparison.CurrentCultureIgnoreCase))
            {
                var transport = endpointConfiguration.UseTransport<LearningTransport>();
                transport.StorageDirectory(_config.LearningTransportStorageDirectory);
                transport.Routing().AddRouting();
                transport.Transactions(TransportTransactionMode.ReceiveOnly);
            }
            else
            {
                var transport = endpointConfiguration.UseTransport<AzureServiceBusTransport>();
                transport.ConnectionString(_config.EI_ServiceBusConnectionString);
                transport.Routing().AddRouting();
                transport.SubscriptionRuleNamingConvention(RuleNameShortener.Shorten);
                transport.Transactions(TransportTransactionMode.ReceiveOnly);
            }

            return Endpoint.Start(endpointConfiguration).GetAwaiter().GetResult();
        }
    }
}
