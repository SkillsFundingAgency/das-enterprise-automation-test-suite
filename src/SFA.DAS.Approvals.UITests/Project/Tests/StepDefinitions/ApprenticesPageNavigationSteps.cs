using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AP_Nav_03Steps
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private ApprenticesHomePage _apprenticesHomePage;

        public AP_Nav_03Steps(ScenarioContext context)
        {
            _context = context;
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
    }
}
