using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.FlexiPayments.E2ETests.Project
{
    [Binding]
    public class BeforeScenarioHooks(ScenarioContext context)
    {
        private readonly ConfigSection _configSection = context.Get<ConfigSection>();

        [BeforeScenario(Order = 40)]
        public void SetUpHelpers()
        {
            var dbConfig = context.Get<DbConfig>();

            var objectContext = context.Get<ObjectContext>();

            context.Set(new EarningsSqlDbHelper(objectContext, dbConfig));

            context.Set(new ApprenticeshipsSqlDbHelper(objectContext, dbConfig));

            objectContext.SetFlexiPaymentsTestDataList();

            context.SetPaymentsSimplificationConfig(_configSection.GetConfigSection<PaymentsSimplificationConfig>());
        }
    }
}
