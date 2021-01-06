using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public class SignInPage : ConsolidatedSupportBasePage
    {
        protected override string PageTitle => "Sign in to Apprenticeship Service Support";

        protected override By PageHeader => By.CssSelector("#signin_title");

        private By UserEmail => By.CssSelector("#user_email");
        private By UserPassword => By.CssSelector("#user_password");
        private By SignInButton => By.CssSelector("#sign-in-submit-button");

        private readonly ScenarioContext _context;
        
        public SignInPage(ScenarioContext context) : base(context)
        {
            _context = context;
            frameHelper.SwitchFrameAndAction(() => VerifyPage());
        }

        public HomePage SignIntoApprenticeshipServiceSupport()
        {
            frameHelper.SwitchFrameAndAction(() =>
            {
                formCompletionHelper.EnterText(UserEmail, config.Username);
                formCompletionHelper.EnterText(UserPassword, config.Password);
                formCompletionHelper.ClickElement(SignInButton);
            });
            return new HomePage(_context, true);
        }
    }
}
