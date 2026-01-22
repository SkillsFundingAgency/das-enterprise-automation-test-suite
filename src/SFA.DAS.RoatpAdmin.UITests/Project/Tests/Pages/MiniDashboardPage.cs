using SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Financial;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages
{
    public class MiniDashboardPage : RoatpNewAdminBasePage
    {
        protected override string PageTitle => "Manage training provider information";

        public MiniDashboardPage(ScenarioContext context, bool navigate = false) : base(context, !navigate)
        {
            if (navigate) { ClickReturnToStaffDashBoard(); VerifyPage(); }
        }

        public SearchPage SearchForATrainingProvider()
        {
            formCompletionHelper.ClickLinkByText("Search for a training provider");
            return new SearchPage(context);
        }
        public RoatpApplicationReportPage AddNewTrainingProvider()
        {
            formCompletionHelper.ClickLinkByText("Add a new training provider");
            return new RoatpApplicationReportPage(context);
        }

        public AllowListPage Add_UKPRN_Allowlist()
        {
            formCompletionHelper.ClickLinkByText("Add a UKPRN to the allow list");
            return new AllowListPage(context);
        }
    }
}
