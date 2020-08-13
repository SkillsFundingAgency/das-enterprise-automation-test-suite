using SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;
using static SFA.DAS.EmployerIncentives.UITests.Project.Helpers.EnumHelper;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EISteps
    {
        private readonly ScenarioContext _context;
        private YouCannotApplyForThisGrantYetPage _youCannotApplyForThisGrantYetPage;
        private HaveYouTakenOnNewApprenticesPage _haveYouTakenOnNewApprenticesPage;
        private ApplyForTheNewApprenticePaymentPage _applyForTheNewApprenticePaymentPage;

        public EISteps(ScenarioContext context) => _context = context;

        [When(@"the Employer Initiates EI Application journey for (Single|Multiple) entity account")]
        public void WhenTheEmployerInitiatesEIApplicationJourneyForSingleEntityAccount(Entities entities)
        {
            _applyForTheNewApprenticePaymentPage = new HomePageFinancesSection(_context).NavigateToEIStartPage();

            if (entities == Entities.Single)
                _haveYouTakenOnNewApprenticesPage = _applyForTheNewApprenticePaymentPage.ClickStartNowButtonInEIStartPageForSingleEntityJourney();
            else if (entities == Entities.Multiple)
                _haveYouTakenOnNewApprenticesPage = _applyForTheNewApprenticePaymentPage.ClickStartNowButtonInEIStartPageForMultipleEntityJourney().SelectFirstEntityInChooseOrgPageAndContinue();
        }

        [Then(@"No Eligible apprentices shutter page is displayed for selecting (Yes|No) option in Qualification page")]
        public void ThenNoEligibleApprenticesShutterPageIsDisplayedForSelectingYesOptionInQualificationPage(RadioOption selection)
        {
            if (selection == RadioOption.Yes)
                _youCannotApplyForThisGrantYetPage = _haveYouTakenOnNewApprenticesPage.SelectYesAndContinueForNoEligibleApprenticesScenario();
            else if (selection == RadioOption.No)
                _youCannotApplyForThisGrantYetPage = _haveYouTakenOnNewApprenticesPage.SelectNoAndContinueForNoEligibleApprenticesScenario();
        }

        [When(@"the Employer navigates back on No Eligible apprentices shutter page")]
        public void WhenTheEmployerNavigatesBackOnNoEligibleApprenticesShutterPage() =>
                _haveYouTakenOnNewApprenticesPage = _youCannotApplyForThisGrantYetPage.NavigateBrowserBack();

        [Then(@"Approvals home page is displayed on clicking on Add apprentices link")]
        public void ThenApprovalsHomePageIsDisplayedOnClickingOnAddApprenticesLink() => _youCannotApplyForThisGrantYetPage.ClickOnAddApprenticesLink();
    }
}
