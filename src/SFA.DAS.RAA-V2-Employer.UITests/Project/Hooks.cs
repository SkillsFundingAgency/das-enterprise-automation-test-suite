using SFA.DAS.FAA.UITests.Project;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project
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

        [BeforeScenario(Order = 33)]
        public void SetUpHelpers()
        {
            var random = _context.Get<RandomDataGenerator>();

            var vacancyTitleDatahelper = _context.Get<VacancyTitleDatahelper>();

            _context.Set(new RAAV2EmployerDataHelper(random, vacancyTitleDatahelper));

            _objectContext.SetApprenticeshipVacancyType();
        }
    }
}
