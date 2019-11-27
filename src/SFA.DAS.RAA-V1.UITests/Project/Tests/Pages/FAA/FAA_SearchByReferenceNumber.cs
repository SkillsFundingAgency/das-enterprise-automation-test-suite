using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.FAA
{
    public abstract class FAA_SearchByReferenceNumber : BasePage
    {
        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion

        protected By NoSearchResults => By.Id("search-no-results-title");
        protected By Search => By.Id("search-button");

        public FAA_SearchByReferenceNumber(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
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
    }
}
