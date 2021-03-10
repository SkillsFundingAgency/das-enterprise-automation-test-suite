using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class HomePageFinancesSection : HomePage
    {
        private readonly ScenarioContext _context;

        public HomePageFinancesSection(ScenarioContext context) : base(context) => _context = context;

        public EIAccessDeniedPage AccessEIHubLinkRedirectsToAccessDeniedPage()
        {
            formCompletionHelper.Click(EIHubLink);
            return new EIAccessDeniedPage(_context);
        }

        public EIHubPage NavigateToEIHubPage()
        {
            formCompletionHelper.Click(EIHubLink);
            return new EIHubPage(_context);
        }

        public ChooseOrganisationPage NavigateToChooseOrgPage()
        {
            formCompletionHelper.Click(EIHubLink);
            return new ChooseOrganisationPage(_context);
        }
    }
}
