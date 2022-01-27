using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataExport.Helper;
using TechTalk.SpecFlow;

namespace SFA.DAS.TestDataExport.BeforeScenario
{
    [Binding]
    public class HelpersSetup
    {
        private readonly ScenarioContext _context;

        public HelpersSetup(ScenarioContext context) => _context = context;

        [BeforeScenario(Order = 1)]
        public void FrameworkSetUpHelpers()
        {
            var objectContext = _context.Get<ObjectContext>();

            _context.Set(new TryCatchExceptionHelper(objectContext));

            objectContext.SetTestDataList();

            TestContext.Progress.WriteLine($"***************'Setting up FrameworkSetUpHelpers [BeforeScenario (Order = 1)]' DONE***************");
        }

        [BeforeScenario(Order = 12)]
        public void DataSetUpHelpers() => _context.Set(new ApprenticePPIDataHelper(_context.ScenarioInfo.Tags));
    }
}