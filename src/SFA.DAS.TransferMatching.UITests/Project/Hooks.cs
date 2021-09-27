using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TransferMatching.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        
        public Hooks(ScenarioContext context) => _context = context;
        
        [BeforeScenario(Order = 22)]
        public void SetUpDataHelpers() => _context.Set(new TMDataHelper(_context.Get<RandomDataGenerator>()));
    }
}
