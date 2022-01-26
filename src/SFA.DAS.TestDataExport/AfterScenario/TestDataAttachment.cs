using TechTalk.SpecFlow;
using SFA.DAS.TestDataExport.Helper;

namespace SFA.DAS.TestDataExport.AfterScenario
{
    [Binding]
    public class TestDataAttachment
    {
        private readonly ScenarioContext _context;

        public TestDataAttachment(ScenarioContext context) => _context = context;

        [AfterScenario(Order = 99)]
        public void AfterScenario_AttachTestData() => _context.Get<TryCatchExceptionHelper>().AfterScenarioException(() => new ConfigurationBuilder.TestDataAttachment(_context).AddTestDataAttachment());
    }
}