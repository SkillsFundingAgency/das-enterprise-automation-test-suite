using OpenQA.Selenium;
using SFA.DAS.FAA.UITests.Project.Tests.Pages;
using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage;
using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages
{
    public class SignInPage : SignInBasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly RAAV1Config _config;
        #endregion

        public SignInPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetRAAV1Config<RAAV1Config>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public Manage_HomePage SubmitManageLoginDetails()
        {
            SubmitValidLoginDetails(_config.ManageUserName, _config.ManagePassword);

            _pageInteractionHelper.WaitforURLToChange("/dashboard");

            return new Manage_HomePage(_context);
        }

        public RAA_RecruitmentHomePage SubmitRecruitmentLoginDetails()
        {
            SubmitValidLoginDetails(_config.RecruitUserName, _config.RecruitPassword);
            return new RAA_RecruitmentHomePage(_context, false);
        }

        public RAA_InvalidCredentialsSignInPage SubmitRecruitmentInvalidLoginDetails()
        {
            SubmitValidLoginDetails($"{_config.RecruitUserName}1",$"{_config.RecruitUserName}1");
            return new RAA_InvalidCredentialsSignInPage(_context);
        }

        public RAA_ForgotMyPasswordPage ForgotMyPassword()
        {
            _formCompletionHelper.ClickLinkByText("I forgot my password");
            return new RAA_ForgotMyPasswordPage(_context);
        }

        public RAA_RegistrationPage CreateNewAccount()
        {
            _formCompletionHelper.ClickLinkByText("I don't have an account");
            return new RAA_RegistrationPage(_context);
        }
    }
}
