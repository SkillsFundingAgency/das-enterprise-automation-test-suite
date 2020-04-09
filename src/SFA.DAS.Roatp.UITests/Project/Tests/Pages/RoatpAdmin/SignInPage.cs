using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class SignInPage : SignInBasePage
    {
        protected override string PageTitle => "ESFA Sign in";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly RoatpConfig _config;
        #endregion

        public SignInPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetRoatpConfig<RoatpConfig>();
        }

        public RoatpAdminHomePage SignInWithValidDetails()
        {
            SubmitValidLoginDetails(_config.AdminUserName, _config.AdminPassword);
            return new RoatpAdminHomePage(_context);
        }

        public void SignInGatewayUser()
        {
            SubmitValidLoginDetails(_config.AdminUserName, _config.AdminPassword);
        }
    }
}
