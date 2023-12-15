using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Roatp.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.StepDefinitions.RoatpApply
{
    [Binding]
    public class TransformationSteps(ScenarioContext context)
    {
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

        [StepArgumentTransformation(@"(main|supporting|employer)")]
        public ApplicationRoute Applicationroute(string applicationroute)
        {
            var route = ApplicationRouteHelper.GetApplicationRoute(applicationroute);

            _objectContext.SetApplicationRoute(route);

            return route;
        }
    }
}
