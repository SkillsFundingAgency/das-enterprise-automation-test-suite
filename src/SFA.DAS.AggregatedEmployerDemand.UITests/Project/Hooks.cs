using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _context;

    public Hooks(ScenarioContext context) => _context = context;

    [BeforeScenario(Order = 21)]
    public void SetUpHelpers() => _context.Set(new AedDataHelper());
}
