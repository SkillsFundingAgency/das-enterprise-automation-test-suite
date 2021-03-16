using NServiceBus;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Messages;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public static class RoutingSettingsExtensions
    {
        public static void AddRouting(this RoutingSettings routingSettings)
        {
            routingSettings.RouteToEndpoint(typeof(CreateIncentiveCommand), "SFA.DAS.EmployerIncentives.CreateIncentive");
        }
    }
}
