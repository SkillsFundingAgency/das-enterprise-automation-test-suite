using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;

        public Hooks(ScenarioContext context)
        {
            _context = context;
        }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            var random = _context.Get<RandomDataGenerator>();

            var regexHelper = _context.Get<RegexHelper>();

            _context.Set(new RAADataHelper(random, regexHelper));

            _context.Set(new FAADataHelper(random));
        }
    }
}
