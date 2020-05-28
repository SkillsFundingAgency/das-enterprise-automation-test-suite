using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_TraineeshipSearchResultsPage : FAA_SearchVacancyBasePage
    {
        protected override string PageTitle => "Search results";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly VacancyTitleDatahelper _dataHelper;
        #endregion

        public FAA_TraineeshipSearchResultsPage(ScenarioContext context) : base(context)
        {
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _dataHelper = context.Get<VacancyTitleDatahelper>();
            VerifyPage();
        }

        public FAA_TraineeshipSearchResultsPage CheckVacancyIsDisplayed(string locationPostCode)
        {
            if (_pageInteractionHelper.IsElementDisplayed(DisplayResults))
            {
                _pageInteractionHelper.FocusTheElement(DisplayResults);
                _formCompletionHelper.SelectFromDropDownByValue(DisplayResults, "50");
                _pageInteractionHelper.WaitforURLToChange("resultsPerPage=50");
            }

            ChangeSortOrderToRecentlyAdded();

            List<IWebElement> vacanciesCount = _pageInteractionHelper.FindElements(VacanciesList);
            if (vacanciesCount.Count > 0)
            {
                foreach (var vacancy in vacanciesCount)
                {
                    if (vacancy.Text.Contains(_dataHelper.VacancyTitle))
                        return this;
                }
                throw new Exception($"VacancyTitle Not found in VacanciesList within the '{locationPostCode}'");
            }
            else
            {
                throw new Exception($"Vacancy title: {_dataHelper.VacancyTitle} Not Found");
            }
        }
    }
}
