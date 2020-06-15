using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class SignInPage : SignInBasePage
    {
        protected override string PageTitle => "ESFA Sign in";

        #region Helpers and Context
        private readonly RoatpConfig _config;
        #endregion

        public SignInPage(ScenarioContext context) : base(context) => _config = context.GetRoatpConfig<RoatpConfig>();

        public void SubmitValidLoginDetails() => SubmitValidLoginDetails(_config.AdminUserName, _config.AdminPassword);
    }
}
