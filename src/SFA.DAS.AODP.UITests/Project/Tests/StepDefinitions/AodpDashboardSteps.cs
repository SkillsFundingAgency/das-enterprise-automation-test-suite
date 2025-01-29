using System.Threading.Tasks;
using SFA.DAS.AODP.UITests.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.AODP.UITests.Project.Tests.StepDefinitions
{
    [Binding, Scope(Tag = "aodp")]
    public class AodpDashboardSteps(ScenarioContext context)
    {
        private readonly AodpStepsHelper _stepsHelper = new(context);

        // private AodpLandingPage _aodpLandingPage;

        [Given(@"Navigate to aodp portal as a DfE user")]
        public void landingPage() => _stepsHelper.GoToAodpLandingPage();

    }
}