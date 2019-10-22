using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages
{
    public class RAASignInPage : BasePage
    {
        protected override By PageHeader => By.CssSelector(".pageTitle");

        protected override string PageTitle => "Sign in";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly RAAV1Config _config;
        #endregion

        private By UsernameField => By.Id("username");
        private By PasswordField => By.Id("password");
        private By SignInButton => By.XPath("//button[@value='Log in']");

        public RAASignInPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetRAAV1Config<RAAV1Config>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }


        public RAA_RecruitmentHomePage SubmitValidLoginDetails()
        {
            EnterEmailAddress()
            .EnterPassword()
            .SignIn();
            return new RAA_RecruitmentHomePage(_context);
        }

        private RAASignInPage EnterEmailAddress()
        {
            _formCompletionHelper.EnterText(UsernameField, _config.RecruitUserName);
            return this;
        }

        private RAASignInPage EnterPassword()
        {
            _formCompletionHelper.EnterText(PasswordField, _config.RecruitPassword);
            return this;
        }

        private void SignIn()
        {
            _formCompletionHelper.ClickElement(SignInButton);
        }
    }
}
