using OpenQA.Selenium;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.PAYESchemesPages;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class GgSignInPage : RegistrationBasePage
    {
        protected override string PageTitle => "Sign in";
        protected override By PageHeader => By.CssSelector(".content__body h1");

        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        #region Locators
        private By UserIdInput => By.Id("userId");
        private By PasswordInput => By.Id("password");
        private By SignInButton => By.CssSelector("input.button");
        private By ErrorMessageText => By.Id("errors");
        #endregion

        public GgSignInPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            VerifyPage();
        }

        public SearchForYourOrganisationPage SignInTo(int index)
        {
            EnterGateWayCredentialsAndSignIn(index);
            return new SearchForYourOrganisationPage(_context);
        }

        public ConfirmPAYESchemePage EnterPayeDetailsAndContinue(int index)
        {
            EnterGateWayCredentialsAndSignIn(index);
            return new ConfirmPAYESchemePage(_context);
        }

        public GgSignInPage SignInWithInvalidDetails()
        {
            SignInTo(registrationDataHelper.InvalidGGId, registrationDataHelper.InvalidGGPassword);
            return this;
        }

        public string GetErrorMessage() => pageInteractionHelper.GetText(ErrorMessageText);

        private void EnterGateWayCredentialsAndSignIn(int index)
        {
            var gatewaydetails = _objectContext.GetGatewayCreds(index);
            SignInTo(gatewaydetails.GatewayId, gatewaydetails.GatewayPassword);
        }

        private void SignInTo(string id, string password)
        {
            formCompletionHelper.EnterText(UserIdInput, id);
            formCompletionHelper.EnterText(PasswordInput, password);
            formCompletionHelper.ClickElement(SignInButton);
        }
    }
}