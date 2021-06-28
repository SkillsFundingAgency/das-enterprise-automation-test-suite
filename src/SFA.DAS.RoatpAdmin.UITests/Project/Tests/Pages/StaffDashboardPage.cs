using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Financial;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages
{
    public class StaffDashboardPage : RoatpNewAdminBasePage
    {
        protected override string PageTitle => "Staff dashboard";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public StaffDashboardPage(ScenarioContext context, bool navigate = false) : base(context, !navigate)
        {
            _context = context; 

            if (navigate) { ClickReturnToStaffDashBoard(); VerifyPage(); }
        }

        public GatewayLandingPage AccessGatewayApplications()
        {
            formCompletionHelper.ClickLinkByText("Go to RoATP gateway applications");
            return new GatewayLandingPage(_context);
        }

        public FinancialLandingPage AccessFinancialApplications()
        {
            formCompletionHelper.ClickLinkByText("Go to RoATP financial applications");
            return new FinancialLandingPage(_context);
        }

        public RoatpAssessorApplicationsHomePage AccessAssessorAndModerationApplications() 
        {
            formCompletionHelper.ClickLinkByText("Go to RoATP assessor applications");
            return new RoatpAssessorApplicationsHomePage(_context);
        }

        public OversightLandingPage AccessOversightApplications() 
        {
            formCompletionHelper.ClickLinkByText("Go to RoATP application outcomes");
            return new OversightLandingPage(_context);
        }

        public RoatpAdminHomePage SearchForATrainingProvider()
        {
            formCompletionHelper.ClickLinkByText("Search for an apprenticeship training provider");
            return new RoatpAdminHomePage(_context);
        }

        public StaffDashboardPage DownloadTrainingProvider()
        {
            formCompletionHelper.ClickLinkByText("Download list of apprenticeship training providers");
            return new StaffDashboardPage(_context);
        }

        public RoatpApplicationReportPage DownloadApplicationData()
        {
            formCompletionHelper.ClickLinkByText("Download application data");
            return new RoatpApplicationReportPage(_context);
        }
    }
}
