using OpenQA.Selenium;
using SFA.DAS.ProviderLogin.Service.Pages;
using SFA.DAS.RAA_V2.Service.Project.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAT_Provider.UITests.Project.Tests.Pages
{
    public class TraineeshipRecruitHomePage : InterimProviderBasePage
    {
        protected override string PageTitle => "";

        protected override string Linktext => "Recruit apprentices";

        #region Helpers and Context
        private readonly SearchVacancyPageHelper _searchVacancyPageHelper;
        #endregion

        private By ViewAllVacancy => By.CssSelector($"a[href='/{ukprn}/vacancies/?filter=All']");
        protected static By RecruitTraineesLink => By.LinkText("Recruit trainees");
        protected By ReferredVacancyActionSelector => By.CssSelector("[id^='task-list']");

        public TraineeshipRecruitHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate) => _searchVacancyPageHelper = new SearchVacancyPageHelper(context);

        public ViewAllVacancyPage GoToViewAllVacancyPage()
        {
                formCompletionHelper.Click(ViewAllVacancy);
                return new ViewAllVacancyPage(context);
        }
        public TraineeshipRecruitHomePage GoToTraineeshipHomePage()
        {
            formCompletionHelper.ClickElement(RecruitTraineesLink);

            //ClickIfPirenIsDisplayed();

            return new TraineeshipRecruitHomePage(context);
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
