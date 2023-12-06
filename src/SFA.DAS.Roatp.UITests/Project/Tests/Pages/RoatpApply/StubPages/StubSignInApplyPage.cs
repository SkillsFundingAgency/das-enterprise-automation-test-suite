using SFA.DAS.Login.Service.Project.Tests.Pages;
using SFA.DAS.Roatp.UITests.Project.Helpers.DataHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.StubPages
{
    public class StubSignInApplyPage : StubSignInBasePage
    {
        protected override string PageTitle => "Stub Authentication - Enter sign in details from Contacts table";

        public StubSignInApplyPage(ScenarioContext context) : base(context) { }

        public StubYouHaveSignedInApplyPage SubmitValidUserDetails()
        {
            var email = objectContext.GetEmail();

            var idOrUserRef = objectContext.GetPassword();

            EnterLoginDetailsAndClickSignIn(email, idOrUserRef);

            return GoToStubYouHaveSignedInApplyPage(email, idOrUserRef, false);
        }

        public StubYouHaveSignedInApplyPage CreateAccount()
        {
            var user = context.Get<RoatpApplyCreateUserDataHelpers>();

            var email = user.CreateAccountEmail;

            //var idOrUserRef = user.Password;

            return GoToStubYouHaveSignedInApplyPage(email, email, true);
        }

        private StubYouHaveSignedInApplyPage GoToStubYouHaveSignedInApplyPage(string email, string idOrUserRef, bool newUser)
        {
            EnterLoginDetailsAndClickSignIn(email, idOrUserRef);

            return new StubYouHaveSignedInApplyPage(context, email, idOrUserRef, newUser);
        }
    }
}
