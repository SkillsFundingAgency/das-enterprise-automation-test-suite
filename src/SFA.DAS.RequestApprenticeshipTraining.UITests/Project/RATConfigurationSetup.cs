namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project;

[Binding]
public class RatConfigurationSetup(ScenarioContext context)
{
    private readonly ConfigSection _configSection = context.Get<ConfigSection>();

    [BeforeScenario(Order = 2)]
    public void SetUpRATConfigConfiguration()
    {
        context.SetEasLoginUser(
        [
            _configSection.GetConfigSection<RatEmployerUser>(),
            _configSection.GetConfigSection<RatMultiEmployerUser>(),
            _configSection.GetConfigSection<RatCancelEmployerUser>()
        ]);
    }
}
