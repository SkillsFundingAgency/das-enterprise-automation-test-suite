using SFA.DAS.Registration.UITests.Project.Helpers;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerSteps
    {
        private readonly ScenarioContext _context;
        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;
        private readonly EmployerHomePageStepsHelper _employerHomePageStepsHelper;
        private readonly UsersSqlDataHelper _usersSqlDataHelper;

        public EmployerSteps(ScenarioContext context)
        {
            _context = context;
            _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);
            _employerHomePageStepsHelper = new EmployerHomePageStepsHelper(_context);
            _usersSqlDataHelper = new UsersSqlDataHelper(_context.Get<DbConfig>());
        }

        [Given(@"the employer user can login to EAS")]
        public void GivenTheEmployerUserCanLoginToEAS()
        {
            _employerHomePageStepsHelper.NavigateToEmployerApprenticeshipService();

            var user = _context.GetUser<LevyUser>();

            _usersSqlDataHelper.ReinstateAccountInDb(user.Username);
            
            var homePage = _employerPortalLoginHelper.Login(user, true);

            new AccountSignOutHelper(_context).SignOut(homePage);
        }

        [Then(@"the employer user can login to EAS")]
        public void ThenTheEmployerUserCanLoginToEAS() => _employerHomePageStepsHelper.GotoEmployerHomePage();

        [Then(@"the employer user cannot login to EAS")]
        public void ThenTheEmployerUserCannotLoginToEAS() 
            => StringAssert.Contains("There was a problem logging into your account", _employerHomePageStepsHelper.ValidateUnsuccessfulLogon().GetErrorFromSigninPage());
    }
}
