namespace SFA.DAS.RAA.APITests.Project;

[Binding]
public class BeforeScenarioHooks(ScenarioContext context)
{
    [BeforeScenario(Order = 32)]
    public void SetUpHelpers()
    {
        var objectContext = context.Get<ObjectContext>();

        context.SetRestClient(new Outer_RecruitApiClient(objectContext, context.GetOuter_ApiAuthTokenConfig()));

        context.Set(new EmployerLegalEntitiesSqlDbHelper(objectContext, context.Get<DbConfig>()));
    }
}
