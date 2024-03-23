using Polly;
using SFA.DAS.EarlyConnectForms.UITests.Project.Helpers;
using SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class NonUcasStudentJourneyStepDefinitions(ScenarioContext context)
    {
        private readonly EarlyConnectStepsHelper _stepsHelper = new(context);
        private GetApprenticeshipAdviserPage _getApprenticeshipAdviserPage;

        [Given(@"I am on the landing page for a region '([^']*)'")]
        public void GivenIAmOnTheLandingPageForARegion(string lepCode)
        {
           // getApprenticeshipAdviserPage.ClickGetAnAdviserButton();
        }

        [Given(@"I am on the landing page for a region")]
        public void GivenIAmOnTheLandingPageForARegion()
        {
            _stepsHelper.GoToEarlyConnectHomePage();
            _stepsHelper.GoToEarlyConnectAdvisorPage();
            _stepsHelper.GoToEarlyConnectEmailPage();

        }
    }
}
