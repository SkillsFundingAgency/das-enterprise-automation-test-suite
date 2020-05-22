using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class SubmittedDetailsPage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "Submitted reports";
        
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector("#report-summary-amend");

        public SubmittedDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ConfirmAmendReportPage AmendReport()
        {
            Continue();
            return new ConfirmAmendReportPage(_context);
        }
    }
}