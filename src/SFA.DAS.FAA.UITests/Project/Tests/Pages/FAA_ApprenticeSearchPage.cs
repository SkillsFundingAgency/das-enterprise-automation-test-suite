using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;
using SFA.DAS.RAA.DataGenerator.Project;


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
        private readonly FAADataHelper _faadataHelper;
        #endregion

        private By SearchField => By.Id("SearchField");
        protected By KeyWord => By.Id("Keywords");
        private By Location => By.Id("Location");
        private By Distance => By.Id("loc-within");
        private By ApprenticeshipLevel => By.Id("apprenticeship-level");
        private By VerifyPhoneNumberText => By.Id("InfoMessageText");
        private By Browse => By.LinkText("Browse");
        private By Category => By.Id("category-ssat1.ahr");
        private By AccountancySubCategory => By.Id("category-ssat1_ahr-details");
        private By AccountancyCheckBox => By.Id("sub-category-stdsec.46");
        private By BrowseButton => By.Id("browse-button");
        private By UpdateResults => By.Id("search-button");

        
        public FAA_ApprenticeSearchPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();  
            _dataHelper = context.Get<VacancyTitleDatahelper>();
            _tabHelper = context.Get<TabHelper>();
            _config = context.GetFAAConfig<FAAConfig>();
            _faadataHelper = context.Get<FAADataHelper>();
            VerifyPage();
        }

        public FAA_ApprenticeSearchResultsPage SearchForAVacancy(string location, string distance, string apprenticeshipLevel, string disabilityConfident)
        {           
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
            SearchVacancyInFAA();            
            return new FAA_ApprenticeSummaryPage(_context);
        }

        public FAA_ApprenticeshipNotAvailablePage SearchClosedVacancy()
        {
            SearchVacancyInFAA();
            return new FAA_ApprenticeshipNotAvailablePage(_context);
        }

        private void SearchVacancyInFAA()
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
        }

        public FAA_PhoneNumberVerificationPage VerifyPhoneNumberVerificationText()
        {
            _pageInteractionHelper.VerifyText(VerifyPhoneNumberText, _faadataHelper.PhoneNumberVerificationText);
            _formCompletionHelper.ClickLinkByText("verify your number");
            _pageInteractionHelper.WaitforURLToChange("verifymobile");
            return new FAA_PhoneNumberVerificationPage(_context);
        } 

        public FAA_ApprenticeSearchResultsPage BrowseVacancy()
        {
            _formCompletionHelper.Click(Browse);
            _pageInteractionHelper.WaitforURLToChange("searchMode=Category");
            _formCompletionHelper.SelectRadioOptionByLocator(Category);
            _formCompletionHelper.Click(BrowseButton);
            _pageInteractionHelper.WaitforURLToChange("ApprenticeshipLevel");
            _formCompletionHelper.Click(AccountancySubCategory);
            _formCompletionHelper.Click(AccountancyCheckBox);
            _formCompletionHelper.EnterText(Location, "CV1 2NJ");
            _formCompletionHelper.SelectFromDropDownByText(Distance, "England");
            _formCompletionHelper.Click(UpdateResults);
            _pageInteractionHelper.WaitforURLToChange("DisplaySubCategory=true");
            return new FAA_ApprenticeSearchResultsPage(_context);
        }
    }
}
