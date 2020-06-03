using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding, Scope(Tag = "approvalsnavigation")]
    public class ApprovalsNavigationSteps
    {
        private readonly ScenarioContext _context;
        private ApprenticesHomePage _apprenticesHomePage;

        public ApprovalsNavigationSteps(ScenarioContext context) => _context = context;

        [When(@"the Employer navigates to 'Apprentice' Page")]
        public void WhenTheEmployerNavigatesToPage() => GoToApprenticesHomePage();

        [Then(@"the employer can navigate to finance page")]
        public void ThenTheEmployerCanNavigateToFinancePage() => GoToApprenticesHomePage().GoToFinancePage();

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

        private ApprenticesHomePage GoToApprenticesHomePage() => new ApprenticesHomePage(_context, true);

        [Then(@"Standard gov\.uk footer should be displayed at the bottom of the page")]
        public void ThenStandardGov_UkFooterShouldBeDisplayedAtTheBottomOfThePage()
        {
            _apprenticesHomePage = new ApprenticesHomePage(_context, true);
            _apprenticesHomePage.ValidateFooter();
        }

        [Then(@"Standard cookie banner should be displayed at the top of the page")]
        public void ThenStandardCookieBannerShouldBeDisplayedAtTheTopOfThePage()
        {
            _apprenticesHomePage = new ApprenticesHomePage(_context, true);
            _apprenticesHomePage.ValidateCookiesBanner();
        }

        [Then(@"the Help widget is displayed on bottom right hand corner")]
        public void ThenTheHelpWidgetIsDisplayedOnBottomRightHandCorner()
        {
            _apprenticesHomePage = new ApprenticesHomePage(_context, true);
            _apprenticesHomePage.ValidateHelpWidget();
        }

        [Then(@"'(.*)' link should direct user to '(.*)' page")]
        public void ThenLinkShouldDirectUserToPage(string link, string page)
        {
            _apprenticesHomePage = new ApprenticesHomePage(_context, true);

            switch (link)
            {
                case "Set payment order":
                    _apprenticesHomePage.ClickSetPaymentOrderLink();
                    break;
                case "Report public sector apprenticeship target":
                    _apprenticesHomePage.ClickReportPublicSectorApprenticeshipTargetLink();
                    break;
                case "Manage your apprentices":
                    _apprenticesHomePage.ClickManageYourApprenticesLink();
                    break;
                case "Your cohorts":
                    _apprenticesHomePage.ClickYourCohortsLink();
                    break;
                case "Add an apprentice":
                    _apprenticesHomePage.AddAnApprentice();
                    break;
                default:
                    break;
            }
        }
    }
}
