using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;
using SFA.DAS.RAA_V2.Service.Project.Helpers;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    public class RecruitmentHomePage : InterimEmployerBasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly SearchVacancyPageHelper _searchVacancyPageHelper;
        #endregion

        protected override string PageTitle => "Recruitment";

        protected override string Linktext => "Recruitment";

        public RecruitmentHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
            _searchVacancyPageHelper = new SearchVacancyPageHelper(context);
        }

        public CreateVacancyPage CreateANewVacancy()
        {
            formCompletionHelper.ClickLinkByText("Create vacancy");
            return new CreateVacancyPage(_context);
        }

        public ManageVacancyPage SelectLiveVacancy() => _searchVacancyPageHelper.SelectLiveVacancy();

        public ManageVacancyPage SearchVacancyByVacancyReference() => _searchVacancyPageHelper.SearchVacancyByVacancyReference();
    }
}
