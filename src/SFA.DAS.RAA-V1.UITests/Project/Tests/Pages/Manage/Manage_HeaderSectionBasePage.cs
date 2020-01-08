using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage
{
    public abstract class Manage_HeaderSectionBasePage : BasePage
    {

        #region Helpers and Context
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly TableRowHelper tableRowHelper;
        protected readonly RAAV1DataHelper raadataHelper;
        protected readonly VacancyTitleDatahelper vacancyTitleDataHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By AgencyHomeCss => By.Id("proposition-name");
        private By SignOutCss => By.Id("signout-link");
        private By AdminLink => By.Id("adminLink");

        public Manage_HeaderSectionBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            tableRowHelper = context.Get<TableRowHelper>();
            raadataHelper = context.Get<RAAV1DataHelper>();
            vacancyTitleDataHelper = context.Get<VacancyTitleDatahelper>();
            VerifyPage();
        }

        protected void SignOut()
        {
            AgentHome();
            formCompletionHelper.Click(SignOutCss);
        }

        protected void AgentHome()
        {
            formCompletionHelper.Click(AgencyHomeCss);
        }
        
        public Manage_AdminFunctionsPage NavigateToAdminFuntionsPage()
        {
            formCompletionHelper.Click(AdminLink);
            return new Manage_AdminFunctionsPage(_context);
        }
    }
}