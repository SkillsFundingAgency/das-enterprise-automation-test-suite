using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.FAA
{
    public class FAA_SearchResultsPage : FAA_SearchVacancy
    {
        protected override string PageTitle => "Search results";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly RAADataHelper _dataHelper;
        private RandomVacancyHelper _vacancyHelper;
        #endregion

        private By VacancyTables => By.CssSelector(".sfa-section-bordered");

        private By AvailableVacancy => By.CssSelector(".save-vacancy .save-vacancy-link[title='Save for later']");

        private By VacancyTitle => By.CssSelector(".vacancy-link");

        private By NoOfPagesCssSelector => By.CssSelector(".page-navigation__btn.next .counter");

        private By NextPage => By.CssSelector(".page-navigation__btn.next");

        private By ApplyButton => By.Id("apply-button");


        public FAA_SearchResultsPage(ScenarioContext context) : base(context)
        {
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _dataHelper = context.Get<RAADataHelper>();
            VerifyPage();
        }

        public bool CanApplyTraineeship()
        {
            var vacancies = _pageInteractionHelper.FindElements(VacancyTitle).Select(x => x.Text).ToList();
            
            foreach (var vacancy in vacancies)
            {
                _formCompletionHelper.ClickLinkByText(vacancy);

                if (_pageInteractionHelper.IsElementDisplayed(ApplyButton))
                {
                    _dataHelper.VacancyTitle = vacancy;
                    return true;
                }

                _formCompletionHelper.ClickLinkByText("Return to search results");
            }
            return false;
        }

        public bool CanApplyApprenticeship()
        {
            return CanApply((x) => x.FindElements(AvailableVacancy).Any());
        }

        private bool CanApply(Func<IWebElement, bool> func)
        {
            _vacancyHelper = new RandomVacancyHelper(_pageInteractionHelper, _formCompletionHelper, _dataHelper);

            _dataHelper.VacancyTitle = string.Empty;

            _vacancyHelper.RandomElementAt(func, VacancyTables, VacancyTitle, NextPage, NoOfPagesCssSelector);

            if (string.IsNullOrEmpty(_dataHelper.VacancyTitle) || !_pageInteractionHelper.IsElementDisplayed(ApplyButton))
            {
                return false;
            }

            _formCompletionHelper.ClickLinkByText(_dataHelper.VacancyTitle);

            return true;
        }
    }
}
