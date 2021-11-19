using SFA.DAS.TestDataExport.Helper;
using TechTalk.SpecFlow;

namespace SFA.DAS.TestDataExport.BeforeScenario
{
    [Binding]
    public class DataSetUpHelper
    {
        private readonly ScenarioContext _context;
        
        public DataSetUpHelper(ScenarioContext context) => _context = context;

        [BeforeScenario(Order = 12)]
        public void SetUpHelpers() => _context.Set(new ApprenticePPIDataHelper(_context.ScenarioInfo.Tags));
    }
}
