using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_LoginPage : BasePage
    {
        protected override string PageTitle => "Sign in to Apprenticeship assessment service";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly EPAOConfig _config;
        #endregion

        #region Locators
        private By EmailAddressTextBox => By.Id("Username");
        private By PasswordTextBox => By.Id("Password");
        private By SignInButton => By.ClassName("govuk-button");
        #endregion

        public AS_LoginPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _config = context.GetEPAOConfig<EPAOConfig>();
            VerifyPage();
        }

        public AS_LoggedInHomePage SignInWithValidDetails()
        {
            _formCompletionHelper.EnterText(EmailAddressTextBox, _config.EPAOAssessorLoginUsername);
            _formCompletionHelper.EnterText(PasswordTextBox, _config.EPAOAssessorLoginPassword);
            _formCompletionHelper.Click(SignInButton);
            return new AS_LoggedInHomePage(_context);
        }
    }
}
