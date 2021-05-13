using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding, Scope(Tag = "managefundingnavigation")]
    public class ManageFundingNavigationSteps
    {
        private readonly ScenarioContext _context;

        public ManageFundingNavigationSteps(ScenarioContext context) => _context = context;

        [When(@"the Employer navigates to 'Manage Funding' Page")]
        public void WhenTheEmployerNavigatesToPage() => GoToManageFundingHomePage();

        [Then(@"the employer can navigate to finance page")]
        public void ThenTheEmployerCanNavigateToFinancePage() => GoToManageFundingHomePage().GoToFinancePage();

        [Then(@"the employer can navigate to your team page")]
        public void ThenTheEmployerCanNavigateToYourTeamPage() => new InterimManageFundingHomePage(_context, true, false).GotoYourTeamPage();

        [Then(@"the employer can navigate to paye scheme page")]
        public void ThenTheEmployerCanNavigateToPayeSchemePage() => new InterimManageFundingHomePage(_context, true, false).GotoPAYESchemesPage();

        [Then(@"the employer can navigate to your organisation and agreement page")]
        public void ThenTheEmployerCanNavigateToYourOrganisationAndAgreementPage() => new InterimManageFundingHomePage(_context, true, false).GoToYourOrganisationsAndAgreementsPage();

        [Then(@"the employer can navigate to account settings page")]
        public void ThenTheEmployerCanNavigateToAccountSettingsPage() => new InterimManageFundingHomePage(_context, true, true).GoToYourAccountsPage();

        [Then(@"the employer can navigate to rename account settings page")]
        public void ThenTheEmployerCanNavigateToRenameAccountSettingsPage() => new InterimManageFundingHomePage(_context, true, true).GoToRenameAccountPage();

        [Then(@"the employer can navigate to change your password settings page")]
        public void ThenTheEmployerCanNavigateToChangeYourPasswordSettingsPage() => new InterimManageFundingHomePage(_context, true, true).GoToChangeYourPasswordPage();

        [Then(@"the employer can navigate to change your email address settings page")]
        public void ThenTheEmployerCanNavigateToChangeYourEmailAddressSettingsPage() => new InterimManageFundingHomePage(_context, true, true).GoToChangeYourEmailAddressPage();

        [Then(@"the employer can navigate to notification settings page")]
        public void ThenTheEmployerCanNavigateToNotificationSettingsPage() => new InterimManageFundingHomePage(_context, true, true).GoToNotificationSettingsPage();

        [Then(@"the employer can navigate to help settings page")]
        public void ThenTheEmployerCanNavigateToHelpSettingsPage() => new InterimManageFundingHomePage(_context, true, true).GoToHelpPage();

        private ManageFundingHomePage GoToManageFundingHomePage() => new ManageFundingHomePage(_context, true);

    }
}
