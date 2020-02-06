using OpenQA.Selenium;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

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

        private GgSignInPage EnterUserID()
        {
            formCompletionHelper.EnterText(UserIdInput, _gatewayid);
            return this;
        }

        private GgSignInPage EnterUserPassword()
        {
            formCompletionHelper.EnterText(PasswordInput, _gatewaypassword);
            return this;
        }

        private GgSignInPage SignIn()
        {
            formCompletionHelper.ClickElement(SignInButton);
            return this;
        }
    }
}