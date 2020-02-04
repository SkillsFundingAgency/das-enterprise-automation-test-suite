using OpenQA.Selenium;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.PreamblePages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_LoginPage : EPAO_BasePage
    {
        protected override string PageTitle => "Sign in to Apprenticeship assessment service";
        private readonly ScenarioContext _context;
        string userName, password;

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
            userName = user == "Assessor User" ? ePAOConfig.EPAOAssessorLoginUsername : ePAOConfig.EPAOManageUserLoginUsername;
            password = user == "Assessor User" ? ePAOConfig.EPAOAssessorLoginPassword : ePAOConfig.EPAOManageUserLoginPassword;

            EnterLoginDetails(userName, password);
            return new AS_LoggedInHomePage(_context);
        }

        public AP_PR1_SearchForYourOrganisationPage SignInAsApplyUser()
        {
            userName = ePAOConfig.EPAOApplyUserLoginUsername;
            password = ePAOConfig.EPAOApplyUserLoginPassword;
            EnterLoginDetails(userName, password);
            return new AP_PR1_SearchForYourOrganisationPage(_context);
        }

        public void EnterLoginDetails(string userName, string password)
        {
            formCompletionHelper.EnterText(EmailAddressTextBox, userName);
            formCompletionHelper.EnterText(PasswordTextBox, password);
            Continue();
        }
    }
}
