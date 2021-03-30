using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ReportProcessingPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => _pageTitle;
        private string _pageTitle;

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector("#main-content > div > div > p:nth-child(4) > a");

        public ReportProcessingPage(ScenarioContext context, int days, string pageTitle = null, bool verifypage = true) : base(context, false)
        {
            _context = context;
            _pageTitle = $"Processing report from {DateTime.Now.AddDays(-days):dd MMM yyyy} to { DateTime.Now:dd MMM yyyy}";

            if (verifypage) { VerifyPage(); }
        }

        public ReportsPage BackToReportDashboard()
        {
            Continue();
            return new ReportsPage(_context);
        }
    }
}
