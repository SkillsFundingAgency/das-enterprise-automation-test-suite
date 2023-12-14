using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SFA.DAS.PayeCreation.Project.Tests.StepDefinitions
{
    [Binding]
    public class SpecificPayeCreationSteps(ScenarioContext context)
    {
        [Given(@"I add levy declarations")]
        public void GivenIAddLevyDeclarations(Table table) => GetPayeCreationStepshelper(table).AddLevyPaye();
        
        [Given(@"I add non levy declarations")]
        public void GivenIAddNonLevyDeclarations(Table table) => GetPayeCreationStepshelper(table).AddNonLevyPaye();

        private PayeCreationStepshelper GetPayeCreationStepshelper(Table table) => new(context, table.CreateInstance<PayeDetails>());
    }
}
