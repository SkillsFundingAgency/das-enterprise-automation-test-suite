using SFA.DAS.EarlyConnectForms.UITests.Project.Helpers;
using SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class NonUcasStudentJourneyStepDefinitions(ScenarioContext context)
    {
        private readonly EarlyConnectStepsHelper _stepsHelper = new(context);

        [Given(@"I am on the landing page for a region '([^']*)'")]
        public void GivenIAmOnTheLandingPageForARegion(string lepCode)
        {
           
        }

        [Given(@"I am on the landing page for a region")]
        public void GivenIAmOnTheLandingPageForARegion()
        {
            _stepsHelper.GoToEarlyConnectHomePage();
            _stepsHelper.GoToEarlyConnectAdvisorPage();
            _stepsHelper.GoToEarlyConnectEmailPage();
        }

        [Given(@"I enter valid details")]
        public void GivenIEnterValidDetails()
        {
            _stepsHelper.GoToCheckEmailCodePage();
            _stepsHelper.GoToCheckEmailCodePage1();
        }
    }
}
