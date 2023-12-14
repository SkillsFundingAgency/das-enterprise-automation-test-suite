using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using System.Collections.Generic;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ApprenticeSearchResultsPage(ScenarioContext context) : FAA_SearchVacancyBasePage(context)
    {
        protected override string PageTitle => "Search results";

        private static By NationwideVacancies => By.Id("nationwideLocationTypeLink");
        private By VacancyLink => By.LinkText(vacancyTitleDataHelper.VacancyTitle);
        private static By SearchAgainLink => By.Id("start-again-link");

        public void CheckSortOrderAndDistance()
        {
            CheckSortOrder();
            CheckNationwideVacanciesText();
        }

        protected void CheckSortOrder()
        {
            pageInteractionHelper.VerifyText(formCompletionHelper.GetSelectedOption(SortResults), "Distance");
        }

        protected void CheckNationwideVacanciesText() => pageInteractionHelper.VerifyText(formCompletionHelper.GetSelectedOption(DistanceFilter), "England");

        protected void ClickNationwideVacancies()
        {
            pageInteractionHelper.Verify(() =>
            {
                var elementDisplayed = pageInteractionHelper.IsElementDisplayed(NoSearchResults);
                if (elementDisplayed)
                {
                    throw new Exception("Element verification failed: No Nationwide Vacancies found");
                }
                return elementDisplayed;
            }, () => formCompletionHelper.Click(NationwideVacancies));
        }

        public FAA_ApprenticeSummaryPage SelectBrowsedVacancy()
        {
            ChangeSortOrderToRecentlyAdded();
            ChangeSortResultsTo50Vacancies();
            formCompletionHelper.Click(VacancyLink);
            return new FAA_ApprenticeSummaryPage(context);
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
            return new FAA_ApprenticeSearchPage(context);
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
