using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_RecruitmentHomePage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Recruitment home";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private RandomVacancyHelper _vacancyHelper;
        #endregion

        private By CreateANewVacancyButton => By.Id("new-vacancy-button");
        private By VacancySearchMode => By.CssSelector("#VacanciesSummary_VacanciesSummarySearch_SearchMode");
        private By VacancySearchText => By.CssSelector("#VacanciesSummary_VacanciesSummarySearch_SearchString");
        private By SearchVacancy => By.CssSelector("#search-vacancies-button");
        private By VacancyTitle => By.CssSelector(".vac-title");
        private By InlineText => By.CssSelector(".sfa-display-inline");
        private By VacancyFilters => By.CssSelector(".column-one-quarter .bold-xsmall");
        private By CloneLink => By.CssSelector("a");
        private By VacancyTables => By.CssSelector("#vacancies-table tbody tr");
        private By NextPage => By.CssSelector(".page-navigation__btn.next");
        private By NoOfPagesCssSelector => By.CssSelector(".page-navigation__btn.next .counter");
        private By ExpectedVacancyTitle => By.PartialLinkText(vacancyTitledataHelper.VacancyTitle);

        public RAA_RecruitmentHomePage(ScenarioContext context, bool navigate) : base(context, navigate)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public RAA_SearchCandidatesPage SearchCandidates()
        {
            formCompletionHelper.ClickLinkByText("Search candidates");
            return new RAA_SearchCandidatesPage(_context);
        }

        public RAA_AdministratorFunctionsPage AdministratorFunctions()
        {
            NavigateToAdmin();
            return new RAA_AdministratorFunctionsPage(_context);
        }

        public RAA_EmployerInformationPage CloneAVacancy()
        {
            SearchByVacancyTitleContains("Live");

            IWebElement element()
            {
                var randomElement = RandomElementAt((str) => !str.Text.Contains("(Applications managed externally)"));
                return _pageInteractionHelper.FindElements(randomElement, CloneLink).LastOrDefault();
            }

            formCompletionHelper.RetryClickOnException(element);

            return new RAA_EmployerInformationPage(_context);
        }

        public RAA_EmployerSelectionPage CreateANewVacancy()
        {
            formCompletionHelper.Click(CreateANewVacancyButton);
            return new RAA_EmployerSelectionPage(_context);
        }

        public RAA_ClosedVacancyPreviewPage SearchClosedVacancy()
        {
            SearchByReferenceNumber();
            return new RAA_ClosedVacancyPreviewPage(_context);
        }

        public RAA_VacancySummaryPage SearchLiveVacancy()
        {
            SearchByReferenceNumber();
            return new RAA_VacancySummaryPage(_context);
        }

        public RAA_PreviewBasePage SearchLiveVacancyWithNoApplications()
        {
            SearchByReferenceNumber();

            if (_objectContext.IsApprenticeshipVacancyType())
                return new RAA_VacancyPreviewPage(_context);
            else
                return new RAA_OppurtunityPreviewPage(_context);
        }

        public RAA_PreviewBasePage SearchReferredVacancy()
        {
            SearchByReferenceNumber();

            if (_objectContext.IsApprenticeshipVacancyType())
                return new RAA_VacancyPreviewPage(_context);
            else
                return new RAA_OppurtunityPreviewPage(_context);
        }

        private void SearchByReferenceNumber()
        {
            ApprenticeshipVacancyType();

            formCompletionHelper.SelectFromDropDownByValue(VacancySearchMode, "ReferenceNumber");
            formCompletionHelper.EnterText(VacancySearchText, _objectContext.GetVacancyReference());
            formCompletionHelper.ClickElement(() => _pageInteractionHelper.FindElement(SearchVacancy));

            _pageInteractionHelper.WaitForElementToBeClickable(ExpectedVacancyTitle);
            formCompletionHelper.Click(ExpectedVacancyTitle);
        }

        private void SearchByVacancyTitleContains(string filter)
        {
            string filtertype(string x) => x == "New applications" ? "NewApplications" : x;
            NavigateToHome();
            ApprenticeshipVacancyType();
            formCompletionHelper.SelectFromDropDownByValue(VacancySearchMode, "VacancyTitle");
            var searchTerm = vacancyTitledataHelper.VacancyTitleDate.AddDays(-10).ToString("MMMyyyy");
            formCompletionHelper.EnterText(VacancySearchText, $"{searchTerm}_");
            formCompletionHelper.ClickElement(() => _pageInteractionHelper.FindElement(SearchVacancy));
            formCompletionHelper.ClickLinkByText(VacancyFilters, filter);
            _pageInteractionHelper.WaitforURLToChange($"FilterType={filtertype(filter)}");
        }

        private void ApprenticeshipVacancyType()
        {
            if (!_objectContext.IsApprenticeshipVacancyType())
            {
                formCompletionHelper.ClickLinkByText("Traineeships");
                _pageInteractionHelper.WaitForElementToChange(InlineText, "Your opportunities");
            }
        }

        private IWebElement RandomElementAt(Func<IWebElement, bool> func)
        {
            _vacancyHelper = new RandomVacancyHelper(_pageInteractionHelper, formCompletionHelper, _objectContext);
            return _vacancyHelper.RandomElementAt(func, VacancyTables, VacancyTitle, NextPage, NoOfPagesCssSelector);
        }
    }
}
