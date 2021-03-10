using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class SearchForApprenticeshipPage : ToolSupportBasePage
    {
        protected override string PageTitle => "Search for an apprenticeship.";
        private readonly ScenarioContext _context;
        private readonly JavaScriptHelper _javaScriptHelper;

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
        private By PageSelector => By.ClassName("page-link");
        private By SelectAllChkBox => By.Name("btSelectAll");
        private By SubmitButton => By.Id("submitSearchFormButton");
        private By PauseButton => By.CssSelector("#searchResultsForm .govuk-button");  
        private By ResumeButton => By.XPath("//button[contains(text(),'Resume apprenticeship(s)')]");
        private By StopButton => By.XPath("//button[contains(text(),'Stop apprenticeship(s)')]");
        private By UlnColumn => By.CssSelector("#apprenticeshipResultsTable tr td:nth-child(3)");
        #endregion

        public SearchForApprenticeshipPage(ScenarioContext context, bool verifyPage = true) : base(context, verifyPage)
        {
            _context = context;
            _javaScriptHelper = _context.Get<JavaScriptHelper>();
        } 

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

        public SearchForApprenticeshipPage SelectAllRecords()
        {
            pageInteractionHelper.WaitForElementToBeClickable(PageSelector);
            formCompletionHelper.ClickElement(SelectAllChkBox);
            
            var isChecked = pageInteractionHelper.FindElement(SelectAllChkBox).GetAttribute("checked");
            
            if (isChecked == "false" || isChecked == null)
            {
                pageInteractionHelper.WaitForElementToBeClickable(PageSelector);
                formCompletionHelper.ClickElement(SelectAllChkBox);
            }
                

            return this; 
        }


        public SearchForApprenticeshipPage ClickSubmitButton()
        {
            formCompletionHelper.Click(SubmitButton);
            return new SearchForApprenticeshipPage(_context);
        }

        public PauseApprenticeshipsPage ClickPauseButton()
        {
            pageInteractionHelper.WaitForElementToBeDisplayed(PaginationInfo);
            _javaScriptHelper.ScrollToTheBottom();            
            formCompletionHelper.Click(PauseButton);
            return new PauseApprenticeshipsPage(_context);
        }

        public ResumeApprenticeshipsPage ClickResumeButton()
        {
            formCompletionHelper.Click(ResumeButton);
            return new ResumeApprenticeshipsPage(_context);
        }

        public StopApprenticeshipsPage ClickStopButton()
        {
            formCompletionHelper.Click(StopButton);
            return new StopApprenticeshipsPage(_context);
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

        public List<IWebElement> GetULNsFromApprenticeshipTable() => pageInteractionHelper.FindElements(UlnColumn);

    }
}
