using SFA.DAS.Login.Service.Project.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page.StubPages
{
    public class StubSignInApprenticeAccountsPage(ScenarioContext context) : StubSignInBasePage(context)
    {
        protected override string PageTitle => StubSignInPageTitle;

        public static string StubSignInPageTitle => "Stub Authentication - Enter sign in details";

        public StubYouHaveSignedInApprenticeAccountsPage SubmitValidUserDetails(string email, string idOrUserRef)
        {
            return GoToStubYouHaveSignedInApprenticeAccountsPage(email, idOrUserRef, false);
        }

        public StubYouHaveSignedInApprenticeAccountsPage CreateAccount(string email) => GoToStubYouHaveSignedInApprenticeAccountsPage(email, $"{Guid.NewGuid()}", true);

        private StubYouHaveSignedInApprenticeAccountsPage GoToStubYouHaveSignedInApprenticeAccountsPage(string email, string idOrUserRef, bool newUser)
        {
            EnterLoginDetailsAndClickSignIn(email, idOrUserRef);

            return new StubYouHaveSignedInApprenticeAccountsPage(context, email, idOrUserRef, newUser);
        }
    }
}
