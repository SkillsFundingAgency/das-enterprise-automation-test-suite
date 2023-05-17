using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class CreateAnAccountToManageApprenticeshipsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Create an account to manage apprenticeships";

        protected override bool TakeFullScreenShot => false;

        #region Locators
        private By SigninLink => By.LinkText("sign in");
        private By CreateAccountLink => By.Id("service-start");
        #endregion

        public CreateAnAccountToManageApprenticeshipsPage(ScenarioContext context) : base(context) => VerifyPage();

        public StubSignInPage GoToStubSignInPage()
        {
            formCompletionHelper.ClickElement(SigninLink);
            return StubSignInPage();
        }

        public SignInPage ClickSignInLinkOnIndexPage()
        {
            formCompletionHelper.ClickElement(SigninLink);
            return new SignInPage(context);
        }

        public StubSignInPage CreateAccount()
        {
            formCompletionHelper.ClickElement(CreateAccountLink);
            return StubSignInPage();
        }

        private StubSignInPage StubSignInPage()
        {
            return new StubSignInPage(context);
        }
    }
}
