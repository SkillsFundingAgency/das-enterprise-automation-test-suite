using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class SignInPage : EsfaSignInPage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly EPAOAdminUser _user;
        #endregion

        public SignInPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _user = _context.GetUser<EPAOAdminUser>();
        }

        public StaffDashboardPage SignInWithValidDetails()
        {
            SubmitValidLoginDetails(_user.Username, _user.Password);
            return new StaffDashboardPage(_context);
        }
    }
}
