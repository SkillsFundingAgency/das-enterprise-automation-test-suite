using NServiceBus;
using SFA.DAS.EmployerIncentives.UITests.Messages;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Helpers
{
    public static class RoutingSettingsExtensions
    {
        public static void AddRouting(this RoutingSettings routingSettings)
        {
            routingSettings.RouteToEndpoint(typeof(CreateIncentiveCommand), "SFA.DAS.EmployerIncentives.CreateIncentive");
        }
    }
}
