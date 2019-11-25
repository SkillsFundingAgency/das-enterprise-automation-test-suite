using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            var random = _context.Get<RandomDataGenerator>();

            var regexHelper = _context.Get<RegexHelper>();

            _context.Set(new RAADataHelper(random, regexHelper));

            _context.Set(new RAARegistrationDataHelper(random));

            _context.Set(new ManagedataHelper(random));

            _context.Set(new FAADataHelper(random));

            _context.Set(new RandomVacancyHelper(_context.Get<PageInteractionHelper>(), _context.Get<FormCompletionHelper>(), _context.Get<RAADataHelper>()));
        }

        [BeforeScenario("apprenticeshipvacancy", Order = 33)]
        public void SetApprenticeshipVacancyType()
        {
            _objectContext.SetApprenticeshipVacancyType();
        }
    }
}
