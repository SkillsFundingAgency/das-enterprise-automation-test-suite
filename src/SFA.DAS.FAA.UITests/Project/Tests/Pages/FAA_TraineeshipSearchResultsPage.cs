using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_TraineeshipSearchResultsPage : FAA_SearchVacancyBasePage
    {
        protected override string PageTitle => "Search results";

        public FAA_TraineeshipSearchResultsPage(ScenarioContext context) : base(context) { }

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
                    if (vacancy.Text.Contains(vacancytitledataHelper.VacancyTitle))
                        return this;
                }
                throw new Exception($"VacancyTitle Not found in VacanciesList within the '{locationPostCode}'");
            }
            else
            {
                throw new Exception($"Vacancy title: {vacancytitledataHelper.VacancyTitle} Not Found");
            }
        }
    }
}
