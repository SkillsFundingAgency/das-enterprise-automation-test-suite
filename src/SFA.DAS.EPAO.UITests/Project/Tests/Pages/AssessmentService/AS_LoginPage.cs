using OpenQA.Selenium;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.PreamblePages;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
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

        public AS_LoggedInHomePage SignInWithValidDetails(LoginUser loginUser)
        {
            EnterLoginDetails(loginUser);
            return new AS_LoggedInHomePage(_context);
        }

        public AP_PR1_SearchForYourOrganisationPage SignInAsApplyUser(LoginUser loginUser)
        {
            EnterLoginDetails(loginUser);
            return new AP_PR1_SearchForYourOrganisationPage(_context);
        }

        public void EnterLoginDetails(LoginUser loginUser)
        {
            formCompletionHelper.EnterText(EmailAddressTextBox, loginUser.Username);
            formCompletionHelper.EnterText(PasswordTextBox, loginUser.Password);
            Continue();
        }
    }
}
