using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
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

        public RAA_RecruitmentHomePage(ScenarioContext context, bool navigate) : base(context, navigate)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _regexHelper = context.Get<RegexHelper>();
        }

        public RAA_VacancyPreviewPage SelectLiveVacancyWithNoApplication()
        {
            SelectVacancy("Live", 0);
            return new RAA_VacancyPreviewPage(_context);
        }

        public RAA_VacancySummaryPage SelectLiveVacancyWithApplications()
        {
            SelectVacancy("Live", 1);
            return new RAA_VacancySummaryPage(_context);
        }

        public RAA_VacancySummaryPage SelectClosedVacancyWithApplications()
        {
            SelectVacancy("Closed", 1);
            return new RAA_VacancySummaryPage(_context);
        }

        public RAA_EmployerInformationPage CloneAVacancy()
        {
            ApprenticeshipVacancyType();

            return Clone();
        }
        
        public RAA_EmployerSelectionPage CreateANewVacancy()
        {
            formCompletionHelper.Click(CreateANewVacancyButton);
            return new RAA_EmployerSelectionPage(_context);
        }

        public RAA_ClosedVacancyPreviewPage SearchClosedVacancy()
        {
            SearchByReferenceNumber("Closed");
            ClickVacancy();
            return new RAA_ClosedVacancyPreviewPage(_context);
        }

        public RAA_VacancySummaryPage SearchLiveVacancy()
        {
            SearchByReferenceNumber("Live");
            ClickVacancy();
            return new RAA_VacancySummaryPage(_context);
        }

        public RAA_VacancyPreviewPage SearchReferredVacancy()
        {
            SearchByReferenceNumber("Referred");
            ClickVacancy();
            return new RAA_VacancyPreviewPage(_context);
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
        }

        private void SearchByVacancyTitleContains()
        {
            formCompletionHelper.SelectFromDropDownByValue(VacancySearchMode, "VacancyTitle");
            var searchTerm = dataHelper.VacancyTitleDate.AddDays(-1).ToString("MMMyyyy");
            formCompletionHelper.EnterText(VacancySearchText, $"{searchTerm}_");
            formCompletionHelper.ClickElement(() => _pageInteractionHelper.FindElement(SearchVacancy));
        }

        private void ApprenticeshipVacancyType()
        {
            if (!_objectContext.IsApprenticeshipVacancyType())
            {
                formCompletionHelper.ClickLinkByText("Traineeships");
                _pageInteractionHelper.WaitForElementToChange(InlineText, "Your opportunities");
            }
        }

        private RAA_EmployerInformationPage Clone()
        {
            int randomLink = RandomElementAt("Live", (str) => !str.Contains("(Applications managed externally)"));
            formCompletionHelper.ClickElement(() => _pageInteractionHelper.GetLinks(CloneLink, "Clone")[randomLink]);
            return new RAA_EmployerInformationPage(_context);
        }

        private void ClickVacancy()
        {
            formCompletionHelper.ClickElement(() => _pageInteractionHelper.GetLink(VacancyTitle, dataHelper.VacancyTitle));
        }

        private RAA_RecruitmentHomePage SelectVacancy(string filter, int applications)
        {
            IWebElement element()
            {
                string[] shouldNotContain = new string[] { "(Applications managed externally)", $"_{dataHelper.VacancyTitleDateElement}_" };

                int randomLink = RandomElementAt(filter, (str) => shouldNotContain.Any(x => !str.Contains(x)) && str.Contains($"{applications}\r\napplication") && _regexHelper.CheckVacancyTitle(str));

                dataHelper.VacancyTitle = _pageInteractionHelper.GetText(() => _pageInteractionHelper.FindElements(VacancyTitle)[randomLink]);

                return _pageInteractionHelper.GetLink(VacancyTitle, dataHelper.VacancyTitle);
            }

            formCompletionHelper.RetryClickOnException(element);

            return this;
        }

        private int RandomElementAt(string filter, Func<string, bool> func)
        {
            List<IWebElement> rows() => _pageInteractionHelper.FindElements(VacancyTables).ToList();
            int randomLink = 0;
            int count = 1;

            while (count < 5)
            {
                for (int i = 1; i < rows().Count; i++)
                {
                    NavigateToHome();
                    SearchByVacancyTitleContains();
                    formCompletionHelper.ClickElement(() => _pageInteractionHelper.GetLink(VacancyFilters, filter));
                    _pageInteractionHelper.WaitforURLToChange($"FilterType={filter}");
                    var tablerows = rows();
                    randomLink = dataHelper.RandomVacancy(tablerows);
                    var text = _pageInteractionHelper.GetText(() => rows()[randomLink]);
                    if (func(text))
                    {
                        break;
                    }
                    else
                    {
                        randomLink = 0;
                    }
                }
                if (randomLink != 0)
                {
                    break;
                }
                formCompletionHelper.ClickElement(() => _pageInteractionHelper.FindElement(NextPage));
                count++;
            }
            return randomLink;
        }

    }
}
