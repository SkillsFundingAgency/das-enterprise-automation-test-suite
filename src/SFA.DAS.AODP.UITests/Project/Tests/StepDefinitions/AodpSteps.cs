using TechTalk.SpecFlow;

namespace SFA.DAS.AODP.UITests.Project.Tests.StepDefinitions
{
    [Binding, Scope(Tag = "aodp")]
    public class AodpSteps(ScenarioContext context)
    {
        // private readonly AodpStepsHelper _stepsHelper = (context);

        // private AodpLandingPage _aodpLandingPage;new

        [Given(@"Navigate to aodp portal as a DfE user")]
        public void landingPage() {}

    }
}