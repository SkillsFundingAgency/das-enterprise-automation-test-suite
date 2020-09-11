using NServiceBus;
using SFA.DAS.NServiceBus.Configuration;
using SFA.DAS.NServiceBus.Configuration.AzureServiceBus;
using SFA.DAS.NServiceBus.Configuration.NewtonsoftJsonSerializer;
using SFA.DAS.Payments.ProviderPayments.Messages;
using System;
using System.Threading.Tasks;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class NServiceBusHelper
    {
        private readonly string _connectionString;

        public NServiceBusHelper(string connectionString) => _connectionString = connectionString;

        public async Task Publish(string endpointName, object eventName)
        {
            var endpointConfiguration = new EndpointConfiguration(endpointName)
                .UseErrorQueue($"{endpointName}-errors")
                .UseInstallers()
                .UseMessageConventions()
                .UseNewtonsoftJsonSerializer();

            endpointConfiguration.Conventions().DefiningEventsAs(t =>
                t.Name.EndsWith("Event")
                || t == typeof(RecordedAct1CompletionPayment));

            var transport = endpointConfiguration.UseTransport<AzureServiceBusTransport>();
            var ruleNameShortener = new RuleNameShortener();

            transport.ConnectionString(_connectionString);
            transport.RuleNameShortener(ruleNameShortener.Shorten);
            transport.Transactions(TransportTransactionMode.ReceiveOnly);

            var endpoint = await Endpoint.Start(endpointConfiguration);

            await endpoint.Publish(eventName);
            Console.WriteLine($"Published {nameof(eventName)}");

            await endpoint.Stop();
        }
    }
}
