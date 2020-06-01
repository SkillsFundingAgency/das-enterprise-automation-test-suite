using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using System.Collections.Generic;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ApprenticeSearchResultsPage : FAA_SearchVacancyBasePage
    {
        protected override string PageTitle => "Search results";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By NationwideVacancies => By.Id("nationwideLocationTypeLink");
        private By NationwideVacanciesText => By.Id("multiple-positions-nationwide");
        private By VacancyLink => By.LinkText(vacancyTitleDataHelper.VacancyTitle);
        private By SearchAgainLink => By.Id("start-again-link");

        public FAA_ApprenticeSearchResultsPage(ScenarioContext context) : base(context) => _context = context;

        public void CheckSortOrderAndDistance()
        {
            ClickNationwideVacancies();
            CheckSortOrder();
            CheckNationwideVacanciesText();
        }

        protected void CheckSortOrder()
        {
            pageInteractionHelper.WaitforURLToChange("LocationType=National");
            IWebElement selectElement = pageInteractionHelper.FindElement(SortResults);
            SelectElement selectedValue = new SelectElement(selectElement);
            string selectedText = selectedValue.SelectedOption.Text;
            pageInteractionHelper.VerifyText(selectedText, "Closing date");
        }

        protected void CheckNationwideVacanciesText() => pageInteractionHelper.VerifyText(NationwideVacanciesText, faaDataHelper.NationwideVacanciesText);

        protected void ClickNationwideVacancies()
        {
            pageInteractionHelper.Verify(() =>
            {
                var elementDisplayed = pageInteractionHelper.IsElementDisplayed(NoSearchResults);
                if (elementDisplayed)
                {
                    throw new Exception("No Nationwide Vacancies found");
                }
                return elementDisplayed;
            }, () => formCompletionHelper.Click(NationwideVacancies));
        }

        public FAA_ApprenticeSummaryPage SelectBrowsedVacancy()
        {
            ChangeSortOrderToRecentlyAdded();
            ChangeSortResultsTo50Vacancies();
            formCompletionHelper.Click(VacancyLink);
            return new FAA_ApprenticeSummaryPage(_context);
        }

        public FAA_ApprenticeSearchResultsPage CheckVacancyIsDisplayedBasedOnSearchCriteria(string locationPostCode, string searchCriteriaOrDistance)
        {
            if (searchCriteriaOrDistance == "Job title" || searchCriteriaOrDistance == "Employer" || searchCriteriaOrDistance == "Description")
                ChangeSortOrderToRecentlyAdded();

            ChangeSortResultsTo50Vacancies();

            bool vacanciesFound = FoundVacancies();
            if (vacanciesFound)
            {
                List<IWebElement> vacanciesCount = pageInteractionHelper.FindElements(VacanciesList);
                foreach (var vacancy in vacanciesCount)
                {
                    if (vacancy.Text.Contains(vacancyTitleDataHelper.VacancyTitle))
                        return this;
                }

                throw new Exception($"VacancyTitle Not found in VacanciesList within '{searchCriteriaOrDistance}' of '{locationPostCode}'");
            }
            else
            {
                throw new Exception($"No apprenticeship found based on given search criteria '{searchCriteriaOrDistance}' and '{locationPostCode}'");
            }
        }

        public FAA_ApprenticeSearchPage ClickOnSearchAgainLink()
        {
            formCompletionHelper.Click(SearchAgainLink);
            return new FAA_ApprenticeSearchPage(_context);
        }

        private void ChangeSortResultsTo50Vacancies()
        {
            if (pageInteractionHelper.IsElementDisplayed(DisplayResults))
            {
                pageInteractionHelper.FocusTheElement(DisplayResults);
                formCompletionHelper.SelectFromDropDownByValue(DisplayResults, "50");
                pageInteractionHelper.WaitforURLToChange("resultsPerPage=50");
            }
        }
    }
}
