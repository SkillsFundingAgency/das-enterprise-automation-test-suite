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
        public void ThenTheEmployerCanNavigateToYourTeamPage() => new InterimRecruitmentHomePage(_context, true, true).GotoYourTeamPage();

        [Then(@"the employer can navigate to account settings page")]
        public void ThenTheEmployerCanNavigateToAccountSettingsPage() => new InterimRecruitmentHomePage(_context, true, true).GoToYourAccountsPage();

        [Then(@"the employer can navigate to rename account settings page")]
        public void ThenTheEmployerCanNavigateToRenameAccountSettingsPage() => new InterimRecruitmentHomePage(_context, true, true).GoToRenameAccountPage();

        [Then(@"the employer can navigate to change your password settings page")]
        public void ThenTheEmployerCanNavigateToChangeYourPasswordSettingsPage() => new InterimRecruitmentHomePage(_context, true, true).GoToChangeYourPasswordPage();

        [Then(@"the employer can navigate to change your email address settings page")]
        public void ThenTheEmployerCanNavigateToChangeYourEmailAddressSettingsPage() => new InterimRecruitmentHomePage(_context, true, true).GoToChangeYourEmailAddressPage();

        [Then(@"the employer can navigate to notification settings page")]
        public void ThenTheEmployerCanNavigateToNotificationSettingsPage() => new InterimRecruitmentHomePage(_context, true, true).GoToNotificationSettingsPage();

        [Then(@"the employer can navigate to help settings page")]
        public void ThenTheEmployerCanNavigateToHelpSettingsPage() => new InterimRecruitmentHomePage(_context, true, true).GoToHelpPage();

    }
}
