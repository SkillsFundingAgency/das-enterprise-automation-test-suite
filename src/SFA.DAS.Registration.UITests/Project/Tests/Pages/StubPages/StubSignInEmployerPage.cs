using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages
{
    public class StubSignInEmployerPage(ScenarioContext context) : StubSignInBasePage(context)
    {
        protected override string PageTitle => "Stub Authentication - Enter sign in details";

        public StubYouHaveSignedInEmployerPage Register(string email = null)
        {
            email = string.IsNullOrEmpty(email) ? objectContext.GetRegisteredEmail() : email;

            EnterLoginDetailsAndClickSignIn(email, email);

            return GoToStubYouHaveSignedInPage(email, email, true);
        }

        public StubYouHaveSignedInEmployerPage Login(EasAccountUser loginUser) => Login(loginUser.Username, loginUser.IdOrUserRef);

        public StubYouHaveSignedInEmployerPage Login(string Username, string IdOrUserRef)
        {
            EnterLoginDetailsAndClickSignIn(Username, IdOrUserRef);

            return GoToStubYouHaveSignedInPage(Username, IdOrUserRef, false);
        }

        private StubYouHaveSignedInEmployerPage GoToStubYouHaveSignedInPage(string username, string idOrUserRef, bool newUser) => new(context, username, idOrUserRef, newUser);
    }
}
