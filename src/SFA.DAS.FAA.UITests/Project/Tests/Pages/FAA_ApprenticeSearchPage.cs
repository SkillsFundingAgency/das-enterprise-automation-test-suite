using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.UI.Framework;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ApprenticeSearchPage(ScenarioContext context) : FAA_SearchVacancyBasePage(context)
    {
        protected override string PageTitle => "Find an apprenticeship";

        private static By SearchField => By.Id("SearchField");
        private static By KeyWord => By.Id("Keywords");
        private static By Location => By.Id("Location");
        private static By Distance => By.Id("loc-within");
        private static By ApprenticeshipLevel => By.Id("apprenticeship-level");
        private static By VerifyPhoneNumberText => By.Id("InfoMessageText");
        private static By Browse => By.LinkText("Browse");
        private static By Category => By.Id("category-ssat1.ahr");
        private static By BrowseButton => By.Id("browse-button");
        private static By KeywordsDropDownField => By.Id("SearchField");
        private static By KeywordsTextField => By.Id("Keywords");
        private static By VerifyMobile => By.CssSelector("a[href='/verifymobile']");
        private static By DisabilityConfidentCheckBox => By.CssSelector("label.block-label");

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
                        urlDistance = searchCriteriaOrDistanceDropDownValue[..index].TrimEnd();
                    }
                    formCompletionHelper.SelectFromDropDownByText(Distance, searchCriteriaOrDistanceDropDownValue);
                    SearchByKeyword(string.Empty, string.Empty, "WithinDistance=" + urlDistance);
                    break;
            }

            return new FAA_ApprenticeSearchResultsPage(context);
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
            return new FAA_ApprenticeSummaryPage(context);
        }

        public FAA_ApprenticeshipNotAvailablePage SearchClosedVacancy()
        {
            SearchVacancyInFAA();
            return new FAA_ApprenticeshipNotAvailablePage(context);
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
                var uri = new Uri(new Uri(UrlConfig.FAA_BaseUrl), $"apprenticeship/{vacancyRef}");
                tabHelper.GoToUrl(uri.AbsoluteUri);
            }
        }

        public FAA_PhoneNumberVerificationPage VerifyPhoneNumberVerificationText()
        {
            pageInteractionHelper.VerifyText(VerifyPhoneNumberText, FAADataHelper.PhoneNumberVerificationText);
            formCompletionHelper.ClickElement(VerifyMobile);
            return new FAA_PhoneNumberVerificationPage(context);
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
            return new FAA_ApprenticeSearchResultsPage(context);
        }
    }
}
