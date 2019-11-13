using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class SignInPage : SupportConsoleBasePage
    {
        protected override string PageTitle => "ESFA Sign in";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly SupportConsoleConfig _config;
        #endregion

        #region Locators
        private By UserName => By.Id("username");
        private By Password => By.Id("password");
        private By SignInButton => By.CssSelector("button.pull-left");
        protected override By PageHeader => By.XPath("//h1");
        #endregion

        public SignInPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _config = context.GetSupportConsoleConfig<SupportConsoleConfig>();
            VerifyPage();
        }

        public SearchHomePage SignInWithValidDetails()
        {
            _formCompletionHelper.EnterText(UserName, _config.SupportLoginUsername);
            _formCompletionHelper.EnterText(Password, _config.SupportLoginPassword);
            _formCompletionHelper.Click(SignInButton);
            return new SearchHomePage(_context);
        }
    }
}