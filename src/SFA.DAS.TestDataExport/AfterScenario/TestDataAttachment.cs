namespace SFA.DAS.TestDataExport.AfterScenario;

[Binding]
public class TestDataAttachment(ScenarioContext context)
{
    [AfterScenario(Order = 99)]
    public void AfterScenario_AttachTestData() => context.Get<TryCatchExceptionHelper>().AfterScenarioException(() => new ConfigurationBuilder.TestDataAttachment(context).AddTestDataAttachment());
}