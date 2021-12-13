using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage;
using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages
{
    public class SignInPage : SignInBasePage
    {
        #region Helpers and Context
        private readonly RAAV1Config _config;
        #endregion

        public SignInPage(ScenarioContext context) : base(context) => _config = context.GetRAAV1Config<RAAV1Config>();

        public Manage_HomePage SubmitManageLoginDetails()
        {
            SubmitValidLoginDetails(_config.ManageUserName, _config.ManagePassword);
            pageInteractionHelper.WaitforURLToChange("/dashboard");
            return new Manage_HomePage(_context);
        }

        public RAA_RecruitmentHomePage SubmitRecruitmentLoginDetails()
        {
            SubmitValidLoginDetails(_config.RecruitUserName, _config.RecruitPassword);
            return new RAA_RecruitmentHomePage(_context, false);
        }

        public RAA_InvalidCredentialsSignInPage SubmitRecruitmentInvalidLoginDetails()
        {
            SubmitValidLoginDetails($"{_config.RecruitUserName}1", $"{_config.RecruitUserName}1");
            return new RAA_InvalidCredentialsSignInPage(_context);
        }

        public RAA_ForgotMyPasswordPage ForgotMyPassword()
        {
            formCompletionHelper.ClickLinkByText("I forgot my password");
            return new RAA_ForgotMyPasswordPage(_context);
        }

        public RAA_RegistrationPage CreateNewAccount()
        {
            formCompletionHelper.ClickLinkByText("I don't have an account");
            return new RAA_RegistrationPage(_context);
        }
    }
}
