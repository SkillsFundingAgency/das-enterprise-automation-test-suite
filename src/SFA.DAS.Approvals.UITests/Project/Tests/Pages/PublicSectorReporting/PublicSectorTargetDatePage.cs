using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public class PublicSectorTargetDatePage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "public sector apprenticeship target data";

        protected override By ContinueButton => By.CssSelector("#report-create-start");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public PublicSectorTargetDatePage(ScenarioContext context) : base(context) => _context = context;

        public ReportYourProgressPage Start()
        {
            Continue();
            return new ReportYourProgressPage(_context);
        }
    }
}