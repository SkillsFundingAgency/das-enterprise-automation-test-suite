using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages
{
    public class RoatpApplicationReportPage : RoatpAdminBasePage
    {
        protected override string PageTitle => "Download the RoATP application report";

        private By FromDate => By.Id("FromDate");
        private By ToDate => By.Id("ToDate");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public RoatpApplicationReportPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public RoatpApplicationReportPage DownloadReport()
        {
            formCompletionHelper.SendKeys(FromDate, DateTime.Now.AddMonths(-6).ToString("yyyy-MM-dd"));
            formCompletionHelper.SendKeys(ToDate, DateTime.Now.ToString("yyyy-MM-dd"));
            Continue();
            return new RoatpApplicationReportPage(_context);
        }

    }
}
