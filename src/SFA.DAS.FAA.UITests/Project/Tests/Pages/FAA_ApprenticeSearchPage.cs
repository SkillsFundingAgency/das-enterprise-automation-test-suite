using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using SFA.DAS.RAA.DataGenerator.Project;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ApprenticeSearchPage : FAA_SearchVacancyBasePage
    {
        protected override string PageTitle => "Find an apprenticeship";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By SearchField => By.Id("SearchField");
        protected By KeyWord => By.Id("Keywords");
        private By Location => By.Id("Location");
        private By Distance => By.Id("loc-within");
        private By ApprenticeshipLevel => By.Id("apprenticeship-level");
        private By VerifyPhoneNumberText => By.Id("InfoMessageText");
        private By Browse => By.LinkText("Browse");
        private By Category => By.Id("category-ssat1.ahr");
        private By BrowseButton => By.Id("browse-button");
        private By KeywordsDropDownField => By.Id("SearchField");
        private By KeywordsTextField => By.Id("Keywords");
        private By VerifyMobile => By.CssSelector("a[href='/verifymobile']");
        private By DisabilityConfidentCheckBox => By.CssSelector("label.block-label");

        public FAA_ApprenticeSearchPage(ScenarioContext context) : base(context) => _context = context;

        public FAA_ApprenticeSearchResultsPage SearchForAVacancy(string locationPostCode, string searchCriteriaOrDistanceDropDownValue, string apprenticeshipLevel, string disabilityConfident)
        {
            formCompletionHelper.EnterText(Location, locationPostCode);
            formCompletionHelper.SelectFromDropDownByText(ApprenticeshipLevel, apprenticeshipLevel);

            if (disabilityConfident == "Yes")
                formCompletionHelper.SelectCheckbox(DisabilityConfidentCheckBox);

            switch (searchCriteriaOrDistanceDropDownValue)
            {
                case "Job title":
                    SearchByKeyword(searchCriteriaOrDistanceDropDownValue, vacancyTitleDataHelper.VacancyTitle, "Keywords=" + vacancyTitleDataHelper.VacancyTitle);
                    break;

                case "Employer":
                    var empName = objectContext.GetEmployerName();
                    SearchByKeyword(searchCriteriaOrDistanceDropDownValue, empName, "SearchField=Employer");
                    break;

                case "Description":
                    var empDesc = objectContext.GetVacancyShortDescription();
                    SearchByKeyword(searchCriteriaOrDistanceDropDownValue, empDesc, "SearchField=Description");
                    break;

                default:
                    string urlDistance = "0";
                    if (searchCriteriaOrDistanceDropDownValue != "England")
                    {
                        int index = searchCriteriaOrDistanceDropDownValue.LastIndexOf("miles");
                        urlDistance = searchCriteriaOrDistanceDropDownValue.Substring(0, index).TrimEnd();
                    }
                    formCompletionHelper.SelectFromDropDownByText(Distance, searchCriteriaOrDistanceDropDownValue);
                    SearchByKeyword(string.Empty, string.Empty, "WithinDistance=" + urlDistance);
                    break;
            }

            return new FAA_ApprenticeSearchResultsPage(_context);
        }

        private void SearchByKeyword(string searchCriteriaOrDistanceDropDownValue, string keywordsTextFieldValue, string urlTextToCheck)
        {
            if (!string.IsNullOrEmpty(keywordsTextFieldValue))
            {
                formCompletionHelper.SelectFromDropDownByText(KeywordsDropDownField, searchCriteriaOrDistanceDropDownValue);
                formCompletionHelper.EnterText(KeywordsTextField, keywordsTextFieldValue);
            }

            formCompletionHelper.Click(Search);
            pageInteractionHelper.WaitforURLToChange(urlTextToCheck);
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
            var vacancyRef = objectContext.GetVacancyReference();

            if (objectContext.IsRAAV1())
            {
                formCompletionHelper.SelectFromDropDownByValue(SearchField, "ReferenceNumber");
                formCompletionHelper.EnterText(KeyWord, vacancyRef);

                base.SearchByReferenceNumber();
            }
            else
            {
                var uri = new Uri(new Uri(faaConfig.FAABaseUrl), $"apprenticeship/{vacancyRef}");
                tabHelper.GoToUrl(uri.AbsoluteUri);
            }
        }

        public FAA_PhoneNumberVerificationPage VerifyPhoneNumberVerificationText()
        {
            pageInteractionHelper.VerifyText(VerifyPhoneNumberText, faaDataHelper.PhoneNumberVerificationText);
            formCompletionHelper.ClickElement(VerifyMobile);
            return new FAA_PhoneNumberVerificationPage(_context);
        }

        public FAA_ApprenticeSearchResultsPage BrowseVacancy()
        {
            formCompletionHelper.Click(Browse);
            pageInteractionHelper.WaitforURLToChange("searchMode=Category");
            formCompletionHelper.SelectRadioOptionByLocator(Category);
            formCompletionHelper.EnterText(Location, "CV1 2NJ");
            formCompletionHelper.SelectFromDropDownByText(Distance, "England");
            formCompletionHelper.Click(BrowseButton);
            pageInteractionHelper.WaitforURLToChange("ApprenticeshipLevel");
            return new FAA_ApprenticeSearchResultsPage(_context);
        }
    }
}
