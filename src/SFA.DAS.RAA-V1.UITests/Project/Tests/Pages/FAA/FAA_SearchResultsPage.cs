using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.FAA
{
    public class FAA_SearchResultsPage : BasePage
    {
        protected override string PageTitle => "Search results";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        private readonly RAADataHelper _dataHelper;
        private readonly RandomVacancyHelper _vacancyHelper;
        #endregion

        private By NoSearchResults => By.Id("search-no-results-title");

        private By VacancyTables => By.CssSelector(".sfa-section-bordered");

        private By VacancyStatus => By.CssSelector(".save-vacancy");

        private By VacancyTitle => By.CssSelector(".vacancy-link");

        private By NoOfPagesCssSelector => By.CssSelector(".page-navigation__btn.next .counter");

        private By NextPage => By.CssSelector(".page-navigation__btn.next");


        public FAA_SearchResultsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _dataHelper = context.Get<RAADataHelper>();
            _vacancyHelper = context.Get<RandomVacancyHelper>();
            VerifyPage();
        }

        public bool FoundVacancies()
        {
            return !_pageInteractionHelper.IsElementDisplayed(NoSearchResults);
        }

        public bool CanApply()
        {

            IWebElement element()
            {
                return _vacancyHelper.RandomElementAt((x) => x.FindElements(VacancyStatus).FirstOrDefault()?.GetAttribute(AttributeHelper.InnerText) == "", VacancyTables, VacancyTitle, NextPage, NoOfPagesCssSelector);
            }

            _formCompletionHelper.RetryClickOnException(element);

            return false;
        }
    }
}
