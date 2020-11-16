using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages.AR_Admin
{
    public class AR_SignInPage : EsfaSignInPage
    {
        #region Helpers and Context
        private readonly ApprenticeRedundancyConfig _config;
        #endregion

        public AR_SignInPage(ScenarioContext context) : base(context) => _config = context.GetARConfig<ApprenticeRedundancyConfig>();

        public void SubmitValidLoginDetails() => SubmitValidLoginDetails(_config.AR_AdminUserName, _config.AR_AdminPassword);
    }
}

