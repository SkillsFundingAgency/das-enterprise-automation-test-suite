using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class IndexPage : RegistrationBasePage
    {
        protected override string PageTitle => "Create an account to manage apprenticeships";
        private readonly ScenarioContext _context;

        #region Locators
        private By SigninLink => By.LinkText("sign in");
        private By CreateAccountLink => By.Id("service-start");
        #endregion

        public IndexPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public SignInPage ClickSignInLinkOnIndexPage()
        {
            formCompletionHelper.ClickElement(SigninLink);
            return new SignInPage(_context);
        }

        public SetUpAsAUserPage CreateAccount()
        {
            formCompletionHelper.ClickElement(CreateAccountLink);
            return new SetUpAsAUserPage(_context);
        }
    }
}
