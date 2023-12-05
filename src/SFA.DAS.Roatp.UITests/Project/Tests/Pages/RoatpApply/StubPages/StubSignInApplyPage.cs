using SFA.DAS.Login.Service.Project.Tests.Pages;
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

            return new StubYouHaveSignedInApplyPage(context, email, idOrUserRef, false);
        }

        public CreateAnAccountPage SelectNoCreateAccountAndContinue()
        {
            SelectRadioOptionByForAttribute("FirstTimeSignin-Yes");
            Continue();
            return new CreateAnAccountPage(context);
        }
    }
}
