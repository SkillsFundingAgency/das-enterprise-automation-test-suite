using OpenQA.Selenium;
using SFA.DAS.ProviderLogin.Service.Pages;
using SFA.DAS.RAA_V2.Service.Project.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages
{
    public class RecruitmentHomePage : InterimProviderBasePage
    {
        protected override string PageTitle => "Recruitment";

        protected override string Linktext => "Recruit apprentices";

        #region Helpers and Context
        private readonly SearchVacancyPageHelper _searchVacancyPageHelper;
        #endregion

        private By CreateVacancyLink => By.CssSelector("a[data-automation='create-vacancy']");

        private By ViewAllVacancy => By.CssSelector($"a[href='/{ukprn}/vacancies/?filter=All']");
        private By RecruitmentAPIsLink => By.LinkText("Recruitment APIs");


        public RecruitmentHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate) => _searchVacancyPageHelper = new SearchVacancyPageHelper(context);

        public ViewAllVacancyPage GoToViewAllVacancyPage()
        {
            formCompletionHelper.Click(ViewAllVacancy);
            return new ViewAllVacancyPage(context);
        }

        public SelectEmployersPage CreateVacancy()
        {
            formCompletionHelper.Click(CreateVacancyLink);
            return new SelectEmployersPage(context);
        }

        public GetStartedWithRecruitmentAPIsPage NavigateToRecruitmentAPIs()
        {
            formCompletionHelper.Click(RecruitmentAPIsLink);
            
            ClickIfPirenIsDisplayed();
            
            return new GetStartedWithRecruitmentAPIsPage(context);
        }

        public ManageRecruitPage SelectLiveVacancy() => _searchVacancyPageHelper.SelectLiveVacancy();

        public ManageRecruitPage SearchVacancyByVacancyReference() => _searchVacancyPageHelper.SearchVacancyByVacancyReference();

        public ProviderVacancySearchResultPage SearchVacancy() => _searchVacancyPageHelper.SearchProviderVacancy();

        public ReferVacancyPage SearchReferVacancy() => _searchVacancyPageHelper.SearchReferVacancy();
    }
}
