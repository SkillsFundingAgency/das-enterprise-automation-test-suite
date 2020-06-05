using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage
{
    public abstract class Manage_HeaderSectionBasePage : RAAV1BasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By AgencyHomeCss => By.Id("proposition-name");
        private By SignOutCss => By.Id("signout-link");
        private By AdminLink => By.Id("adminLink");

        public Manage_HeaderSectionBasePage(ScenarioContext context) : base(context) => _context = context;

        protected void SignOut()
        {
            AgentHome();
            formCompletionHelper.Click(SignOutCss);
        }

        protected void AgentHome() => formCompletionHelper.Click(AgencyHomeCss);
        
        public Manage_AdminFunctionsPage NavigateToAdminFuntionsPage()
        {
            formCompletionHelper.Click(AdminLink);
            return new Manage_AdminFunctionsPage(_context);
        }
    }
}