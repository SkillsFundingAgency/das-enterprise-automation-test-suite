using OpenQA.Selenium;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages
{
    public class StubSignInPage : VerifyBasePage
    {
        protected override string PageTitle => "Stub Authentication - Enter sign in details";

        protected override bool TakeFullScreenShot => false;

        #region Locators
        private static By IdInput => By.CssSelector(".govuk-input[id='Id']");
        private static By EmailInput => By.CssSelector(".govuk-input[id='Email']");
        private static By SignInButton => By.CssSelector(".govuk-button[type='submit']");
        #endregion

        public StubSignInPage(ScenarioContext context) : base(context) => VerifyPage();

        public StubYouHaveSignedInPage Register(string email = null)
        {
            email = string.IsNullOrEmpty(email) ? objectContext.GetRegisteredEmail() : email;

            EnterLoginDetailsAndClickSignIn(email, email);

            return GoToStubYouHaveSignedInPage(email, email, true);
        }

        public StubYouHaveSignedInPage Login(EasAccountUser loginUser) => Login(loginUser.Username, loginUser.IdOrUserRef);

        public StubYouHaveSignedInPage Login(string Username, string IdOrUserRef)
        {
            EnterLoginDetailsAndClickSignIn(Username, IdOrUserRef);

            return GoToStubYouHaveSignedInPage(Username, IdOrUserRef, false);
        }

        private void EnterLoginDetailsAndClickSignIn(string email, string userref)
        {
            formCompletionHelper.EnterText(IdInput, userref);
            formCompletionHelper.EnterText(EmailInput, email);
            formCompletionHelper.ClickElement(SignInButton);
        }

        private StubYouHaveSignedInPage GoToStubYouHaveSignedInPage(string username, string idOrUserRef, bool newUser) => new(context, username, idOrUserRef, newUser);
    }
}
