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
        private By SortResults => By.Id("sort-results");
        private By NationwideVacanciesText => By.Id("multiple-positions-nationwide");
        private By VacancyLink => By.LinkText(vacancytitledataHelper.VacancyTitle);
        private By DisplayResults => By.Id("results-per-page");
        private By VacanciesList => By.ClassName("vacancy-link");


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

        protected void CheckNationwideVacanciesText()
        {
            pageInteractionHelper.VerifyText(NationwideVacanciesText, faadataHelper.NationwideVacanciesText);
        }

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

        public bool CheckVacancyIsDisplayedBasedOnSearchCriteria(string postCode, string searchParameter)
        {
            if (searchParameter == "Job title" || searchParameter == "Employer" || searchParameter == "Description")
            {
                ChangeSortOrderToRecentlyAdded();
            }
            ChangeSortResultsTo50Vacancies();
            bool vacanciesFound = FoundVacancies();
            if (vacanciesFound)
            {
                List<IWebElement> vacanciesCount = pageInteractionHelper.FindElements(VacanciesList);
                foreach (var vacancy in vacanciesCount)
                {
                    if (vacancy.Text.Contains(vacancytitledataHelper.VacancyTitle))
                    {
                        return true;
                    }
                }
            }
            else
            {
                throw new Exception($"No apprenticeship found based on given search criteria '{searchParameter}' and '{postCode}'");
            }
            return false;
        }

        private void ChangeSortOrderToRecentlyAdded()
        {
            formCompletionHelper.SelectFromDropDownByValue(SortResults, "RecentlyAdded");
            pageInteractionHelper.WaitforURLToChange("sortType=RecentlyAdded");
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
