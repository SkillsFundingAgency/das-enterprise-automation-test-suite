using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
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