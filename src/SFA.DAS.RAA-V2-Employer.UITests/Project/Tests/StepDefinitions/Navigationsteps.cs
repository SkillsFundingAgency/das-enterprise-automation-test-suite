using SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class Navigationsteps
    {

        private readonly ScenarioContext _context;
        private readonly EmployerStepsHelper _employerStepsHelper;

        public Navigationsteps(ScenarioContext context)
        {
            _context = context;
            _employerStepsHelper = new EmployerStepsHelper(_context);
        }

        [When(@"the Employer navigates to 'Recruit' Page")]
        public void WhenTheEmployerNavigatesToPage() => _employerStepsHelper.GoToRecruitmentHomePage();

        [Then(@"the employer can navigate to home page")]
        public void ThenTheEmployerCanNavigateToHomePage() => new HomePage(_context, true);

        [Then(@"the employer can navigate to finance page")]
        public void ThenTheEmployerCanNavigateToFinancePage()
        {
            new InterimRecruitmentHomePage(_context, true);

            new InterimFinanceHomePage(_context, true);
        }

        [Then(@"the employer can navigate to apprentice page")]
        public void ThenTheEmployerCanNavigateToApprenticePage()
        {
            new InterimRecruitmentHomePage(_context, true);

            new InterimApprenticesHomePage(_context, true);
        }

        [Then(@"the employer can navigate to your team page")]
        public void ThenTheEmployerCanNavigateToYourTeamPage()
        {
            new InterimRecruitmentHomePage(_context, true);

            new InterimYourTeamPage(_context, true);
        }

        [Then(@"the employer can navigate to account settings page")]
        public void ThenTheEmployerCanNavigateToAccountSettingsPage() => new InterimRecruitmentHomePage(_context, true).GoToYourAccountsPage();

    }
}
