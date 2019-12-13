using NUnit.Framework;
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

        [Given(@"the Employer creates a vacancy by using a trading name")]
        public void GivenTheEmployerCreatesAVacancyByUsingATradingName()
        {
            _employerStepsHelper.CreateANewVacancy("existing-trading-name");
        }


        [Given(@"the Employer creates a vacancy by using a registered name")]
        public void GivenTheEmployerCreatesAVacancyByUsingARegisteredName()
        {
            _employerStepsHelper.CreateANewVacancy();
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

