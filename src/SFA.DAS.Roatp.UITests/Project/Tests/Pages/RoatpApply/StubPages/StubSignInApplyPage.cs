using SFA.DAS.Login.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.StubPages
{
    public class StubSignInApplyPage : StubSignInBasePage
    {
        protected override string PageTitle => "Stub Authentication - Enter sign in details from Contacts table";

        public StubSignInApplyPage(ScenarioContext context) : base(context) { }

        public StubYouHaveSignedInApplyPage SubmitValidUserDetails() => GoToStubYouHaveSignedInApplyPage(objectContext.GetEmail(), objectContext.GetSignInId(), false);

        public StubYouHaveSignedInApplyPage CreateAccount(string email) => GoToStubYouHaveSignedInApplyPage(email, email, true);

        private StubYouHaveSignedInApplyPage GoToStubYouHaveSignedInApplyPage(string email, string idOrUserRef, bool newUser)
        {
            EnterLoginDetailsAndClickSignIn(email, idOrUserRef);

            return new StubYouHaveSignedInApplyPage(context, email, idOrUserRef, newUser);
        }
    }
}
