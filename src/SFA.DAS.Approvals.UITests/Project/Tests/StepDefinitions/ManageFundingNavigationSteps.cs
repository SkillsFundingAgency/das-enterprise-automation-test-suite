using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding, Scope(Tag = "managefundingnavigation")]
    public class ManageFundingNavigationSteps
    {
        private readonly ScenarioContext _context;

        public ManageFundingNavigationSteps(ScenarioContext context) => _context = context;

        [When(@"the Employer navigates to 'Apprentice' Page")]
        public void WhenTheEmployerNavigatesToPage() => NavigateToApprenticesPage();

        [Then(@"the employer can navigate to finance page")]
        public void ThenTheEmployerCanNavigateToFinancePage() => NavigateToApprenticesPage().GoToFinancePage();

        [Then(@"the employer can navigate to your team page")]
        public void ThenTheEmployerCanNavigateToYourTeamPage() => new InterimApprenticesHomePage(_context, true, true).GotoYourTeamPage();

        [Then(@"the employer can navigate to paye scheme page")]
        public void ThenTheEmployerCanNavigateToPayeSchemePage() => new InterimApprenticesHomePage(_context, true, true).GotoPAYESchemesPage();

        [Then(@"the employer can navigate to your organisation and agreement page")]
        public void ThenTheEmployerCanNavigateToYourOrganisationAndAgreementPage() => new InterimApprenticesHomePage(_context, true, true).GoToYourOrganisationsAndAgreementsPage();

        [Then(@"the employer can navigate to account settings page")]
        public void ThenTheEmployerCanNavigateToAccountSettingsPage() => new InterimApprenticesHomePage(_context, true, true).GoToYourAccountsPage();

        [Then(@"the employer can navigate to rename account settings page")]
        public void ThenTheEmployerCanNavigateToRenameAccountSettingsPage() => new InterimApprenticesHomePage(_context, true, true).GoToRenameAccountPage();

        [Then(@"the employer can navigate to change your password settings page")]
        public void ThenTheEmployerCanNavigateToChangeYourPasswordSettingsPage() => new InterimApprenticesHomePage(_context, true, true).GoToChangeYourPasswordPage();

        [Then(@"the employer can navigate to change your email address settings page")]
        public void ThenTheEmployerCanNavigateToChangeYourEmailAddressSettingsPage() => new InterimApprenticesHomePage(_context, true, true).GoToChangeYourEmailAddressPage();

        [Then(@"the employer can navigate to notification settings page")]
        public void ThenTheEmployerCanNavigateToNotificationSettingsPage() => new InterimApprenticesHomePage(_context, true, true).GoToNotificationSettingsPage();

        [Then(@"the employer can navigate to help settings page")]
        public void ThenTheEmployerCanNavigateToHelpSettingsPage() => new InterimApprenticesHomePage(_context, true, true).GoToHelpPage();

        private ApprenticesHomePage NavigateToApprenticesPage() => new ApprenticesHomePage(_context, true);

    }
}
