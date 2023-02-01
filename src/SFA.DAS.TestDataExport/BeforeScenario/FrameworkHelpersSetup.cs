using SFA.DAS.FrameworkHelpers;
using SFA.DAS.TestDataExport.Helper;
using TechTalk.SpecFlow;

namespace SFA.DAS.TestDataExport.BeforeScenario
{
    [Binding]
    public class FrameworkHelpersSetup
    {
        private readonly ScenarioContext _context;

        public FrameworkHelpersSetup(ScenarioContext context) => _context = context;

        [BeforeScenario(Order = 1)]
        public void SetUpFrameworkHelpers()
        {
            var objectContext = _context.Get<ObjectContext>();

            _context.Set(new TryCatchExceptionHelper(objectContext));

            objectContext.SetTestDataList();

            objectContext.SetRetryInformationList();
        }

        [BeforeScenario(Order = 12)]
        public void DataSetUpHelpers() => _context.Set(new ApprenticePPIDataHelper(_context.ScenarioInfo.Tags));
    }
}