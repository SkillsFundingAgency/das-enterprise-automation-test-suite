using SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers;
using SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class Navigationsteps
    {
        private readonly ScenarioContext _context;
        private readonly RAAV2EmployerLoginStepsHelper _rAAV2EmployerLoginHelper;

        public Navigationsteps(ScenarioContext context)
        {
            _context = context;
            _rAAV2EmployerLoginHelper = new RAAV2EmployerLoginStepsHelper(_context);
        }

        [Given(@"the Employer navigates to 'Recruit' Page")]
        [When(@"the Employer navigates to 'Recruit' Page")]
        public void WhenTheEmployerNavigatesToPage() => _rAAV2EmployerLoginHelper.GoToRecruitmentHomePage();

        [Then(@"the employer can navigate to finance page")]
        public void ThenTheEmployerCanNavigateToFinancePage()
        {
            new InterimYourApprenticeshipAdvertsHomePage(_context, true);

            new InterimFinanceHomePage(_context, true);
        }

        [Then(@"the employer can navigate to apprentice page")]
        public void ThenTheEmployerCanNavigateToApprenticePage()
        {
            new InterimYourApprenticeshipAdvertsHomePage(_context, true);

            new InterimApprenticesHomePage(_context, false);
        }

        [Then(@"the employer can navigate to your team page")]
        public void ThenTheEmployerCanNavigateToYourTeamPage() => new InterimYourApprenticeshipAdvertsHomePage(_context, true, true).GotoYourTeamPage();

        [Then(@"the employer can navigate to account settings page")]
        public void ThenTheEmployerCanNavigateToAccountSettingsPage() => new InterimYourApprenticeshipAdvertsHomePage(_context, true, true).GoToYourAccountsPage();

        [Then(@"the employer can navigate to rename account settings page")]
        public void ThenTheEmployerCanNavigateToRenameAccountSettingsPage() => new InterimYourApprenticeshipAdvertsHomePage(_context, true, true).GoToRenameAccountPage();

        [Then(@"the employer can navigate to notification settings page")]
        public void ThenTheEmployerCanNavigateToNotificationSettingsPage() => new InterimYourApprenticeshipAdvertsHomePage(_context, true, true).GoToNotificationSettingsPage();

        [Then(@"the employer can navigate to advert notifications page via settings dropdwon")]
        public void ThenTheEmployerCanNavigateToAdvertNotificationsPageViaSettingsDropdwon() => new YourApprenticeshipAdvertsHomePage(_context, true, true).GoToAdvertNotificationsPage();

        [Then(@"the employer can navigate to help settings page")]
        public void ThenTheEmployerCanNavigateToHelpSettingsPage() => new InterimYourApprenticeshipAdvertsHomePage(_context, true, true).GoToHelpPage();

    }
}
