using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;
using SFA.DAS.RAA_V2.Service.Project.Helpers;

namespace SFA.DAS.RAA_V2.Service.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;

        public Hooks(ScenarioContext context) => _context = context;

        [BeforeScenario(Order = 33)]
        public void SetUpHelpers()
        {
            var vacancyTitleDatahelper = _context.Get<VacancyTitleDatahelper>();

            _context.Set(new RAAV2DataHelper( vacancyTitleDatahelper));

            _context.Get<ObjectContext>().SetApprenticeshipVacancyType();

            var dbConfig = _context.Get<DbConfig>();

            _context.Set(new ProviderCreateVacancySqlDbHelper(dbConfig));

            _context.Set(new RAAV2ProviderPermissionsSqlDbHelper(dbConfig));
        }
    }
}
