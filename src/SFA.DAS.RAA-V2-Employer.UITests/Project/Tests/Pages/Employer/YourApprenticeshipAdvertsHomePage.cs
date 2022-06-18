using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;
using SFA.DAS.RAA_V2.Service.Project.Helpers;
using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    public class YourApprenticeshipAdvertsHomePage : InterimYourApprenticeshipAdvertsHomePage
    {
        protected override string PageTitle => "Your apprenticeship adverts";

        #region Helpers and Context
        private readonly SearchVacancyPageHelper _searchVacancyPageHelper;  
        #endregion

        protected override By AcceptCookieButton => By.CssSelector("#btn-cookie-accept");
        private By CreateAnAdvertButton => By.LinkText("Create an advert");
        private By SettingsLink => By.LinkText("Settings");
        private By AdvertNotificationLink => By.LinkText("Manage your advert notifications");
        private By RecruitmentAPIsLink => By.LinkText("Recruitment APIs");

        public YourApprenticeshipAdvertsHomePage(ScenarioContext context, bool navigate = false, bool gotourl = false) : base(context, navigate, gotourl) => _searchVacancyPageHelper = new SearchVacancyPageHelper(context);


        public EmployerVacancySearchResultPage GoToYourAdvertFromDraftAdverts()
        {
            formCompletionHelper.ClickLinkByText("Draft adverts");
            return new EmployerVacancySearchResultPage(context);
        }

        public CreateAnAdvertHomePage CreateAnApprenticeshipAdvert()
        {
            AcceptCookies();
            formCompletionHelper.Click(CreateAnAdvertButton);
            return new CreateAnAdvertHomePage(context);
        }

        public CreateAnAdvertPage CreateAnAdvert()
        {
            AcceptCookies();
            formCompletionHelper.Click(CreateAnAdvertButton);
            return new CreateAnAdvertPage(context);
        }

        public ManageRecruitPage SelectLiveAdvert() => _searchVacancyPageHelper.SelectLiveVacancy();

        public EmployerVacancySearchResultPage SearchAdvertByReferenceNumber() => _searchVacancyPageHelper.SearchEmployerVacancy();

        public EmployerVacancySearchResultPage SearchYourAdverts() => _searchVacancyPageHelper.SearchEmployerVacancy();

        public ManageYourAdvertEmailsPage GoToAdvertNotificationsPage()
        {
            NavigateToSettings();
            formCompletionHelper.ClickElement(AdvertNotificationLink);
            return new ManageYourAdvertEmailsPage(context);
        }

        private void NavigateToSettings() => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(SettingsLink));

        private new YourApprenticeshipAdvertsHomePage AcceptCookies()
        {
            base.AcceptCookies();
            return this;
        }

        public GetStartedWithRecruitmentAPIsPage ClickRecruitmentAPILink()
        {
            formCompletionHelper.Click(RecruitmentAPIsLink);
            return new GetStartedWithRecruitmentAPIsPage(context);
        }
    }
}
