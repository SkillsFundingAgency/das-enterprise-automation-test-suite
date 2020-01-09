using TechTalk.SpecFlow;

namespace SFA.DAS.ConfigurationBuilder.BeforeScenario
{
    [Binding]
    public class ObjectContextSetup
    {
        private readonly ScenarioContext _context;

        public ObjectContextSetup(ScenarioContext context)
        {
            _context = context;
        }

        [BeforeScenario(Order = 0)]
        public void SetObjectContext(ObjectContext objectContext) => _context.Set(objectContext);
    }
}
