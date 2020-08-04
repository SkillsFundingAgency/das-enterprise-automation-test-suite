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
        private readonly ScenarioContext _context;
        private readonly SearchVacancyPageHelper _searchVacancyPageHelper;  
        #endregion

        protected override By AcceptCookieButton => By.CssSelector("#btn-cookie-accept");
        private readonly By CreateAnAdvertButton = By.LinkText("Create an advert");

        public YourApprenticeshipAdvertsHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
            _searchVacancyPageHelper = new SearchVacancyPageHelper(context);
        }

        public CreateAnAdvertPage CreateAnAdvert()
        {
            AcceptCookies();
            formCompletionHelper.Click(CreateAnAdvertButton);
            return new CreateAnAdvertPage(_context);
        }

        private new YourApprenticeshipAdvertsHomePage AcceptCookies()
        {
            base.AcceptCookies();
            return this;
        }

        public ManageRecruitPage SelectLiveAdvert() => _searchVacancyPageHelper.SelectLiveVacancy();

        public ManageRecruitPage SearchAdvertByReferenceNumber() => _searchVacancyPageHelper.SearchVacancyByVacancyReference();
    }
}
