using OpenQA.Selenium;
using SFA.DAS.ProviderLogin.Service.Pages;
using SFA.DAS.RAA_V2.Service.Project.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages
{
    public class RecruitmentHomePage : InterimProviderBasePage
    {
        protected override string PageTitle => "Recruitment";

        protected override string Linktext => "Recruit apprentices";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly SearchVacancyPageHelper _searchVacancyPageHelper;
        #endregion

        private By CreateVacancyLink => By.CssSelector("a[data-automation='create-vacancy']");

        public RecruitmentHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _searchVacancyPageHelper = new SearchVacancyPageHelper(context);
        }

        public SelectEmployersPage CreateVacancy()
        {
            _formCompletionHelper.Click(CreateVacancyLink);
            return new SelectEmployersPage(_context);
        }

        public ManageVacancyPage SelectVacancy() => _searchVacancyPageHelper.SelectVacancy();

        public ManageVacancyPage SearchAnyVacancy() => _searchVacancyPageHelper.SearchAnyVacancy();
    }
}
