using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.PreamblePages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    class ApplySteps
    {
        private readonly ScenarioContext _context;
        private AP_ApplicationOverviewPage _applicationOverviewPage;

        public ApplySteps(ScenarioContext context)
        {
            _context = context;
        }

        [When(@"the Apply User completes preamble journey of Organisation Section")]
        public void WhenTheApplyUserCompletespreambleJourneyOfOrganisationSection()
        {
            _applicationOverviewPage = new AP_PR1_SearchForYourOrganisationPage(_context).EnterOrgNameAndSearchInSearchForYourOrgPage()
                .ClickOrgLinkFromSearchResultsForPage()
                .SelectTrainingProviderRadioButtonAndContinueInSelectOrgTypePage()
                .ClickConfirmAndApplyButtonInConfirmOrgPage();
        }

        [When(@"organisation details section")]
        public void WhenOrganisationDetailsSection()
        {
            _applicationOverviewPage = _applicationOverviewPage.ClickGoToOrganisationDetailsLinkInApplicationOverviewPage()
                .ClickTradingNameLinkInOrganisationDetailsPage()
                .GiveATradingNameAndContinueInTradingNamePage()
                .SelectYesAndContinueInUseYourTradingNameOnTheRegisterPage()
                .EnterContactDetailsAndContinueInContactDetailsPage()
                .EnterContactDetailsAndContinueInContractNoticeToPage()
                .EnterUkprnAndContinueInDoYouHaveAUkprnPage()
                .EnterDetailsAndContinueInOEMPage()
                .EnterDetailsAndContinueInOfqualRecognitionNumberPage()
                .SelectPubliLimitedCompanyOptionAndContinueInTradingStatusPage()
                .EnterNumberAndContinueInCompanyNumberPage()
                .EnterNumberAndContinueInDirectoDetailsPage()
                .SelectNoOptionAndContinueInDirectorsDataPage()
                .EnterCharityDetailsAndContinueInRegisteredCharityPage()
                .SelectNoOptionAndContinueInRegisterOfRemovedTrusteesPage()
                .ClickReturnToApplicationOverviewButton();
        }

    }
}
