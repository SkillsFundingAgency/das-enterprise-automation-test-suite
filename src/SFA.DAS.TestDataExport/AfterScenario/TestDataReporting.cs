using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataExport.Helper;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.TestDataExport.AfterScenario
{
    [Binding]
    public class TestDataReporting
    {
        private readonly ScenarioContext _context;

        public TestDataReporting(ScenarioContext context) => _context = context;

        [AfterScenario(Order = 99)]
        public void CollectTestData()
        {
            var objectContext = _context.Get<ObjectContext>();

            _context.Get<TryCatchExceptionHelper>().AfterScenarioException(() => new ReportTestDataHelper().ReportTestData(objectContext.GetDirectory(), objectContext.GetAll()));
        }
    }
}