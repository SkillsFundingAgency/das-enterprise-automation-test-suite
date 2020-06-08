using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Financial;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages
{
   public class StaffDashboardPage : RoatpAdminBasePage
    {
        protected override string PageTitle => "Staff dashboard";

        private By GatewayApplicationLink => By.XPath("(//a['govuk-link'])[10]");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly RoatpConfig _config;
        #endregion

        public StaffDashboardPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetRoatpConfig<RoatpConfig>();
        }

        public GatewayLandingPage AccessGatewayApplications()
        {
            formCompletionHelper.ClickElement(GatewayApplicationLink);
            return new GatewayLandingPage(_context);
        }

        public FinancialLandingPage AccessFinancialApplications()
        {
            formCompletionHelper.ClickLinkByText("RoATP financial applications");
            return new FinancialLandingPage(_context);
        }
    }
}
