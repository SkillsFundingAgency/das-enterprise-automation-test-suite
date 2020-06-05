using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_TraineeshipSearchResultsPage : FAA_SearchVacancyBasePage
    {
        protected override string PageTitle => "Search results";

        private By LocationTextBox => By.Id("Location");
        private By DistanceDropDown => By.Id("loc-within");

        public FAA_TraineeshipSearchResultsPage(ScenarioContext context) : base(context) { }

        public FAA_TraineeshipSearchResultsPage SearchForAVacancy(string locationPostCode, string distance)
        {
            formCompletionHelper.EnterText(LocationTextBox, locationPostCode);
            formCompletionHelper.SelectFromDropDownByText(DistanceDropDown, distance);
            formCompletionHelper.Click(Search);

            pageInteractionHelper.WaitforURLToChange(distance);
            return this;
        }

        public FAA_TraineeshipSearchResultsPage CheckVacancyIsDisplayed(string locationPostCode)
        {
            if (pageInteractionHelper.IsElementDisplayed(DisplayResults))
            {
                pageInteractionHelper.FocusTheElement(DisplayResults);
                formCompletionHelper.SelectFromDropDownByValue(DisplayResults, "50");
                pageInteractionHelper.WaitforURLToChange("resultsPerPage=50");
            }

            ChangeSortOrderToRecentlyAdded();

            List<IWebElement> vacanciesCount = pageInteractionHelper.FindElements(VacanciesList);
            if (vacanciesCount.Count > 0)
            {
                foreach (var vacancy in vacanciesCount)
                {
                    if (vacancy.Text.Contains(vacancyTitleDataHelper.VacancyTitle))
                        return this;
                }
                throw new Exception($"VacancyTitle Not found in VacanciesList within the '{locationPostCode}'");
            }
            else
            {
                throw new Exception($"Vacancy title: {vacancyTitleDataHelper.VacancyTitle} Not Found");
            }
        }
    }
}
