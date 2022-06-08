namespace SFA.DAS.TestDataCleanup.Project.AfterScenario;

[Binding]
public class TestDataAttachment
{
    private readonly ScenarioContext _context;

    public TestDataAttachment(ScenarioContext context) => _context = context;

    [AfterScenario(Order = 10)]
    public void AfterScenario_AttachTestData() => new ConfigurationBuilder.TestDataAttachment(_context).AddTestDataAttachment();
}