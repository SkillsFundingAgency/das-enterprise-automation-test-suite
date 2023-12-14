namespace SFA.DAS.TestDataCleanup.Project.AfterScenario;

[Binding]
public class TestDataAttachment(ScenarioContext context)
{
    [AfterScenario(Order = 10)]
    public void AfterScenario_AttachTestData() => new ConfigurationBuilder.TestDataAttachment(context).AddTestDataAttachment();
}