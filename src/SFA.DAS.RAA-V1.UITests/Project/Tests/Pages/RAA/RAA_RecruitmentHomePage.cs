using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
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
        private readonly ObjectContext _objectContext;
        private readonly RAADataHelper _dataHelper;
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
        private By TableRows => By.CssSelector("tbody tr");
        private By NextPage => By.CssSelector(".page-navigation__btn.next");


        public RAA_RecruitmentHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _dataHelper = context.Get<RAADataHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public RAA_EmployerInformationPage CloneAVacancy()
        {
            ApprenticeshipVacancyType();
            return LiveVacancy()
                .Clone();
        }

        public RAA_EmployerSelectionPage CreateANewVacancy()
        {
            formCompletionHelper.Click(CreateANewVacancyButton);
            return new RAA_EmployerSelectionPage(_context);
        }

        public RAA_VacancySummaryPage SearchLiveVacancy()
        {
            SearchByReferenceNumber("Live");
            return GoToVacancySummary();
        }

        public RAA_VacancyPreviewPage SearchReferredVacancy()
        {
            SearchByReferenceNumber("Referred");
            return GoToVacancyPeviewPage();
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
            List<IWebElement> rows() => _pageInteractionHelper.FindElements(TableRows).ToList();
            int randomLink = 0;
            int count = 1;

            while (count < 5)
            {
                for (int i = 1; i < rows().Count; i++)
                {
                    var tablerows = rows();
                    randomLink = _dataHelper.CloneVacancy(tablerows);
                    var text = _pageInteractionHelper.GetText(() => rows()[randomLink]);
                    if (!text.Contains("(Applications managed externally)"))
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

            formCompletionHelper.ClickElement(() => _pageInteractionHelper.GetLinks(CloneLink, "Clone")[randomLink]);
            return new RAA_EmployerInformationPage(_context);
        }

        private RAA_VacancySummaryPage GoToVacancySummary()
        {
             ClickVacancy();
             return new RAA_VacancySummaryPage(_context);
        }

        private RAA_VacancyPreviewPage GoToVacancyPeviewPage()
        {
            ClickVacancy();
            return new RAA_VacancyPreviewPage(_context);
        }

        private void ClickVacancy()
        {
            formCompletionHelper.ClickElement(() => _pageInteractionHelper.GetLink(VacancyTitle, _dataHelper.VacancyTitle));
        }

        private RAA_RecruitmentHomePage LiveVacancy()
        {
            formCompletionHelper.ClickElement(() => _pageInteractionHelper.GetLink(VacancyFilters, "Live"));
            return this;
        }
    }
}
