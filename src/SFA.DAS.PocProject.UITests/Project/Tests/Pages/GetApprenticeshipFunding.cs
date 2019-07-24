using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.PocProject.UITests.Project.Tests.Pages
{
    public class GetApprenticeshipFunding : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ProjectSpecificConfig _config;
        #endregion

        private By AddPayeRadioButton => By.CssSelector("label[for=want-to-add-paye-scheme]");

        private By DoNotAddPayeRadioButton => By.CssSelector("label[for=do-not-want-to-add-paye-scheme]");

        private By ContinueButton => By.Id("submit-confirm-who-you-are-button");

        public GetApprenticeshipFunding(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.Get<ProjectSpecificConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        protected override string PageTitle => "Get apprenticeship funding";

        public void AddPaye()
        {
            SelectAddPaye().
                Continue();
        }

        public MyAccountWithOutPAYE DoNotAddPaye()
        {
            SelectDoNotAddPaye().
                Continue();
            return new MyAccountWithOutPAYE(_context);
        }

        private GetApprenticeshipFunding SelectAddPaye()
        {
            _formCompletionHelper.ClickElement(AddPayeRadioButton);
            return this;
        }

        private GetApprenticeshipFunding SelectDoNotAddPaye()
        {
            _formCompletionHelper.ClickElement(DoNotAddPayeRadioButton);
            return this;
        }

        private void Continue()
        {
            _formCompletionHelper.ClickElement(ContinueButton);
        }
    }

    public class GatewayInformPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ProjectSpecificConfig _config;
        #endregion

        private By ContinueButton => By.Id("agree_and_continue");

        private By SetItUpLaterLink => By.CssSelector("a.button-link");

        public GatewayInformPage(ScenarioContext context) : base(context)
        {
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        protected override string PageTitle => "Using your Government Gateway details";

        public GGSignInPage ContinueToGGSignIn()
        {
            Continue();
            return new GGSignInPage(_context);
        }

        private void Continue()
        {
            _formCompletionHelper.ClickElement(ContinueButton);
        }
    }

    public class GGSignInPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ProjectSpecificConfig _config;
        #endregion

        private By UserIdInput => By.Id("userId");

        private By PassowrdInput => By.Id("password");

        private By SignInButton => By.CssSelector("input.button");

        public GGSignInPage(ScenarioContext context) : base(context)
        {
            _config = context.Get<ProjectSpecificConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }
        protected override string PageTitle => "Sign in";

        protected override By PageHeader => By.CssSelector(".content__body h1");

        public void SignInTo()
        {
            EnterUserID().
                EnterUserPassword().
                SignIn();
        }

        private GGSignInPage EnterUserID()
        {
            _formCompletionHelper.EnterText(UserIdInput, _config.GGUserId);
            return this;
        }

        private GGSignInPage EnterUserPassword()
        {
            _formCompletionHelper.EnterText(PassowrdInput, _config.GGUserpassword);
            return this;
        }

        private void SignIn()
        {
            _formCompletionHelper.ClickElement(SignInButton);
        }
    }
}