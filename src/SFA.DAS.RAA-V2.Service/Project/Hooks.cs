using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.RAA.DataGenerator.Project.Config;
using SFA.DAS.RAA_V2.Service.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

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

            var objectContext = _context.Get<ObjectContext>();

            _context.Set(new ProviderCreateVacancySqlDbHelper(objectContext, dbConfig));

            _context.Set(new RAAV2ProviderPermissionsSqlDbHelper(objectContext, dbConfig));
        }
    }
}
