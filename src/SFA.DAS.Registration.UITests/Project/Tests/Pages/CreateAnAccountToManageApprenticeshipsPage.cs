using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class CreateAnAccountToManageApprenticeshipsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Create an account to manage apprenticeships";

        protected override bool TakeFullScreenShot => false;

        private readonly ScenarioContext _context;

        #region Locators
        private By SigninLink => By.LinkText("sign in");
        private By CreateAccountLink => By.Id("service-start");
        #endregion

        public CreateAnAccountToManageApprenticeshipsPage(ScenarioContext context) : base(context)
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
