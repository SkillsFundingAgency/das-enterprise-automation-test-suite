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

        [Then(@"the Employer can create a vacancy by entering all the Optional fields")]
        public void ThenTheEmployerCanCreateAVacancyByEnteringAllTheOptionalFields()
        {
            _employerStepsHelper.CreateANewVacancy("anonymous", true);
        }

        [Then(@"the Employer can create an anonymous vacancy")]
        public void ThenTheEmployerCanCreateAnAnonymousVacancy()
        {
            _employerStepsHelper.CreateANewVacancy("anonymous");
        }

        [Given(@"the Employer creates a vacancy by using a trading name")]
        public void GivenTheEmployerCreatesAVacancyByUsingATradingName()
        {
            _employerStepsHelper.CreateANewVacancy("existing-trading-name");
        }


        [Given(@"the Employer creates a vacancy by using a registered name")]
        public void GivenTheEmployerCreatesAVacancyByUsingARegisteredName()
        {
            _employerStepsHelper.CreateANewVacancy("legal-entity-name");
        }

        [Then(@"Employer can make the application successful")]
        public void ThenEmployerCanMakeTheApplicationSuccessful()
        {
            _employerStepsHelper.ApplicantSucessful();
        }

        [Then(@"Employer can make the application unsuccessful")]
        public void ThenEmployerCanMakeTheApplicationUnsuccessful()
        {
            _employerStepsHelper.ApplicantUnSucessful();
        }
    }
}
