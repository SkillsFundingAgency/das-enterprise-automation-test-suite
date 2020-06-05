using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.ConfigurationBuilder;
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

            _context.Set(new RAAV1DataHelper(random, regexHelper));

            _context.Set(new RAAV1RegistrationDataHelper(random));

            _context.Set(new RAAV1ManagedataHelper(random));

            _objectContext.SetFAARestart();

            _objectContext.SetRAAV1();
        }

        [BeforeScenario("apprenticeshipvacancy", Order = 33)]
        public void SetApprenticeshipVacancyType() => _objectContext.SetApprenticeshipVacancyType();
    }
}
