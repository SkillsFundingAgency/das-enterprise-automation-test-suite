using SFA.DAS.API.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmploymentChecks.APITests.Project.Helpers;
using SFA.DAS.EmploymentChecks.APITests.Project.Helpers.AzureDurableFunctions;
using SFA.DAS.EmploymentChecks.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmploymentChecks.APITests.Project;

[Binding]
public class BeforeScenarioHooks(ScenarioContext context)
{
    private readonly DbConfig _dbConfig = context.Get<DbConfig>();
    private readonly EmploymentCheckProcessConfig _config = context.GetEmploymentCheckPaymentProcessConfig<EmploymentCheckProcessConfig>();

    [BeforeScenario(Order = 32)]
    public void SetUpHelpers()
    {
        var objectContext = context.Get<ObjectContext>();

        context.SetRestClient(new Outer_EmploymentCheckApiClient(objectContext, context.GetOuter_ApiAuthTokenConfig()));

        context.Set(new EmploymentCheckOrchestrationHelper(_config));
        context.Set(new Helper(context));
        context.Set(new EmploymentChecksSqlDbHelper(objectContext, _dbConfig));
    }
}