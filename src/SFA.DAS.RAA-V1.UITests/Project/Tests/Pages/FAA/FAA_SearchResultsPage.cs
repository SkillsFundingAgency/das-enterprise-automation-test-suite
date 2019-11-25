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
        #endregion

        private By NoSearchResults => By.Id("search-no-results-title");

        private By VacancySection => By.CssSelector(".sfa-section-bordered");

        private By VacancyStatus => By.CssSelector(".save-vacancy");

        private By VacancyLink => By.CssSelector(".vacancy-link");

        private By NoOfPagesCounterCssSelector => By.CssSelector(".page-navigation__btn.next .counter");

        private By NoOfPagesCssSelector => By.CssSelector(".page-navigation__btn.next");


        public FAA_SearchResultsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _dataHelper = context.Get<RAADataHelper>();
            VerifyPage();
        }

        public bool FoundVacancies()
        {
            return !_pageInteractionHelper.IsElementDisplayed(NoSearchResults);
        }

        public bool CanApply()
        {
            List<int> pages = new List<int>();
            for (int i = 1; i <= NoOfPages(); i++)
            {
                pages.Add(i);
            }

            foreach (var page in pages)
            {
                var vacancies = _pageInteractionHelper.FindElements(VacancySection).ToList();

                List<IWebElement> availableVacancies = vacancies.Where(x => x.GetAttribute(AttributeHelper.InnerText) == "").ToList();

                foreach (var vacancy in availableVacancies)
                {
                    var availableVacancy = _pageInteractionHelper.FindElement(vacancy, VacancyStatus);

                    if (availableVacancy.GetAttribute(AttributeHelper.InnerText) == "")
                    {
                        _formCompletionHelper.ClickElement(() =>
                        {
                            var element = _pageInteractionHelper.FindElement(vacancy, VacancyLink);
                            _dataHelper.VacancyTitle = element.Text;
                            return element;
                        });

                        return true;
                    }
                }
                if (_pageInteractionHelper.IsElementDisplayed(NoOfPagesCssSelector))
                {
                    _formCompletionHelper.Click(NoOfPagesCssSelector);
                }
            }

            return false;
        }


        private int NoOfPages()
        {
            int noOfPages = 1;

            if (_pageInteractionHelper.IsElementDisplayed(NoOfPagesCounterCssSelector))
            {
                noOfPages = int.Parse(_pageInteractionHelper.GetText(NoOfPagesCounterCssSelector).Split("of")[1].Trim());
            }

            return noOfPages;
        }
    }
}
