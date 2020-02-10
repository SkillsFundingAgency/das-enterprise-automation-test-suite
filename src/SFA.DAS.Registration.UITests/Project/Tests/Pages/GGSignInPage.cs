using OpenQA.Selenium;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;
using System;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class GgSignInPage : RegistrationBasePage
    {
        protected override string PageTitle => "Sign in";
        protected override By PageHeader => By.CssSelector(".content__body h1");
        private readonly ScenarioContext _context;
        private readonly string _gatewayid;
        private readonly string _gatewaypassword;

        #region Locators
        private By UserIdInput => By.Id("userId");
        private By PasswordInput => By.Id("password");
        private By SignInButton => By.CssSelector("input.button");
        private By ErrorMessageText => By.Id("errors");
        #endregion

        public GgSignInPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _gatewayid = context.Get<ObjectContext>().GetGatewayId();
            _gatewaypassword = context.Get<ObjectContext>().GetGatewayPassword();
            VerifyPage();
        }

        public OrganisationSearchPage SignInTo()
        {
            EnterUserID().
                EnterUserPassword().
                SignIn();
            return new OrganisationSearchPage(_context);
        }

        public GgSignInPage SignInWithInvalidDetails()
        {
            EnterUserID(registrationDataHelper.RandomAlphaNumericString(10)).
                EnterUserPassword(registrationDataHelper.RandomAlphaNumericString(10)).
                SignIn();
            return this;
        }

        public string GetErrorMessage() => pageInteractionHelper.GetText(ErrorMessageText);

        private GgSignInPage EnterUserID(string id = null)
        {
            if (String.IsNullOrEmpty(id))
                id = _gatewayid;

            formCompletionHelper.EnterText(UserIdInput, id);
            return this;
        }

        private GgSignInPage EnterUserPassword(string password = null)
        {
            if (String.IsNullOrEmpty(password))
                password = _gatewaypassword;

            formCompletionHelper.EnterText(PasswordInput, password);
            return this;
        }

        private GgSignInPage SignIn()
        {
            formCompletionHelper.ClickElement(SignInButton);
            return this;
        }
    }
}