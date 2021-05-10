using SFA.DAS.Roatp.UITests.Project;
using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.Roatp.UITests.Project.Hooks;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Hooks
{
    [Binding, Scope(Tag = "rpgateway")]
    public class RoatpAdminGatewayBeforeScenarioHooks : RoatpBaseHooks
    {
        private readonly ScenarioContext _context;

        public RoatpAdminGatewayBeforeScenarioHooks(ScenarioContext context) : base(context)  =>_context = context;

        [BeforeScenario(Order = 36)]
        public void SetUpGatewayApplicationRoute() => _objectContext.SetApplicationRoute(ApplicationRouteHelper.GetApplicationRoute(_context.ScenarioInfo.Title));
    }
}
