using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_LoginPage : EPAO_BasePage
    {
        protected override string PageTitle => "Sign in to Apprenticeship assessment service";
        private readonly ScenarioContext _context;

        #region Locators
        private By EmailAddressTextBox => By.Id("Username");
        private By PasswordTextBox => By.Id("Password");
        #endregion

        public AS_LoginPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_LoggedInHomePage SignInWithValidDetails(string user)
        {
            string userName = user == "Assessor User" ? ePAOConfig.EPAOAssessorLoginUsername : ePAOConfig.EPAOManageUserLoginUsername;
            string password = user == "Assessor User" ? ePAOConfig.EPAOAssessorLoginPassword : ePAOConfig.EPAOManageUserLoginPassword;

            formCompletionHelper.EnterText(EmailAddressTextBox, userName);
            formCompletionHelper.EnterText(PasswordTextBox, password);
            Continue();
            return new AS_LoggedInHomePage(_context);
        }
    }
}
