using SFA.DAS.Configuration;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.BeforeScenario
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
