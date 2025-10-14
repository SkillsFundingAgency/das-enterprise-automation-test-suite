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
            formCompletionHelper.ClickLinkByText("Manage financial applications");
            return new FinancialLandingPage(context);
        }

        public RoatpAssessorApplicationsHomePage AccessAssessorAndModerationApplications()
        {
            formCompletionHelper.ClickLinkByText("Manage applications");
            return new RoatpAssessorApplicationsHomePage(context);
        }

        public OversightLandingPage AccessOversightApplications()
        {
            formCompletionHelper.ClickLinkByText("Decide on application outcomes");
            return new OversightLandingPage(context);
        }

        public SearchPage SearchForATrainingProvider()
        {
            formCompletionHelper.ClickLinkByText("Search for an apprenticeship training provider");
            return new SearchPage(context);
        }

        public StaffDashboardPage DownloadTrainingProvider()
        {
            formCompletionHelper.ClickLinkByText("Download training provider data");
            return new StaffDashboardPage(context);
        }

        public RoatpApplicationReportPage DownloadApplicationData()
        {
            formCompletionHelper.ClickLinkByText("Download application data");
            return new RoatpApplicationReportPage(context);
        }

        public AllowListPage Add_UKPRN_Allowlist()
        {
            formCompletionHelper.ClickLinkByText("Add UKPRNs to the allow list");
            return new AllowListPage(context);
        }
    }
}
