using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport.BeforeScenario
{
    [Binding]
    public class ObjectContextSetup
    {
        private readonly ScenarioContext _context;

        public ObjectContextSetup(ScenarioContext context)
        {
            _context = context;
        }

        [BeforeScenario(Order = 13)]
        public void SetObjectContext(ObjectContext objectContext) => _context.Set(objectContext);

    }
}
