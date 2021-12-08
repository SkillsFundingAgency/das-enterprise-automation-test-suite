using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SFA.DAS.PayeCreation.Project.Tests.StepDefinitions
{
    [Binding]
    public class PayeCreationSteps
    {
        private readonly PayeCreationStepshelper _payeCreationStepshelper;

        public PayeCreationSteps(ScenarioContext context)
        {
            var payeConfig = context.GetPayeCreationConfig();
            
            var payeDetails = new PayeDetails
            {
                EmpRef = string.Empty,
                Duration = payeConfig.Duration,
                LevyPerMonth = payeConfig.LevyPerMonth,
                NoOfLevy = payeConfig.NoOfLevy,
                NoOfNonLevy = payeConfig.NoOfNonLevy
            };

            _payeCreationStepshelper = new PayeCreationStepshelper(context, payeDetails);
        }

        [Given(@"I add non levy declarations")]
        public void GivenIAddNonLevyDeclarations() => _payeCreationStepshelper.AddNonLevyPaye();

        [Given(@"I add levy declarations")]
        public void GivenIAddLevyDeclarations() => _payeCreationStepshelper.AddLevyPaye();
    }

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
