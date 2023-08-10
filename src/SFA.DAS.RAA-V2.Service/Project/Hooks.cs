using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;
using SFA.DAS.RAA_V2.Service.Project.Helpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.RAA.DataGenerator.Project.Config;

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

            var fAAConfig = _context.GetFAAConfig<FAAConfig>();

            _context.Set(new RAAV2DataHelper(fAAConfig, vacancyTitleDatahelper));

            _context.Get<ObjectContext>().SetApprenticeshipVacancyType();

            var dbConfig = _context.Get<DbConfig>();

            _context.Set(new ProviderCreateVacancySqlDbHelper(dbConfig));

            _context.Set(new RAAV2ProviderPermissionsSqlDbHelper(dbConfig));
        }
    }
}
