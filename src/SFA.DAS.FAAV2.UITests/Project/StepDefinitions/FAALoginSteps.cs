namespace SFA.DAS.FAAV2.UITests.Project.StepDefinitions
{
    [Binding]
    public class FAALoginSteps(ScenarioContext context)
    {
        [Then(@"the candidate can login in to faav2")]
        public void TheCandidateCanLoginInToFaav()
        {
            new FAAStepsHelper(context).GoToFAAHomePage();
        }
    }
}