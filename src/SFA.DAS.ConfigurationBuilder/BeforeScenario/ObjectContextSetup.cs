using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConfigurationBuilder.BeforeScenario
{
    [Binding]
    public class ObjectContextSetup(ScenarioContext context)
    {
        [BeforeScenario(Order = 0)]
        public void SetObjectContext(ObjectContext objectContext) => context.Set(objectContext);
    }
}