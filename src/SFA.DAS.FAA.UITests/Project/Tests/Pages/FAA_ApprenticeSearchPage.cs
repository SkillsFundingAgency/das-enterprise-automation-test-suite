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
        private By AccountancySubCategory => By.Id("category-ssat1_ahr-details");
        private By AccountancyCheckBox => By.Id("sub-category-stdsec.46");
        private By BrowseButton => By.Id("browse-button");
        private By UpdateResults => By.Id("search-button");
        private By KeywordDropDown => By.Id("SearchField");
        private By KeywordTextField => By.Id("Keywords");
        private By VerifyMobile => By.CssSelector("a[href='/verifymobile']");
        
        public FAA_ApprenticeSearchPage(ScenarioContext context) : base(context) => _context = context;

        public FAA_ApprenticeSearchResultsPage SearchForAVacancy(string location, string searchParameter, string apprenticeshipLevel, string disabilityConfident)
        {           
            formCompletionHelper.EnterText(Location, location);
            formCompletionHelper.SelectFromDropDownByText(ApprenticeshipLevel, apprenticeshipLevel);
            if (disabilityConfident == "Yes")
            {
                formCompletionHelper.SelectCheckBoxByText("Disability Confident");
            }
            switch (searchParameter)
            {
                case "Job title":
                    SearchByKeyword(searchParameter, vacancytitledataHelper.VacancyTitle, "Keywords=" + vacancytitledataHelper.VacancyTitle);
                    break;

                case "Employer":
                    var empName = objectContext.GetEmployerName();
                    SearchByKeyword(searchParameter, empName, "SearchField=Employer");
                    break;

                case "Description":
                    var empDesc = objectContext.GetVacancyShortDescription();
                    SearchByKeyword(searchParameter, empDesc, "SearchField=Description");
                    break;

                default:
                    string urlDistance = "0";
                    if (searchParameter != "England")
                    {
                        int index = searchParameter.LastIndexOf("miles");
                        urlDistance = searchParameter.Substring(0, index).TrimEnd();
                    }
                    formCompletionHelper.SelectFromDropDownByText(Distance, searchParameter);
                    SearchByKeyword(string.Empty,string.Empty, "WithinDistance=" + urlDistance);                     
                    break;
            }
            
            return new FAA_ApprenticeSearchResultsPage(_context);
        }

        private void SearchByKeyword(string searchParameter,string searchText, string urlCheck)
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                formCompletionHelper.SelectFromDropDownByText(KeywordDropDown, searchParameter);
                formCompletionHelper.EnterText(KeywordTextField, searchText);
            }
            formCompletionHelper.Click(Search);
            pageInteractionHelper.WaitforURLToChange(urlCheck);
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
                var uri = new Uri(new Uri(faaconfig.FAABaseUrl), $"apprenticeship/{vacancyRef}");
                tabHelper.GoToUrl(uri.AbsoluteUri);
            }
        }

        public FAA_PhoneNumberVerificationPage VerifyPhoneNumberVerificationText()
        {
            pageInteractionHelper.VerifyText(VerifyPhoneNumberText, faadataHelper.PhoneNumberVerificationText);
            formCompletionHelper.ClickElement(VerifyMobile);
            return new FAA_PhoneNumberVerificationPage(_context);
        } 

        public FAA_ApprenticeSearchResultsPage BrowseVacancy()
        {
            formCompletionHelper.Click(Browse);
            pageInteractionHelper.WaitforURLToChange("searchMode=Category");
            formCompletionHelper.SelectRadioOptionByLocator(Category);
            formCompletionHelper.Click(BrowseButton);
            pageInteractionHelper.WaitforURLToChange("ApprenticeshipLevel");
            formCompletionHelper.Click(AccountancySubCategory);
            formCompletionHelper.Click(AccountancyCheckBox);
            formCompletionHelper.EnterText(Location, "CV1 2NJ");
            formCompletionHelper.SelectFromDropDownByText(Distance, "England");
            formCompletionHelper.Click(UpdateResults);
            pageInteractionHelper.WaitforURLToChange("DisplaySubCategory=true");
            return new FAA_ApprenticeSearchResultsPage(_context);
        }
    }
}
