using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class TransformationSteps
    {
        private readonly ObjectContext _objectContext;

        public TransformationSteps(ScenarioContext context) => _objectContext = context.Get<ObjectContext>(); 

        [StepArgumentTransformation(@"(main|supporting|employer)")]
        public ApplicationRoute Applicationroute(string applicationroute)
        {
            var route = Enum.Parse<ApplicationRoute>(applicationroute, true);

            _objectContext.SetApplicationRoute(route);
            
            return route;
        }
    }
}
