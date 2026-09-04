using SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Financial;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages
{
    public class StaffDashboardPage : RoatpNewAdminBasePage
    {
        protected override string PageTitle => "Staff dashboard";

        public StaffDashboardPage(ScenarioContext context, bool navigate = false) : base(context, !navigate)
        {
            if (navigate) { ClickReturnToStaffDashBoard(); VerifyPage(); }
        }

        public GatewayLandingPage AccessGatewayApplications()
        {
            formCompletionHelper.ClickLinkByText("Access the gateway");
            return new GatewayLandingPage(context);
        }

        public FinancialLandingPage AccessFinancialApplications()
        {
            formCompletionHelper.ClickLinkByText("Complete financial health assessment");
            return new FinancialLandingPage(context);
        }

        public RoatpAssessorApplicationsHomePage AccessAssessorAndModerationApplications()
        {
            formCompletionHelper.ClickLinkByText("Review readiness and quality");
            return new RoatpAssessorApplicationsHomePage(context);
        }

        public OversightLandingPage AccessOversightApplications()
        {
            formCompletionHelper.ClickLinkByText("Decide on application outcomes");
            return new OversightLandingPage(context);
        }

        public MiniDashboardPage AccessAddAndSearchForATrainingProvider()
        {
            formCompletionHelper.ClickLinkByText("Manage training providers and restricted courses");
            return new MiniDashboardPage(context);
        }

        public StaffDashboardPage DownloadTrainingProvider()
        {
            formCompletionHelper.ClickLinkByText("Download list of apprenticeship training providers");
            return new StaffDashboardPage(context);
        }

        public RoatpApplicationReportPage DownloadApplicationData()
        {
            formCompletionHelper.ClickLinkByText("Download application data");
            return new RoatpApplicationReportPage(context);
        }
    }
}
