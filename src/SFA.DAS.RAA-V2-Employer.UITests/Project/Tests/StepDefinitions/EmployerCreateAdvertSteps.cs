using SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerCreateAdvertSteps
    {
        private readonly ScenarioContext _context;
        private readonly EmployerCreateVacancyStepsHelper _employerCreateVacancyStepsHelper;

        public EmployerCreateAdvertSteps(ScenarioContext context)
        {
            _context = context;
            _employerCreateVacancyStepsHelper = new EmployerCreateVacancyStepsHelper(context);
        }

        [Given(@"the Employer creates a vacancy by using a registered name")]
        public void GivenTheEmployerCreatesAVacancyByUsingARegisteredName() => _employerCreateVacancyStepsHelper.CreateANewVacancy("legal-entity-name");


        [Given(@"the Employer creates a vacancy by using a trading name")]
        public void GivenTheEmployerCreatesAVacancyByUsingATradingName() => _employerCreateVacancyStepsHelper.CreateANewVacancy("existing-trading-name");
    }
}
