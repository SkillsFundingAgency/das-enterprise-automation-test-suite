using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ExistingAccountSteps
    {
        private readonly ScenarioContext _context;
        private readonly EmployerPortalLoginHelper _loginhelper;

        public ExistingAccountSteps(ScenarioContext context)
        {
            _context = context;
            _loginhelper = new EmployerPortalLoginHelper(context);
        }

        [Given(@"the Employer logins using existing Levy Account")]
        public void GivenTheEmployerLoginsUsingExistingLevyAccount() => _loginhelper.Login(_context.GetUser<LevyUser>(), true);

        [Given(@"the Employer logins using existing NonLevy Account")]
        public void GivenTheEmployerLoginsUsingExistingNonLevyAccount() => _loginhelper.Login(_context.GetUser<NonLevyUser>(), false);
    }
}
