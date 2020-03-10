using SFA.DAS.EPAO.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project
{
    [Binding]
    class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly EPAOConfig _config;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _config = context.GetEPAOConfig<EPAOConfig>();
        }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            _context.Set(new EPAOSqlDataHelper(_config));

            _context.Set(new EPAODataHelper(_context.Get<RandomDataGenerator>()));
        }
    }
}
