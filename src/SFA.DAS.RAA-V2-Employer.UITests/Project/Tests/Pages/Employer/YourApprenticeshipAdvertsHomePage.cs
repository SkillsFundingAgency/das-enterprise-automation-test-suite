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
        private readonly By CreateAnAdvertButton = By.LinkText("Create an advert");
        private By SettingsLink => By.LinkText("Settings");
        private By AdvertNotificationLink => By.LinkText("Manage your advert notifications");

        public YourApprenticeshipAdvertsHomePage(ScenarioContext context, bool navigate = false, bool gotourl = false) : base(context, navigate, gotourl) => _searchVacancyPageHelper = new SearchVacancyPageHelper(context);

        public CreateAnAdvertPage CreateAnAdvert()
        {
            AcceptCookies();
            formCompletionHelper.Click(CreateAnAdvertButton);
            return new CreateAnAdvertPage(_context);
        }

        public ManageRecruitPage SelectLiveAdvert() => _searchVacancyPageHelper.SelectLiveVacancy();

        public ManageRecruitPage SearchAdvertByReferenceNumber() => _searchVacancyPageHelper.SearchVacancyByVacancyReference();

        public EmployerVacancySearchResultPage SearchYourAdverts() => _searchVacancyPageHelper.SearchEmployerVacancy();

        public ManageYourAdvertEmailsPage GoToAdvertNotificationsPage()
        {
            NavigateToSettings();
            formCompletionHelper.ClickElement(AdvertNotificationLink);
            return new ManageYourAdvertEmailsPage(_context);
        }

        private void NavigateToSettings() => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(SettingsLink));

        private new YourApprenticeshipAdvertsHomePage AcceptCookies()
        {
            base.AcceptCookies();
            return this;
        }
    }
}
