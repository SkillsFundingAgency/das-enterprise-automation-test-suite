using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SFA.DAS.PayeCreation.Project.Tests.StepDefinitions
{
    [Binding]
    public class SpecificPayeCreationSteps
    {
        private readonly ScenarioContext _context;

        public SpecificPayeCreationSteps(ScenarioContext context) => _context = context;

        [Given(@"I add levy declarations")]
        public void GivenIAddLevyDeclarations(Table table) => GetPayeCreationStepshelper(table).AddLevyPaye();
        
        [Given(@"I add non levy declarations")]
        public void GivenIAddNonLevyDeclarations(Table table) => GetPayeCreationStepshelper(table).AddNonLevyPaye();

        private PayeCreationStepshelper GetPayeCreationStepshelper(Table table) => new PayeCreationStepshelper(_context, table.CreateInstance<PayeDetails>());
    }
}
