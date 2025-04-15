using OpenQA.Selenium;
using SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;
using SFA.DAS.RAA.Service.Project.Helpers;
using SFA.DAS.RAA.Service.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAProvider.UITests.Project.Tests.Pages
{
    public class RecruitmentHomePage(ScenarioContext context, bool navigate = false) : InterimProviderBasePage(context, navigate)
    {
        protected override string PageTitle => "Recruitment";

        protected override string Linktext => "Recruit apprentices";

        #region Helpers and Context
        private readonly SearchVacancyPageHelper _searchVacancyPageHelper = new(context);
        #endregion

        private By ViewAllVacancy => By.CssSelector($"a[href='/{ukprn}/vacancies/?filter=All']");
        private static By RecruitmentAPIsLink => By.LinkText("Recruitment APIs");
        protected static By ReferredVacancyActionSelector => By.CssSelector("[id^='task-list']");
        private static By VacancyNotificationLink => By.LinkText("Notification settings");
        private static By SettingsLink => By.LinkText("Settings");
        private static By ApprenticeRequestsLink => By.XPath("//a[normalize-space()=‘Apprentice requests’]");
        private static By ManageFundingLink => By.XPath("//a[normalize-space()=‘Manage funding’]");
        private static By MoreLink => By.LinkText("More");



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

        public ProviderVacancySearchResultPage GoToYourAdvertFromDraftAdverts()
        {
            formCompletionHelper.ClickLinkByText("Draft vacancies");
            return new ProviderVacancySearchResultPage(context);
        }

        public ProviderVacancySearchResultPage SearchVacancyByVacancyReference() => _searchVacancyPageHelper.SearchVacancyByVacancyReference();

        public ProviderVacancySearchResultPage SearchVacancy() => _searchVacancyPageHelper.SearchProviderVacancy();

        public ManageRecruitPage SelectLiveVacancy() => _searchVacancyPageHelper.SelectLiveVacancy();

        public ReferVacancyPage SearchReferAdvertTitle()
        {
            _ = _searchVacancyPageHelper.SearchReferVacancy();

            GoToReferredVacancyCheckYourAnswersPage();

            return new ReferVacancyPage(context);
        }
        public ReferVacancyPage GoToReferredVacancyCheckYourAnswersPage()
        {
            formCompletionHelper.ClickElement(ReferredVacancyActionSelector);

            return new ReferVacancyPage(context);
        }
        public ManageYourRecruitmentEmailsPage GoToVacancytNotificationsPage()
        {
            NavigateToSettings();
            formCompletionHelper.ClickElement(VacancyNotificationLink);
            return new ManageYourRecruitmentEmailsPage(context);
        }
        private void NavigateToSettings() => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(SettingsLink));
        private void NavigateToMore() => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(MoreLink));

        public ReportsPage GoToReportsPage()
        {
            formCompletionHelper.ClickLinkByText("Reports");
            return new ReportsPage(context);
        }
        public ManageYourRecruitmentEmailsPage GoToManageYourRecruitmentEmailsPage()
        {
            formCompletionHelper.ClickLinkByText("Manage your recruitment emails");
            return new ManageYourRecruitmentEmailsPage(context);
        }

        public ApprenticeRequestsPage NavigateToApprenticeRequestsPage()
        {
            formCompletionHelper.ClickLinkByText("Apprentice requests");
            return new ApprenticeRequestsPage(context);
        }
        public ManageFundingPage NavigateToManageFundingPage()
        {
            formCompletionHelper.ClickLinkByText("Manage funding");
            return new ManageFundingPage(context);
        }
        public ManageYourApprenticePage NavigateToManageYourApprenticesPage()
        {
            formCompletionHelper.ClickLinkByText("Manage your apprentices");
            return new ManageYourApprenticePage(context);
        }
        public OrganisationsAndAgreementsPage NavigateToOrganisationsAndAgreementsPage()
        {
            NavigateToMore();
            formCompletionHelper.ClickLinkByText("Organisations and agreements");
            return new OrganisationsAndAgreementsPage(context);
        }
        public NotificationsSettingsPage GoToNotificationsSettingsPage()
        {
            NavigateToSettings();
            formCompletionHelper.ClickLinkByText("Notification settings");
            return new NotificationsSettingsPage(context);
        }
        public ChangeYourSignInDetailsPage GoToChangeYourSignInDetailsPage()
        {
            NavigateToSettings();
            formCompletionHelper.ClickLinkByText("Change your sign-in details");
            return new ChangeYourSignInDetailsPage(context);
        }
    }
}
