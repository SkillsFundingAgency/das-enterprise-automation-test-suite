using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;
using SFA.DAS.RAA.DataGenerator.Project;
using NUnit.Framework;

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
        private By KeywordsDropDownField => By.Id("SearchField");
        private By KeywordsTextField => By.Id("Keywords");
        private By VerifyMobile => By.CssSelector("a[href='/verifymobile']");
        private By DisabilityConfidentCheckBox => By.CssSelector("label.block-label");

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

        public FAA_ApprenticeSearchResultsPage SearchForAVacancy(string locationPostCode, string searchCriteriaOrDistanceDropDownValue, string apprenticeshipLevel, string disabilityConfident)
        {
            _formCompletionHelper.EnterText(Location, locationPostCode);
            _formCompletionHelper.SelectFromDropDownByText(ApprenticeshipLevel, apprenticeshipLevel);

            if (disabilityConfident == "Yes")
                _formCompletionHelper.SelectCheckbox(DisabilityConfidentCheckBox);

            switch (searchCriteriaOrDistanceDropDownValue)
            {
                case "Job title":
                    SearchByKeyword(searchCriteriaOrDistanceDropDownValue, _dataHelper.VacancyTitle, "Keywords=" + _dataHelper.VacancyTitle);
                    break;

                case "Employer":
                    var empName = _objectContext.GetEmployerName();
                    SearchByKeyword(searchCriteriaOrDistanceDropDownValue, empName, "SearchField=Employer");
                    break;

                case "Description":
                    var empDesc = _objectContext.GetVacancyShortDescription();
                    SearchByKeyword(searchCriteriaOrDistanceDropDownValue, empDesc, "SearchField=Description");
                    break;

                default:
                    string urlDistance = "0";
                    if (searchCriteriaOrDistanceDropDownValue != "England")
                    {
                        int index = searchCriteriaOrDistanceDropDownValue.LastIndexOf("miles");
                        urlDistance = searchCriteriaOrDistanceDropDownValue.Substring(0, index).TrimEnd();
                    }
                    _formCompletionHelper.SelectFromDropDownByText(Distance, searchCriteriaOrDistanceDropDownValue);
                    SearchByKeyword(string.Empty, string.Empty, "WithinDistance=" + urlDistance);
                    break;
            }

            return new FAA_ApprenticeSearchResultsPage(_context);
        }

        private void SearchByKeyword(string searchCriteriaOrDistanceDropDownValue, string keywordsTextFieldValue, string urlTextToCheck)
        {
            if (!string.IsNullOrEmpty(keywordsTextFieldValue))
            {
                _formCompletionHelper.SelectFromDropDownByText(KeywordsDropDownField, searchCriteriaOrDistanceDropDownValue);
                _formCompletionHelper.EnterText(KeywordsTextField, keywordsTextFieldValue);
            }

            _formCompletionHelper.Click(Search);
            _pageInteractionHelper.WaitforURLToChange(urlTextToCheck);
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
            _formCompletionHelper.ClickElement(VerifyMobile);
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
