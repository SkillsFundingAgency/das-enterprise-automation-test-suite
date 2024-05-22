namespace SFA.DAS.EPAO.UITests.Project;

[Binding]
public class FAAV2ConfigurationSetup(ScenarioContext context)
{
    [BeforeScenario(Order = 2)]
    public void SetUpFAAV2Configuration()
    {
        var configSection = context.Get<ConfigSection>();

        context.SetFAAPortaluser(
        [
            configSection.GetConfigSection<FAAApplyUser>()
        ]);
    }
}