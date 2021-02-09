using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class HomePageFinancesSection : HomePage
    {
        private readonly ScenarioContext _context;

        public HomePageFinancesSection(ScenarioContext context) : base(context) => _context = context;

        public EIAccessDeniedPage AccessEIRedirectsToAccessDeniedPage()
        {
            formCompletionHelper.Click(ApplyForEILink);
            return new EIAccessDeniedPage(_context);
        }

        public EIAccessDeniedPage AccessViewEIApplicationsRedirectsToAccessDeniedPage()
        {
            formCompletionHelper.Click(ViewEIApplicationsLink);
            return new EIAccessDeniedPage(_context);
        }

        public EIStartPage NavigateToEIStartPage()
        {
            formCompletionHelper.Click(ApplyForEILink);
            return new EIStartPage(_context);
        }

        public ChooseOrganisationPage NavigateToApplyChooseOrgPage()
        {
            formCompletionHelper.Click(ApplyForEILink);
            return new ChooseOrganisationPage(_context);
        }

        public ViewApplicationsPage NavigateToEIViewApplicationsPage()
        {
            formCompletionHelper.Click(ViewEIApplicationsLink);
            return new ViewApplicationsPage(_context);
        }

        public ViewApplicationsShutterPage NavigateToEIViewApplicationsShutterPage()
        {
            formCompletionHelper.Click(ViewEIApplicationsLink);
            return new ViewApplicationsShutterPage(_context);
        }
    }
}
