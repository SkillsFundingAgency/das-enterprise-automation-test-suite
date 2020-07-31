using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages.AR_Admin
{
   public class ApprenticeMatchingDashBoardPage : ApprenticeRedundancyBasePage
    {
        protected override string PageTitle => "Download a vacancy sharing service report";

        private By ApprenticeReport => By.Id("ReportType");
        private By EmployerReport => By.Id("ReportType-2");
        private By MarketoFileType => By.Id("FileType");
        private By CsvFiletype => By.Id("FileType-2");
        private By FromDate => By.Id("FromDate");
        private By ToDate => By.Id("ToDate");
        private By Download => By.CssSelector(".govuk-button");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ApprenticeMatchingDashBoardPage (ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public ApprenticeMatchingDashBoardPage SelectApprenticeReportAndConfirmDates()
        {
            formCompletionHelper.SelectRadioOptionByLocator(ApprenticeReport);
            formCompletionHelper.SendKeys(FromDate, apprenticeRedundancyDataHelper.GetFromdate);
            formCompletionHelper.SendKeys(ToDate, DateTime.Now.ToString("yyyy-MM-dd"));
            return this;
        }

        public ApprenticeMatchingDashBoardPage SelectEmployerReportAndConfirmDates()
        {
            formCompletionHelper.SelectRadioOptionByLocator(EmployerReport);
            formCompletionHelper.SendKeys(FromDate, apprenticeRedundancyDataHelper.GetFromdate);
            formCompletionHelper.SendKeys(ToDate, DateTime.Now.ToString("yyyy-MM-dd"));
            return this;
        }

        public ApprenticeMatchingDashBoardPage ContinueWithoutSelectingReportAndDate()
        {
            formCompletionHelper.ClickElement(Download);
            return this;
        }
        public ApprenticeMatchingDashBoardPage SelectCSVFileAndDownload()
        {
            formCompletionHelper.SelectRadioOptionByLocator(CsvFiletype);
            formCompletionHelper.ClickElement(Download);
            return this;
        }
        public ApprenticeMatchingDashBoardPage SelectMarketoFileAndDownload()
        {
            formCompletionHelper.SelectRadioOptionByLocator(MarketoFileType);
            formCompletionHelper.ClickElement(Download);
            return this;
        }

    }
}
