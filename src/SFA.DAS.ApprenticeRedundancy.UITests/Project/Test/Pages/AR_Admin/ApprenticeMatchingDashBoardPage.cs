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
        protected override string PageTitle => "Welcome, s Allroatprole";

        private By ReportType => By.Id("ReportType");
        private By FromDate => By.Id("FromDate");
        private By ToDate => By.Id("ToDate");
        private By Download => By.Id("download-report");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ApprenticeMatchingDashBoardPage (ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public ApprenticeMatchingDashBoardPage SelectApprenticeReportAndDownload()
        {
            formCompletionHelper.SelectFromDropDownByText(ReportType, "Apprentice report");
            formCompletionHelper.SendKeys(FromDate, apprenticeRedundancyDataHelper.GetFromdate);
            formCompletionHelper.SendKeys(ToDate, DateTime.Now.ToString("yyyy-MM-dd"));
            formCompletionHelper.ClickElement(Download);
            return this;
        }

        public ApprenticeMatchingDashBoardPage SelectEmployerReportAndDownload()
        {
            formCompletionHelper.SelectFromDropDownByText(ReportType, "Employer report");
            formCompletionHelper.SendKeys(FromDate, apprenticeRedundancyDataHelper.GetFromdate);
            formCompletionHelper.SendKeys(ToDate, DateTime.Now.ToString("yyyy-MM-dd"));
            formCompletionHelper.ClickElement(Download);
            return this;
        }
    }
}
