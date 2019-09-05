using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class ExistingAccountsStepsHelper
    {
        private readonly EmployerPortalLoginHelper _loginHelper;
        private readonly LoginCredentialsHelper _loginCredentialsHelper;

        public ExistingAccountsStepsHelper(ScenarioContext context)
        {
            _loginCredentialsHelper = context.Get<LoginCredentialsHelper>();
            _loginHelper = new EmployerPortalLoginHelper(context);
        }

        public void Login(LoginUser loginUser, bool isLevy)
        {
            _loginCredentialsHelper.SetLoginCredentials(loginUser, isLevy);

            _loginHelper.Login(loginUser);
        }
    }
}
