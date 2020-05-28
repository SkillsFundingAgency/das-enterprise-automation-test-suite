using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_TraineeshipSearchResultsPage : FAA_SearchVacancyBasePage
    {
        protected override string PageTitle => "Search results";

        #region Helpers and Context
        private readonly ScenarioContext _context;        
        #endregion

        private By Location => By.Id("Location");
        private By ReferenceNumber => By.Id("ReferenceNumber");
        private By Distance => By.Id("loc-within");
        private By SortOrder => By.Id("sort-results");
        private By VacanciesList => By.ClassName("vacancy-link");
        private By DisplayResults => By.Id("results-per-page");

        public FAA_TraineeshipSearchResultsPage(ScenarioContext context) : base(context) => _context = context;

        public FAA_TraineeshipSearchResultsPage SearchForAVacancy(string location, string distance)
        {
            formCompletionHelper.EnterText(Location, location);

            formCompletionHelper.SelectFromDropDownByText(Distance, distance);

            formCompletionHelper.Click(Search);

            WaitforURLToChange(distance);
            formCompletionHelper.SelectFromDropDownByValue(SortOrder, "RecentlyAdded");
            if (pageInteractionHelper.IsElementDisplayed(DisplayResults))
            {
                pageInteractionHelper.FocusTheElement(DisplayResults);
                formCompletionHelper.SelectFromDropDownByValue(DisplayResults, "50");
                pageInteractionHelper.WaitforURLToChange("resultsPerPage=50");
            }            

            List<IWebElement> vacanciesCount = pageInteractionHelper.FindElements(VacanciesList);
            
            bool status = false;
            
            foreach (var vacancy in vacanciesCount)
            {
                if(vacancy.Text.Contains(vacancytitledataHelper.VacancyTitle))
                {
                    status = true;
                    break;
                }
            }
            if(!status)
            {
                throw new Exception($"Vacancy title: {vacancytitledataHelper.VacancyTitle} Not Found");
            }
            return new FAA_TraineeshipSearchResultsPage(_context);
        }
    }
}
