using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ObjectContext _objectContext;

        public Hooks(ScenarioContext context) => _objectContext = context.Get<ObjectContext>();

        [BeforeScenario(Order = 34)]
        public void SetUpHelpers() => _objectContext.SetRAAV2Employer();
    }
}
