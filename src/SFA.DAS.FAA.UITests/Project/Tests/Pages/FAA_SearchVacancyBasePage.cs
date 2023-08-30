using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using SFA.DAS.RAA.DataGenerator.Project;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public abstract class FAA_SearchVacancyBasePage : FAABasePage
    {
        protected static By NoSearchResults => By.Id("search-no-results-title");
        protected static By Search => By.Id("search-button");
        protected static By VacanciesList => By.ClassName("vacancy-link");
        protected static By DisplayResults => By.Id("results-per-page");
        protected static By SortResults => By.Id("sort-results");
        protected static By DistanceFilter => By.Id("loc-within");

        protected FAA_SearchVacancyBasePage(ScenarioContext context) : base(context) { }

        protected void SearchByReferenceNumber()
        {
            pageInteractionHelper.Verify(() =>
            {
                var elementDisplayed = pageInteractionHelper.IsElementDisplayed(NoSearchResults);
                if (elementDisplayed)
                {
                     throw new Exception($"Element verification failed: No Search result found for Vacancy {objectContext.GetVacancyReference()}");
                }
                return elementDisplayed;
            }, () => formCompletionHelper.Click(Search));
        }

        protected void ChangeSortOrderToRecentlyAdded()
        {
            formCompletionHelper.SelectFromDropDownByValue(SortResults, "RecentlyAdded");
            pageInteractionHelper.WaitforURLToChange("sortType=RecentlyAdded");
        }

        public bool FoundVacancies() => !pageInteractionHelper.IsElementDisplayed(NoSearchResults);
    }
}
