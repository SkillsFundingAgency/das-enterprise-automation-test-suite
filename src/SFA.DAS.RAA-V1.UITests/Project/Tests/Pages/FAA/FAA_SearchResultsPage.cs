using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.FAA
{
    public class FAA_SearchResultsPage : FAA_ApprenticeSearchPage
    {
        protected override string PageTitle => "Search results";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        private readonly RAADataHelper _dataHelper;
        private RandomVacancyHelper _vacancyHelper;
        #endregion

        private By NoSearchResults => By.Id("search-no-results-title");

        private By VacancyTables => By.CssSelector(".sfa-section-bordered");

        private By AvailableVacancy => By.CssSelector(".save-vacancy .save-vacancy-link[title='Save for later']");

        private By VacancyTitle => By.CssSelector(".vacancy-link");

        private By NoOfPagesCssSelector => By.CssSelector(".page-navigation__btn.next .counter");

        private By NextPage => By.CssSelector(".page-navigation__btn.next");


        public FAA_SearchResultsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _dataHelper = context.Get<RAADataHelper>();
            VerifyPage();
        }

        public bool FoundVacancies()
        {
            return !_pageInteractionHelper.IsElementDisplayed(NoSearchResults);
        }

        public bool CanApply()
        {
            _vacancyHelper = new RandomVacancyHelper(_pageInteractionHelper, _formCompletionHelper, _dataHelper);

            _dataHelper.VacancyTitle = string.Empty;

            _vacancyHelper.RandomElementAt((x) => x.FindElements(AvailableVacancy).Any(), VacancyTables, VacancyTitle, NextPage, NoOfPagesCssSelector);

            if (string.IsNullOrEmpty(_dataHelper.VacancyTitle))
            {
                return false; 
            }

            _formCompletionHelper.ClickLinkByText(_dataHelper.VacancyTitle);

            return true;
        }
    }
}
