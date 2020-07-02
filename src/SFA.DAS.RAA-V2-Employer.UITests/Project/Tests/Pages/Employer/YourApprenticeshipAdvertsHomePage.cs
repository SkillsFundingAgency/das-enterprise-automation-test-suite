using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;
using SFA.DAS.RAA_V2.Service.Project.Helpers;
using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    public class YourApprenticeshipAdvertsHomePage : InterimYourApprenticeshipAdvertsHomePage
    {
        //we removed the page title check temporary because if a known situation,
        //remove this line once the recuirment landing page is dev done.
        protected override string PageTitle => "";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly SearchVacancyPageHelper _searchVacancyPageHelper;  
        #endregion

        protected override By AcceptCookieButton => By.CssSelector("#btn-cookie-accept");
        private readonly By StartNow = By.CssSelector("[data-automation='create-vacancy']");
        private readonly By CreateAnAdvertButton = By.LinkText("Create an advert");

        public YourApprenticeshipAdvertsHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
            _searchVacancyPageHelper = new SearchVacancyPageHelper(context);
        }

        public WhatDoYouWantToCallThisAdvertPage ClickStartNow()
        {
            formCompletionHelper.Click(StartNow);
            return new WhatDoYouWantToCallThisAdvertPage(_context);
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

        public ManageVacancyPage SelectLiveAdvert() => _searchVacancyPageHelper.SelectLiveVacancy();

        public ManageVacancyPage SearchAdvertByReferenceNumber() => _searchVacancyPageHelper.SearchVacancyByVacancyReference();
    }
}
