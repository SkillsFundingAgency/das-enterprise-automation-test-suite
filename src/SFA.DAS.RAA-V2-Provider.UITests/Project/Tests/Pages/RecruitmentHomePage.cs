using OpenQA.Selenium;
using SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;
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

        private By ViewAllVacancy => By.CssSelector($"a[href='/{ukprn}/vacancies/?filter=All']");
        private static By RecruitmentAPIsLink => By.LinkText("Recruitment APIs");
        protected static By ReferredVacancyActionSelector => By.CssSelector("[id^='task-list']");

        public RecruitmentHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate) => _searchVacancyPageHelper = new SearchVacancyPageHelper(context);

        public ViewAllVacancyPage GoToViewAllVacancyPage()
        {
            formCompletionHelper.Click(ViewAllVacancy);
            return new ViewAllVacancyPage(context);
        }

        public GetStartedWithRecruitmentAPIsPage NavigateToRecruitmentAPIs()
        {
            formCompletionHelper.Click(RecruitmentAPIsLink);
            
            return new GetStartedWithRecruitmentAPIsPage(context);
        }

        public ProviderVacancySearchResultPage SearchVacancyByVacancyReference() => _searchVacancyPageHelper.SearchVacancyByVacancyReference();

        public ProviderVacancySearchResultPage SearchVacancy() => _searchVacancyPageHelper.SearchProviderVacancy();

        public ReferVacancyPage SearchReferAdvertTitle()
        {
            var vacancyPage = _searchVacancyPageHelper.SearchReferVacancy();
            GoToReferredVacancyCheckYourAnswersPage();

            return new ReferVacancyPage(context);
        }
        public ReferVacancyPage GoToReferredVacancyCheckYourAnswersPage()
        {
            formCompletionHelper.ClickElement(ReferredVacancyActionSelector);

            return new ReferVacancyPage(context);
        }
    }
}
