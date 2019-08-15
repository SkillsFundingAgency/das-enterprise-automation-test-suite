using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class AboutYourAgreementPage : MyAccountWithPaye
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By AgreementButton => By.CssSelector("input.button");

        protected override string PageTitle => "About your agreement";

        protected override string Linktext => "Your organisations and agreements";


        public AboutYourAgreementPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public AboutYourAgreementPage(ScenarioContext context, bool navigate) : this(context)
        {
            this.navigate = navigate;
        }

        public SignAgreementPage Agreement()
        {
            ContinueWithAgreement();
            return new SignAgreementPage(_context);
        }

        private void ContinueWithAgreement()
        {
            _formCompletionHelper.ClickElement(AgreementButton);
        }
    }

    public class SignAgreementPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ProjectConfig _config;
        #endregion

        private By WantToSignRadioButton => By.CssSelector("label[for=want-to-sign]");

        private By DoNotWantToSignRadioButton => By.CssSelector("label[for=do-not-want-to-sign]");

        private By ContinueButton => By.CssSelector("input.button");

        public SignAgreementPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetProjectConfig<ProjectConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public HomePage SignAgreement()
        {
            Sign();
            return new HomePage(_context);
        }
        public HomePage DoNotSignAgreement()
        {
            DoNotSign();
            return new HomePage(_context);
        }

        private void Sign()
        {
            Continue(WantToSignRadioButton);
        }
        private void DoNotSign()
        {
            Continue(DoNotWantToSignRadioButton);
        }

        private void Continue(By by)
        {
            _formCompletionHelper.ClickElement(by);
            _formCompletionHelper.ClickElement(ContinueButton);
        }

        protected override string PageTitle => _config.RE_OrganisationName.ToUpper();
    }
}