using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerFinance.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.APITests.Project.Hooks
{
    [Binding]
    public class BeforeScenarioHooks(ScenarioContext context)
    {
        private readonly DbConfig _dbConfig = context.Get<DbConfig>();
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

        [BeforeScenario(Order = 45)]
        public void SetUpHelpers()
        {
            context.Set(new EmployerFinanceSqlHelper(context.Get<ObjectContext>(), _dbConfig));

            context.Set(new EmployerAccountsSqlHelper(context.Get<ObjectContext>(), _dbConfig));

            context.SetRestClient(new Inner_EmployerFinanceApiRestClient(_objectContext, context.Get<Inner_ApiFrameworkConfig>()));

        }
    }
}