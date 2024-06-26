namespace SFA.DAS.FAA.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FAASteps(ScenarioContext context)
    {
        private readonly FAAStepsHelper _faaStepsHelper = new(context);

        [Then(@"the status of the Application is shown as '(successful|unsuccessful)' in FAA")]
        public void ThenTheStatusOfTheApplicationIsShownAsInFAA(string expectedStatus)
        {
            _faaStepsHelper.VerifyApplicationStatus(expectedStatus == "successful");
        }
    }
}