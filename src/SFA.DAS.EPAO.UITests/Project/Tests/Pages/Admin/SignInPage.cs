using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class SignInPage : SignInBasePage
    {
        protected override string PageTitle => "ESFA Sign in";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly EPAOAdminConfig _config;
        #endregion

        public SignInPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetEPAOAdminConfig<EPAOAdminConfig>();
        }

        public EpaoAdminHomePage SignInWithValidDetails()
        {
            SubmitValidLoginDetails(_config.AdminUserName, _config.AdminPassword);
            return new EpaoAdminHomePage(_context);
        }
    }
}
