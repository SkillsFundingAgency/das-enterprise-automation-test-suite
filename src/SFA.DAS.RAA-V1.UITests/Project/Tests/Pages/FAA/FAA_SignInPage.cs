using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.FAA
{
    public class FAA_SignInPage : BasePage
    {
        protected override string PageTitle => "Sign in";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly RAAV1Config _config;
        #endregion

        private By UsernameField => By.CssSelector("#EmailAddress");

        private By PasswordField => By.CssSelector("#Password");

        private By SignInButton => By.CssSelector("#sign-in-button");

        public FAA_SignInPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _config = context.GetRAAV1Config<RAAV1Config>();
            VerifyPage();
        }

        public FAA_HomePage SubmitValidLoginDetails()
        {
            _formCompletionHelper.EnterText(UsernameField, _config.FAAUserName);
            _formCompletionHelper.EnterText(PasswordField, _config.FAAPassword);
            _formCompletionHelper.ClickElement(SignInButton);
            return new FAA_HomePage(_context);
        }

    }
}
