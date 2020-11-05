using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Financial;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages
{
   public class StaffDashboardPage : RoatpAdminBasePage
    {
        protected override string PageTitle => "Staff dashboard";

        private By FinancialApplicationLink => By.XPath("//a[@href='/Roatp/Financial/Current']");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public StaffDashboardPage(ScenarioContext context) : base(context) => _context = context;

        public GatewayLandingPage AccessGatewayApplications()
        {
            formCompletionHelper.ClickLinkByText("Go to RoATP gateway applications");
            return new GatewayLandingPage(_context);
        }
        public FinancialLandingPage AccessFinancialApplications()
        {
            formCompletionHelper.ClickElement(FinancialApplicationLink);
            return new FinancialLandingPage(_context);
        }
        public AssessorApplicationsPage AccessAssessorAndModerationApplications()
        {
            formCompletionHelper.ClickLinkByText("Go to RoATP assessor applications");
            return new AssessorApplicationsPage(_context);
        }
    }
}
