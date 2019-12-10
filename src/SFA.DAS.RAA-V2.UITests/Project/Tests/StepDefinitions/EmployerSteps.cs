using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerSteps
    {
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly ScenarioContext _context;
        private readonly EmployerPortalLoginHelper _loginhelper;

        public EmployerSteps(ScenarioContext context)
        {
            _context = context;
            _employerStepsHelper = new EmployerStepsHelper(context);
            _loginhelper = new EmployerPortalLoginHelper(context);
        }

        [Given(@"the Employer creates a vacancy by using a registered name")]
        public void GivenTheEmployerCreatesAVacancyByUsingARegisteredName()
        {
            _loginhelper.Login(_context.GetUser<RAAV2EmployerUser>(), true);

            _employerStepsHelper.CreateANewVacancy();
        }
    }
}
