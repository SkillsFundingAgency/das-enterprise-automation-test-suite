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

        [Given(@"the Employer login using existing levy account")]
        public void GivenTheEmployerLoginUsingExistingLevyAccount()
        {
            _loginhelper.Login(_context.GetUser<LevyUser>(), true);
        }

        [Given(@"the Employer login using existing non levy account")]
        public void GivenTheEmployerLoginUsingExistingNonLevyAccount()
        {
            _loginhelper.Login(_context.GetUser<NonLevyUser>(), false);
        }

        [Given(@"the Employer login using existing eoi account")]
        public void GivenTheEmployerLoginUsingExistingEoiAccount()
        {
            _loginhelper.Login(_context.GetUser<EoiUser>(), false);
        }
    }
}
