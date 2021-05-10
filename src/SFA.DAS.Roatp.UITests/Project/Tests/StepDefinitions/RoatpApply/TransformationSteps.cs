using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Roatp.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.StepDefinitions.RoatpApply
{
    [Binding]
    public class TransformationSteps
    {
        private readonly ObjectContext _objectContext;

        public TransformationSteps(ScenarioContext context) => _objectContext = context.Get<ObjectContext>();

        [StepArgumentTransformation(@"(main|supporting|employer)")]
        public ApplicationRoute Applicationroute(string applicationroute)
        {
            var route = ApplicationRouteHelper.GetApplicationRoute(applicationroute);

            _objectContext.SetApplicationRoute(route);

            return route;
        }
    }
}
