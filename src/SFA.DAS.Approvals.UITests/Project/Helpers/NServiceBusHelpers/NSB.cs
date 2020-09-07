using NServiceBus;
using SFA.DAS.NServiceBus.Configuration;
using SFA.DAS.NServiceBus.Configuration.AzureServiceBus;
using SFA.DAS.NServiceBus.Configuration.NewtonsoftJsonSerializer;
using SFA.DAS.Payments.ProviderPayments.Messages;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Threading.Tasks;


namespace SFA.DAS.Approvals.UITests.Project.Helpers.NServiceBusHelpers
{
    public class NSB
    {
        private const string EndpointName = "SFA.DAS.Approvals.RegressionTests";
        protected readonly string connectionString;

        public NSB(ApprovalsConfig approvalsConfig) => connectionString = approvalsConfig.ServiceBusConnectionString;
        
        public void PublishEvent(object eventName)
        {
            Task t = Publish(eventName);
            t.Wait();
        }

        private async Task Publish(object eventName)
        {
            var endpointConfiguration = new EndpointConfiguration(EndpointName)
                .UseErrorQueue($"{EndpointName}-errors")
                .UseInstallers()
                .UseMessageConventions()
                .UseNewtonsoftJsonSerializer();

            endpointConfiguration.Conventions().DefiningEventsAs(t =>
                t.Name.EndsWith("Event")
                || t == typeof(RecordedAct1CompletionPayment));

            var transport = endpointConfiguration.UseTransport<AzureServiceBusTransport>();
            var ruleNameShortener = new RuleNameShortener();

            transport.ConnectionString(connectionString);
            transport.RuleNameShortener(ruleNameShortener.Shorten);
            transport.Transactions(TransportTransactionMode.ReceiveOnly);

            var endpoint = await Endpoint.Start(endpointConfiguration);

            await endpoint.Publish(eventName);
            Console.WriteLine($"Published {nameof(eventName)}");

            await endpoint.Stop();
            
        }
    }
}
