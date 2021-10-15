using SFA.DAS.TestDataExport.Helper;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.TestDataExport.BeforeScenario
{
    [Binding]
    public class DataSetUpHelper
    {
        private readonly ScenarioContext _context;
        
        public DataSetUpHelper(ScenarioContext context) => _context = context;

        [BeforeScenario(Order = 12)]
        public void SetUpHelpers()
        {
            if (_context.TryGetValue(out RandomDataGenerator random))
            {
                _context.Set(new ApprenticePPIDataHelper(random, _context.ScenarioInfo.Tags));
            }
        }
    }
}
