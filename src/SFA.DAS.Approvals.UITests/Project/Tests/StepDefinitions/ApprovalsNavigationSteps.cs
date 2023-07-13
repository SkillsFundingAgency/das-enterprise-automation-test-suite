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
        public void ThenTheEmployerCanNavigateToYourTeamPage() => GoToInterimApprenticesHomePage().GotoYourTeamPage();

        [Then(@"the employer can navigate to paye scheme page")]
        public void ThenTheEmployerCanNavigateToPayeSchemePage() => GoToInterimApprenticesHomePage().GotoPAYESchemesPage();

        [Then(@"the employer can navigate to your organisation and agreement page")]
        public void ThenTheEmployerCanNavigateToYourOrganisationAndAgreementPage() => GoToInterimApprenticesHomePage().GoToYourOrganisationsAndAgreementsPage();

        [Then(@"the employer can navigate to account settings page")]
        public void ThenTheEmployerCanNavigateToAccountSettingsPage() => GoToInterimApprenticesHomePage().GoToYourAccountsPage();

        [Then(@"the employer can navigate to rename account settings page")]
        public void ThenTheEmployerCanNavigateToRenameAccountSettingsPage() => GoToInterimApprenticesHomePage().GoToRenameAccountPage();

        [Then(@"the employer can navigate to notification settings page")]
        public void ThenTheEmployerCanNavigateToNotificationSettingsPage() => GoToInterimApprenticesHomePage().GoToNotificationSettingsPage();

        [Then(@"the employer can navigate to help settings page")]
        public void ThenTheEmployerCanNavigateToHelpSettingsPage() => GoToInterimApprenticesHomePage().GoToHelpPage();

        [Then(@"Standard gov\.uk footer should be displayed at the bottom of the page")]
        public void ThenStandardGov_UkFooterShouldBeDisplayedAtTheBottomOfThePage() => _apprenticesHomePage = GoToApprenticesHomePage().ValidateFooter();

        [Then(@"Standard cookie banner should be displayed at the top of the page")]
        public void ThenStandardCookieBannerShouldBeDisplayedAtTheTopOfThePage() => _apprenticesHomePage = GoToApprenticesHomePage().ValidateCookiesBanner();

        [Then(@"the Help widget is displayed on bottom right hand corner")]
        public void ThenTheHelpWidgetIsDisplayedOnBottomRightHandCorner() => _apprenticesHomePage = GoToApprenticesHomePage().ValidateHelpWidget();

        [Then(@"'(.*)' link should direct user to '(.*)' page")]
        public void ThenLinkShouldDirectUserToPage(string link, string _)
        {
            _apprenticesHomePage = GoToApprenticesHomePage();

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
                case "Apprentice requests":
                    _apprenticesHomePage.ClickApprenticeRequestsLink();
                    break;
                case "Add an apprentice":
                    _apprenticesHomePage.AddAnApprentice();
                    break;
                default:
                    break;
            }
        }

        private ApprenticesHomePage GoToApprenticesHomePage() => new ApprenticesHomePage(_context);

        private InterimApprenticesHomePage GoToInterimApprenticesHomePage() => new InterimApprenticesHomePage(_context, true);
    }
}
