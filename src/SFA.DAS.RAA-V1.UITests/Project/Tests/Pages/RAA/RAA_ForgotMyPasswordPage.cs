using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_ForgotMyPasswordPage : BasePage
    {
        protected override By PageHeader => By.CssSelector(".pageTitle");

        protected override string PageTitle => "Forgotten Password";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly RAAV1Config _config;
        #endregion

        private By UsernameField => By.Id("username");

        private By SubmitButton => By.CssSelector("button.btn.btn-ml");

        private By FormInfo => By.CssSelector("p.form-info");
        
        public RAA_ForgotMyPasswordPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetRAAV1Config<RAAV1Config>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public RAA_ForgotMyPasswordPage ResetPassword()
        {
            _formCompletionHelper.EnterText(UsernameField, _config.RecruitUserName);
            _formCompletionHelper.Click(SubmitButton);
            return this;
        }

        public string FormInfoText()
        {
            _pageInteractionHelper.WaitforURLToChange("/passwordRecoveryEmailSent/"); 
            return _pageInteractionHelper.GetText(FormInfo);
        }
    }
}
