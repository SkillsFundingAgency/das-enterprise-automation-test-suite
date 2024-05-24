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
    public class Hooks(ScenarioContext context)
    {
        [BeforeScenario(Order = 33)]
        public void SetUpHelpers()
        {
            var vacancyTitleDatahelper = context.Get<VacancyTitleDatahelper>();

            var fAAConfig = context.GetFAAConfig<FAAConfig>();

            context.Set(new RAAV2DataHelper(fAAConfig, vacancyTitleDatahelper));

            context.Get<ObjectContext>().SetApprenticeshipVacancyType();

            var dbConfig = context.Get<DbConfig>();

            var objectContext = context.Get<ObjectContext>();

            context.Set(new ProviderCreateVacancySqlDbHelper(objectContext, dbConfig));

            context.Set(new RAAV2ProviderPermissionsSqlDbHelper(objectContext, dbConfig));
        }
    }
}
