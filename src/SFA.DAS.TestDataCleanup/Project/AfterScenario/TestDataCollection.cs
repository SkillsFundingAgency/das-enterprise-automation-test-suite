using TechTalk.SpecFlow;
using SFA.DAS.TestDataExport.AfterScenario;

namespace SFA.DAS.TestDataCleanup.Project.AfterScenario
{
    [Binding]
    public class TestDataCollection
    {
        private readonly ScenarioContext _context;

        public TestDataCollection(ScenarioContext context) => _context = context;

        [AfterScenario(Order = 10)]
        public void CollectTestData() => new TestDataCollectionHelper(_context).CollectTestData();
    }
}