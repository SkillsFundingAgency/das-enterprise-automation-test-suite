using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;
using SFA.DAS.RAA.DataGenerator.Project;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public abstract class FAA_SearchVacancyBasePage : BasePage
    {
        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ObjectContext _objectContext;
        #endregion

        protected By NoSearchResults => By.Id("search-no-results-title");
        protected By Search => By.Id("search-button");

        public FAA_SearchVacancyBasePage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _objectContext = context.Get<ObjectContext>();
        }

        public bool FoundVacancies()
        {
            return !_pageInteractionHelper.IsElementDisplayed(NoSearchResults);
        }

        protected void SearchByReferenceNumber()
        {
            _pageInteractionHelper.Verify(() =>
            {
                var elementDisplayed = _pageInteractionHelper.IsElementDisplayed(NoSearchResults);
                if (elementDisplayed)
                {
                     throw new Exception($"Element verification failed: No Search result found for Vacancy {_objectContext.GetVacancyReference()}");
                }
                return elementDisplayed;
            }, () => _formCompletionHelper.Click(Search));
        }

        protected void WaitforURLToChange(string distance)
        {
            var urlChange = distance.Contains("miles") ? distance.Split(" ")[0] : "0";

            _pageInteractionHelper.WaitforURLToChange($"WithinDistance={urlChange}");
        }        

    }
}
