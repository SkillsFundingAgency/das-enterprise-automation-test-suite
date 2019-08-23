using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class GgSignInPage : BasePage
    {
        protected override string PageTitle => "Sign in";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ProjectConfig _config;
        private readonly string _gatewayid;
        private readonly string _gatewaypassword;
        #endregion

        private By UserIdInput => By.Id("userId");

        private By PasswordInput => By.Id("password");

        private By SignInButton => By.CssSelector("input.button");

        public GgSignInPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetProjectConfig<ProjectConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _gatewayid = context.Get<ObjectContext>().GetGatewayId();
            _gatewaypassword = context.Get<ObjectContext>().GetGatewayPassword();
            VerifyPage();
        }
        protected override By PageHeader => By.CssSelector(".content__body h1");

        public OrganisationSearchPage SignInTo()
        {
            EnterUserID().
                EnterUserPassword().
                SignIn();
            return new OrganisationSearchPage(_context);
        }

        private GgSignInPage EnterUserID()
        {
            _formCompletionHelper.EnterText(UserIdInput, _gatewayid);
            return this;
        }

        private GgSignInPage EnterUserPassword()
        {
            _formCompletionHelper.EnterText(PasswordInput, _gatewaypassword);
            return this;
        }

        private GgSignInPage SignIn()
        {
            _formCompletionHelper.ClickElement(SignInButton);
            return this;
        }
    }
}