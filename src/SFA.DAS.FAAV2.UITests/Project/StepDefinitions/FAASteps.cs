namespace SFA.DAS.FAA.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FAASteps(ScenarioContext context)
    {
        [Then(@"the candidate can login")]
        public void ThenTheCandidateCanLogin()
        {
            new FAAStepsHelper(context).GoToFAAHomePage();
        }

    }
}