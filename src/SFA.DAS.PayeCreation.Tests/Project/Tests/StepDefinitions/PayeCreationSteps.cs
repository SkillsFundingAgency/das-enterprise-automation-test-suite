using TechTalk.SpecFlow;

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
}
