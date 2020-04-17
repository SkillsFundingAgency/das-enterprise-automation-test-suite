using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class NavigationSteps
    {
        private readonly ScenarioContext _context;

        public NavigationSteps(ScenarioContext context) => _context = context;

        [Then(@"the Employer is able to navigate back and forth from Apprentices to 'Finance' Page")]
        public void ThenTheEmployerIsAbleToNavigateBackAndForthFromApprenticesToFinancePage()
        {
            NavigateToApprenticesPage();
            new FinancePage(_context);
        }

        [Then(@"the Employer is able to navigate back and forth from Apprentices to 'Your Team' Page")]
        public void ThenTheEmployerIsAbleToNavigateBackAndForthFromApprenticesToYourTeamPage() => NavigateToApprenticesPage().GotoYourTeamPage();

        [Then(@"the Employer is able to navigate back and forth from Apprentices to 'Your organisations and agreements' Page")]
        public void ThenTheEmployerIsAbleToNavigateBackAndForthFromApprenticesToYourOrganisationsAndAgreementsPage() =>
            NavigateToApprenticesPage().GoToYourOrganisationsAndAgreementsPage();

        [Then(@"the Employer is able to navigate back and forth from Apprentices to 'PAYE schemes' Page")]
        public void ThenTheEmployerIsAbleToNavigateBackAndForthFromApprenticesToPayeSchemesPage()
        {
            NavigateToApprenticesPage().GotoPAYESchemesPage();
            NavigateToApprenticesPage();
        }

        private ApprenticesHomePage NavigateToApprenticesPage() => new ApprenticesHomePage(_context, true);
    }
}
