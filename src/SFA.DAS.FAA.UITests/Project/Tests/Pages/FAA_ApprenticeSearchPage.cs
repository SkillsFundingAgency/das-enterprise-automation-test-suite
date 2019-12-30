using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ApprenticeSearchPage : FAA_SearchVacancyBasePage
    {
        protected override string PageTitle => "Find an apprenticeship";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly VacancyTitleDatahelper _dataHelper;
        private readonly TabHelper _tabHelper;
        private readonly FAAConfig _config;
        #endregion

        private By SearchField => By.Id("SearchField");

        protected By KeyWord => By.Id("Keywords");

        private By Location => By.Id("Location");

        private By Distance => By.Id("loc-within");

        private By ApprenticeshipLevel => By.Id("apprenticeship-level");

        public FAA_ApprenticeSearchPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _dataHelper = context.Get<VacancyTitleDatahelper>();
            _tabHelper = context.Get<TabHelper>();
            _config = context.GetFAAConfig<FAAConfig>();
            VerifyPage();
        }

        public FAA_ApprenticeSearchResultsPage SearchForAVacancy(string location, string distance, string apprenticeshipLevel, string disabilityConfident)
        {
            _formCompletionHelper.SelectFromDropDownByValue(SearchField, "JobTitle");
            _formCompletionHelper.EnterText(KeyWord, _dataHelper.VacancyTitle);
            _formCompletionHelper.EnterText(Location, location);
            _formCompletionHelper.SelectFromDropDownByText(Distance, distance);
            _formCompletionHelper.SelectFromDropDownByText(ApprenticeshipLevel, apprenticeshipLevel);
            if (disabilityConfident == "Yes")
            {
                _formCompletionHelper.SelectCheckBoxByText("Disability Confident");
            }

            _formCompletionHelper.Click(Search);

            WaitforURLToChange(distance);

            return new FAA_ApprenticeSearchResultsPage(_context);
        }

        public new FAA_ApprenticeSummaryPage SearchByReferenceNumber()
        {
            var vacancyRef = _objectContext.GetVacancyReference();

            if (_objectContext.IsRAAV1())
            {
                _formCompletionHelper.SelectFromDropDownByValue(SearchField, "ReferenceNumber");
                _formCompletionHelper.EnterText(KeyWord, vacancyRef);

                base.SearchByReferenceNumber();
            }
            else
            {
                var uri = new Uri(new Uri(_config.FAABaseUrl), $"apprenticeship/{vacancyRef}");
                _tabHelper.GoToUrl(uri.AbsoluteUri);
            }
            

            return new FAA_ApprenticeSummaryPage(_context);
        }
    }
}
