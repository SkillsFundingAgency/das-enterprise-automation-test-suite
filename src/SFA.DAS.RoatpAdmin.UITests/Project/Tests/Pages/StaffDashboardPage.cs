using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Financial;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight;
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
    }
}
