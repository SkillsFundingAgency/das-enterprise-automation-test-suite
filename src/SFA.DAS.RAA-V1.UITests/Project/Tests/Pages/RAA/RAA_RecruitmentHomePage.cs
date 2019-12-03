using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
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
        private readonly RegexHelper _regexHelper;
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
        private By NoOfVacancy => By.CssSelector(".bold-xlarge");
        private By CloneLink => By.CssSelector("a");
        private By VacancyFilter => By.CssSelector(".column-one-quarter .vacancy-filter");
        private By VacancyStatus => By.CssSelector(".bold-xsmall");
        private By VacancyTables => By.CssSelector("#vacancies-table tbody tr");
        private By NextPage => By.CssSelector(".page-navigation__btn.next");
        private By NoOfPagesCssSelector => By.CssSelector(".page-navigation__btn.next .counter");

        public RAA_RecruitmentHomePage(ScenarioContext context, bool navigate) : base(context, navigate)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _regexHelper = context.Get<RegexHelper>();
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

        public RAA_VacancySummaryPage SelectLiveVacancyWithNewApplications()
        {
            SelectVacancy("New applications", 1, "Live");
            return new RAA_VacancySummaryPage(_context);
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
            SearchByReferenceNumber("Closed");
            return new RAA_ClosedVacancyPreviewPage(_context);
        }

        public RAA_VacancySummaryPage SearchLiveVacancy()
        {
            SearchByReferenceNumber("Live");
            return new RAA_VacancySummaryPage(_context);
        }

        public RAA_VacancyPreviewPage SearchLiveVacancyWithNoApplications()
        {
            SearchByReferenceNumber("Live");
            return new RAA_VacancyPreviewPage(_context);
        }

        public RAA_PreviewBasePage SearchReferredVacancy()
        {
            SearchByReferenceNumber("Referred");

            if (_objectContext.IsApprenticeshipVacancyType())
            {
                return new RAA_VacancyPreviewPage(_context);
            }
            else
            {
                return new RAA_OppurtunityPreviewPage(_context);
            }
        }

        private void SearchByReferenceNumber(string vacancyType)
        {
            IWebElement func()
            {
                var filters = _pageInteractionHelper.FindElements(VacancyFilter);

                foreach (var filter in filters)
                {
                    var status = _pageInteractionHelper.FindElement(filter, VacancyStatus);
                    if (status.Text == vacancyType)
                    {
                        return _pageInteractionHelper.FindElement(filter, NoOfVacancy);
                    }
                }

                return null;
            }

            ApprenticeshipVacancyType();

            formCompletionHelper.SelectFromDropDownByValue(VacancySearchMode, "ReferenceNumber");
            formCompletionHelper.EnterText(VacancySearchText, _objectContext.GetVacancyReference());
            formCompletionHelper.ClickElement(() => _pageInteractionHelper.FindElement(SearchVacancy));
            _pageInteractionHelper.WaitForElementToChange(func, AttributeHelper.InnerText, "1");
            formCompletionHelper.ClickLinkByText(VacancyTitle, dataHelper.VacancyTitle);
        }

        private void SearchByVacancyTitleContains(string filter)
        {
            string filtertype(string x) => x == "New applications" ? "NewApplications" : x;
            NavigateToHome();
            ApprenticeshipVacancyType();
            formCompletionHelper.SelectFromDropDownByValue(VacancySearchMode, "VacancyTitle");
            var searchTerm = dataHelper.VacancyTitleDate.AddDays(-1).ToString("MMMyyyy");
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

        private RAA_RecruitmentHomePage SelectVacancy(string filter, int applications, string additionalFilter = null)
        {
            SearchByVacancyTitleContains(filter);

            IWebElement element()
            {
                string[] shouldNotContain = new string[] { "(Applications managed externally)", $"_{dataHelper.VacancyTitleDateElement}_" };

                var randomElement = RandomElementAt((e) =>
                {
                    var str = e.Text;
                    return shouldNotContain.Any(x => !str.Contains(x)) && str.Contains($"{applications}\r\napplication") && (additionalFilter == null ? true : str.Contains(additionalFilter)) && _regexHelper.CheckVacancyTitle(str);
                });

                return _pageInteractionHelper.FindElement(randomElement, VacancyTitle);
            }

            formCompletionHelper.RetryClickOnException(element);

            dataHelper.VacancyTitle = _objectContext.GetVacancyTitle();

            return this;
        }

        private IWebElement RandomElementAt(Func<IWebElement, bool> func)
        {
            _vacancyHelper = new RandomVacancyHelper(_pageInteractionHelper, formCompletionHelper, _objectContext);

            return _vacancyHelper.RandomElementAt(func, VacancyTables, VacancyTitle, NextPage, NoOfPagesCssSelector);
        }
    }
}
