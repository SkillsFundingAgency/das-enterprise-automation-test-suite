using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.PocProject.UITests.Project.Tests.Pages
{
    public class GGSignInPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ProjectSpecificConfig _config;
        #endregion

        private By UserIdInput => By.Id("userId");

        private By PassowrdInput => By.Id("password");

        private By SignInButton => By.CssSelector("input.button");

        public GGSignInPage(ScenarioContext context) : base(context)
        {
            _config = context.Get<ProjectSpecificConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }
        protected override string PageTitle => "Sign in";

        protected override By PageHeader => By.CssSelector(".content__body h1");

        public OrganistionSearchPage SignInTo()
        {
            EnterUserID().
                EnterUserPassword().
                SignIn();
            return new OrganistionSearchPage(_context);
        }

        private GGSignInPage EnterUserID()
        {
            _formCompletionHelper.EnterText(UserIdInput, _config.GGUserId);
            return this;
        }

        private GGSignInPage EnterUserPassword()
        {
            _formCompletionHelper.EnterText(PassowrdInput, _config.GGUserpassword);
            return this;
        }

        private GGSignInPage SignIn()
        {
            _formCompletionHelper.ClickElement(SignInButton);
            return this;
        }
    }
}