using OpenQA.Selenium;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.PAYESchemesPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class GgSignInPage : RegistrationBasePage
    {
        protected override string PageTitle => "Sign in";

        protected override bool TakeFullScreenShot => false;

        #region Locators
        private static By UserIdInput => By.Id("UserId");
        private static By PasswordInput => By.Id("Password");
        private static By SignInButton => By.XPath("//button[contains(text(),'Continue')]");
        private static By ErrorMessageText => By.XPath("(//ul[@class='govuk-list govuk-error-summary__list']/li)[1]");
        #endregion

        public GgSignInPage(ScenarioContext context) : base(context) => VerifyPage();

        public SearchForYourOrganisationPage SignInTo(int index)
        {
            EnterGateWayCredentialsAndSignIn(index);

            return new SearchForYourOrganisationPage(context);
        }

        public ConfirmPAYESchemePage EnterPayeDetailsAndContinue(int index)
        {
            var gatewaydetails = EnterGateWayCredentialsAndSignIn(index);

            return new ConfirmPAYESchemePage(context, gatewaydetails.Paye);
        }

        public GgSignInPage SignInWithInvalidDetails()
        {
            SignInTo(registrationDataHelper.InvalidGGId, registrationDataHelper.InvalidGGPassword);
            return this;
        }

        public string GetErrorMessage() => pageInteractionHelper.GetText(ErrorMessageText);

        private GatewayCreds EnterGateWayCredentialsAndSignIn(int index)
        {
            var gatewaydetails = objectContext.GetGatewayCreds(index);

            SignInTo(gatewaydetails.GatewayId, gatewaydetails.GatewayPassword);

            return gatewaydetails;
        }

        private void SignInTo(string id, string password)
        {
            formCompletionHelper.EnterText(UserIdInput, id);
            formCompletionHelper.EnterText(PasswordInput, password);
            formCompletionHelper.ClickElement(SignInButton);
        }
    }
}