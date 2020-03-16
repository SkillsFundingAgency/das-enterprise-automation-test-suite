using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ApprenticeSearchResultsPage : FAA_SearchVacancyBasePage
    {
        protected override string PageTitle => "Search results";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly FAADataHelper _faaDataHelper;
        private readonly VacancyTitleDatahelper _vacancyTitleDataHelper;
        private readonly ObjectContext _objectContext;
        private readonly ScenarioContext _context;
        #endregion
        private By NationwideVacancies => By.Id("nationwideLocationTypeLink");
        private By SortResults => By.Id("sort-results");
        private By NationwideVacanciesText => By.Id("multiple-positions-nationwide");
        private By SearchResults => By.Id("search-results");
        private By VacancyLink => By.LinkText(_vacancyTitleDataHelper.VacancyTitle);



        public FAA_ApprenticeSearchResultsPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _faaDataHelper = context.Get<FAADataHelper>();
            _vacancyTitleDataHelper = context.Get<VacancyTitleDatahelper>();
            _objectContext = context.Get<ObjectContext>();
            _context = context;
            VerifyPage();
        }

        public void CheckSortOrderAndDistance()
        {
            ClickNationwideVacancies();
            CheckSortOrder();
            CheckNationwideVacanciesText();
        }

        protected void CheckSortOrder()
        {
            _pageInteractionHelper.WaitforURLToChange("LocationType=National");
            IWebElement selectElement = _pageInteractionHelper.FindElement(SortResults);
            SelectElement selectedValue = new SelectElement(selectElement);
            string selectedText = selectedValue.SelectedOption.Text;
            _pageInteractionHelper.VerifyText(selectedText, "Closing date");            
        }

        protected void CheckNationwideVacanciesText()
        {
            _pageInteractionHelper.VerifyText(NationwideVacanciesText, _faaDataHelper.NationwideVacanciesText);
        }

        protected void ClickNationwideVacancies()
        {
            _pageInteractionHelper.Verify(() =>
            {
                var elementDisplayed = _pageInteractionHelper.IsElementDisplayed(NoSearchResults);
                if (elementDisplayed)
                {
                    throw new Exception("No Nationwide Vacancies found");
                }
                return elementDisplayed;
            }, () => _formCompletionHelper.Click(NationwideVacancies));           

        }

        public FAA_ApprenticeSummaryPage SelectBrowsedVacancy()
        {
            _formCompletionHelper.SelectFromDropDownByText(SortResults, "Recently added");
            _formCompletionHelper.Click(VacancyLink);            
            return new FAA_ApprenticeSummaryPage(_context);
        }
    }
}
