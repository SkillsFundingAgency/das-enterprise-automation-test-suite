using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
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
        private By VacancyTables => By.CssSelector("#vacancies-table tbody tr");
        private By NextPage => By.CssSelector(".page-navigation__btn.next");
        private By NoOfPagesCssSelector => By.CssSelector(".page-navigation__btn.next .counter");
        private By ReferenceNumberSearchResetCircleSymbol => By.CssSelector(".fa.fa-times-circle");

        public RAA_RecruitmentHomePage(ScenarioContext context, bool navigate) : base(context, navigate) => _context = context;
            

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
                return pageInteractionHelper.FindElements(randomElement, CloneLink).LastOrDefault();
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

            if(objectContext.IsApprenticeshipVacancyType())
            {
                return new RAA_VacancyPreviewPage(_context);
            }
            else
            {
                return new RAA_OppurtunityPreviewPage(_context);
            }
        }

        public RAA_PreviewBasePage SearchReferredVacancy()
        {
            SearchByReferenceNumber();

            if (objectContext.IsApprenticeshipVacancyType())
            {
                return new RAA_VacancyPreviewPage(_context);
            }
            else
            {
                return new RAA_OppurtunityPreviewPage(_context);
            }
        }

        private void SearchByReferenceNumber()
        {
            IWebElement func()
            {
                //_pageInteractionHelper expects some element back and fails when page is running slow and element is not available 
                var dummyElement = pageInteractionHelper.FindElements(VacancyFilter);
                var vacancies = pageInteractionHelper.FindElements(VacancyTitle);                

                foreach (var vac in vacancies)
                {
                    if (vac.Text == vacancyTitledataHelper.VacancyTitle)
                    {
                        return vac;
                    }
                }

                return dummyElement[0];
            }

            ApprenticeshipVacancyType();

            formCompletionHelper.SelectFromDropDownByValue(VacancySearchMode, "ReferenceNumber");
            formCompletionHelper.EnterText(VacancySearchText, objectContext.GetVacancyReference());
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(SearchVacancy));
            pageInteractionHelper.WaitForElementToChange(func, AttributeHelper.InnerText, vacancyTitledataHelper.VacancyTitle);
            pageInteractionHelper.WaitUntilAnyElements(ReferenceNumberSearchResetCircleSymbol);

            formCompletionHelper.ClickLinkByText(VacancyTitle, vacancyTitledataHelper.VacancyTitle);
        }

        private void SearchByVacancyTitleContains(string filter)
        {
            string filtertype(string x) => x == "New applications" ? "NewApplications" : x;
            NavigateToHome();
            ApprenticeshipVacancyType();
            formCompletionHelper.SelectFromDropDownByValue(VacancySearchMode, "VacancyTitle");
            var searchTerm = vacancyTitledataHelper.VacancyTitleDate.AddDays(-10).ToString("MMMyyyy");
            formCompletionHelper.EnterText(VacancySearchText, $"{searchTerm}_");
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(SearchVacancy));
            formCompletionHelper.ClickLinkByText(VacancyFilters, filter);
            pageInteractionHelper.WaitforURLToChange($"FilterType={filtertype(filter)}");
        }

        private void ApprenticeshipVacancyType()
        {
            if (!objectContext.IsApprenticeshipVacancyType())
            {
                formCompletionHelper.ClickLinkByText("Traineeships");
                pageInteractionHelper.WaitForElementToChange(InlineText, "Your opportunities");
            }
        }

        private IWebElement RandomElementAt(Func<IWebElement, bool> func)
        {
            randomVacancyHelper = new RandomVacancyHelper(pageInteractionHelper, formCompletionHelper, objectContext);

            return randomVacancyHelper.RandomElementAt(func, VacancyTables, VacancyTitle, NextPage, NoOfPagesCssSelector);
        }
    }   
}
