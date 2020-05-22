using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class ConfirmAmendReportPage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "If you amend this submission, you will have to resubmit ";

        protected override By PageHeader => By.CssSelector("#content p");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector("#report-confirm-amend");

        public ConfirmAmendReportPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ReportYourProgressPage ConfirmAmend()
        {
            Continue();
            return new ReportYourProgressPage(_context);
        }
    }

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

    public class SubmittedReportspage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "Submitted reports";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly TableRowHelper _tableRowHelper;
        #endregion

        public SubmittedReportspage(ScenarioContext context) : base(context)
        {
            _context = context;
            _tableRowHelper = context.Get<TableRowHelper>();
            VerifyPage();
        }

        public SubmittedDetailsPage ViewReport()
        {
            _tableRowHelper.SelectRowFromTable("View", registrationConfig.RE_OrganisationName);
            return new SubmittedDetailsPage(_context);
        }

    }
}