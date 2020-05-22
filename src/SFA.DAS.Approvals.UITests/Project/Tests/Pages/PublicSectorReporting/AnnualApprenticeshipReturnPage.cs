using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class AnnualApprenticeshipReturnPage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "Annual apprenticeship return";

        protected override By ContinueButton => By.CssSelector("#SubmitSelectOptionForm");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public AnnualApprenticeshipReturnPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ReportYourProgressPage Start()
        {
            Continue();
            return new ReportYourProgressPage(_context);
        }
    }
}