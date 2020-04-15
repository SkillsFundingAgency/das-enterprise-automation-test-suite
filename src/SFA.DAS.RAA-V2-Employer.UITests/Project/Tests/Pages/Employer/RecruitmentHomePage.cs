using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;
using SFA.DAS.RAA_V2.Service.Project.Helpers;
using OpenQA.Selenium;

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

        protected override By AcceptCookieButton => By.CssSelector("#btn-cookie-accept");

        private readonly By StartNow = By.CssSelector("[data-automation='create-vacancy']");

        public RecruitmentHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
            _searchVacancyPageHelper = new SearchVacancyPageHelper(context);
        }

        public VacancyTitlePage ClickStartNow()
        {
            formCompletionHelper.Click(StartNow);
            return new VacancyTitlePage(_context);
        }

        public CreateVacancyPage CreateANewVacancy()
        {
            AcceptCookies();
            formCompletionHelper.ClickLinkByText("Create vacancy");
            return new CreateVacancyPage(_context);
        }

        private new RecruitmentHomePage AcceptCookies()
        {
            base.AcceptCookies();
            return this;
        }

        public ManageVacancyPage SelectLiveVacancy() => _searchVacancyPageHelper.SelectLiveVacancy();

        public ManageVacancyPage SearchVacancyByVacancyReference() => _searchVacancyPageHelper.SearchVacancyByVacancyReference();
    }
}
