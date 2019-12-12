using SFA.DAS.RAA_V2.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerSteps
    {
        private readonly EmployerStepsHelper _employerStepsHelper;

        public EmployerSteps(ScenarioContext context)
        {
            _employerStepsHelper = new EmployerStepsHelper(context);
        }

        [Given(@"the Employer creates a vacancy by using a registered name")]
        public void GivenTheEmployerCreatesAVacancyByUsingARegisteredName()
        {
            _employerStepsHelper.CreateANewVacancy();
        }

        [Then(@"Employer is able to view and make the application '(.*)'")]
        public void ThenEmployerIsAbleToViewAndMakeTheApplication(string status)
        {
            _employerStepsHelper.ApplicantSucessful();
        }
    }
}

