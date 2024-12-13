namespace SFA.DAS.ProvideFeedback.APITests.Project;

[Binding]
public class BeforeScenarioHooks(ScenarioContext context)
{
    [BeforeScenario(Order = 32)]
    public void SetUpHelpers()
    {
        var objectContext = context.Get<ObjectContext>();

        context.SetRestClient(new Outer_ProviderFeedbackApiClient(objectContext, context.GetOuter_ApiAuthTokenConfig()));

    }
}
