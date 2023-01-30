using TechTalk.SpecFlow;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.TestDataExport.AfterScenario
{
    [Binding]
    public class AfterStepReporting
    {
        private readonly ScenarioContext _context;

        public AfterStepReporting(ScenarioContext context) => _context = context;

        [AfterStep(Order = 10)]
        public void AfterStep()
        {
            string StepOutcome() => _context.TestError != null ? "ERROR" : "Done";

            var stepInfo = _context.StepContext.StepInfo;

            _context.Get<ObjectContext>().SetAfterStepInformation($"-> {StepOutcome()}: {stepInfo.StepDefinitionType} {stepInfo.Text}");
        }
    }
}