using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using SFA.DAS.RAA.DataGenerator.Project;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public abstract class FAA_SearchVacancyBasePage : FAABasePage
    {
        protected By NoSearchResults => By.Id("search-no-results-title");
        protected By Search => By.Id("search-button");

        public FAA_SearchVacancyBasePage(ScenarioContext context) : base(context) { }
    
        public bool FoundVacancies() => !pageInteractionHelper.IsElementDisplayed(NoSearchResults);

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

        protected void WaitforURLToChange(string distance)
        {
            var urlChange = distance.Contains("miles") ? distance.Split(" ")[0] : "0";

            pageInteractionHelper.WaitforURLToChange($"WithinDistance={urlChange}");
        }        
    }
}
