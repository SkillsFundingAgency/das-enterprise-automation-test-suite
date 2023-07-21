using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport.SqlHelpers;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerSteps
    {
        private readonly ScenarioContext _context;
        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;
        private readonly EmployerHomePageStepsHelper _employerHomePageStepsHelper;
        private readonly UsersSqlDataHelper _usersSqlDataHelper;
        private readonly AccountSignOutHelper accountSignOutHelper;

        public EmployerSteps(ScenarioContext context)
        {
            _context = context;
            _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);
            _employerHomePageStepsHelper = new EmployerHomePageStepsHelper(_context);
            _usersSqlDataHelper = new UsersSqlDataHelper(_context.Get<DbConfig>());
            accountSignOutHelper = new AccountSignOutHelper(context);
        }

        [Given(@"the employer user can login to EAS")]
        public void GivenTheEmployerUserCanLoginToEAS()
        {
            _employerHomePageStepsHelper.NavigateToEmployerApprenticeshipService();

            var user = _context.GetUser<LevyUser>();

            _usersSqlDataHelper.ReinstateAccountInDb(user.Username);
            
            var homePage = _employerPortalLoginHelper.Login(user, true);

            accountSignOutHelper.SignOut(homePage);
        }

        [Then(@"the employer user can login to EAS")]
        public void ThenTheEmployerUserCanLoginToEAS() => _employerHomePageStepsHelper.GotoEmployerHomePage();

        [Then(@"the employer user cannot login to EAS")]
        public void ThenTheEmployerUserCannotLoginToEAS()
        {
            var accountUnavailablePage = _employerHomePageStepsHelper.ValidateUnsuccessfulLogon();

            accountSignOutHelper.SignOut(accountUnavailablePage);
        }

    }
}
