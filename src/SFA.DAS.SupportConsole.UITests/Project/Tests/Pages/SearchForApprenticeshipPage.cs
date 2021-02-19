using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class SearchForApprenticeshipPage : ToolSupportBasePage
    {
        private readonly ScenarioContext _context;
        protected override string PageTitle => "Search for an apprenticeship.";

        #region Locators
        private By EmployerName => By.Id("employerName");
        private By ProviderName => By.Id("providerName");
        private By Ukprn => By.Id("ukprn");
        private By CourseName => By.Id("courseName");
        private By ApprenticeNameOrUln => By.Id("apprenticeNameOrUln");
        private By EndDate => By.Id("endDate");        
        private By ApprenticeshipStatus => By.Id("SelectedStatus");
        private By DataTable => By.Id("apprenticeshipResultsTable");
        private By PaginationInfo => By.ClassName("pagination-info");
        private By SubmitButton => By.Id("submitSearchFormButton");
        private By PauseButton => By.XPath("//button[contains(text(),'Pause apprenticeship(s)')]");

        #endregion

        public SearchForApprenticeshipPage(ScenarioContext context) : base(context) => _context = context;

        public SearchForApprenticeshipPage EnterEmployerName(string employerName)
        {
            formCompletionHelper.EnterText(EmployerName, employerName);
            return this;
        }

        public SearchForApprenticeshipPage EnterProviderName(string providerName)
        {
            formCompletionHelper.EnterText(ProviderName, providerName);
            return this;
        }

        public SearchForApprenticeshipPage EnterUkprn(string ukprn)
        {
            formCompletionHelper.EnterText(Ukprn, ukprn);
            return this;
        }

        public SearchForApprenticeshipPage EnterCourseName(string courseName)
        {
            formCompletionHelper.EnterText(CourseName, courseName);
            return this;
        }

        public SearchForApprenticeshipPage EnterEndDate(string endDate)
        {
            formCompletionHelper.EnterText(EndDate, endDate);
            return this;
        }

        public SearchForApprenticeshipPage EnterULNorApprenticeName(string apprenticeNameOrUln)
        {
            formCompletionHelper.EnterText(ApprenticeNameOrUln, apprenticeNameOrUln);
            return this;
        }

        public SearchForApprenticeshipPage SelectStatus(string status)
        {
            status = (status == "" ? "Any" : status);
            formCompletionHelper.SelectFromDropDownByText(ApprenticeshipStatus, status);
            return this;
        }

        public SearchForApprenticeshipPage ClickSubmitButton()
        {
            formCompletionHelper.Click(SubmitButton);
            return this;
        }

        public int GetNumberOfRecordsFound()
        {
            pageInteractionHelper.WaitForElementToBeDisplayed(DataTable);
            var paginationInfo = pageInteractionHelper.GetText(PaginationInfo);
            var arrPaginationInfo = paginationInfo.Split(" ");
            
            if (arrPaginationInfo.Length < 5)
                return 0;
            else            
                return (Convert.ToInt32(arrPaginationInfo[5]));
        }

    }
}
