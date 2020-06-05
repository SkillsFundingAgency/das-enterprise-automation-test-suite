using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class MyAccountWithOutPayeLoginHelper : EmployerPortalLoginHelper
    {
        private readonly ScenarioContext _context;

        public MyAccountWithOutPayeLoginHelper(ScenarioContext context) : base(context) => _context = context;

        public new MyAccountWithOutPayePage ReLogin() => new SignInPage(_context).LoginToMyAccountWithOutPaye(loginCredentialsHelper.GetLoginCredentials());
    }
}
