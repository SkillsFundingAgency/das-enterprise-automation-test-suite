using SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;
using static SFA.DAS.EmployerIncentives.UITests.Project.Helpers.EnumHelper;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EISteps
    {
        private readonly ScenarioContext _context;
        private EIStartPage _eIStartPage;
        private SelectApprenticesShutterPage _selectApprenticesShutterPage;
        private QualificationQuestionPage _qualificationQuestionPage;
        private QualificationQuestionShutterPage _qualificationQuestionShutterPage;
        private EmployerAgreementShutterPage _employerAgreementShutterPage;

        public EISteps(ScenarioContext context) => _context = context;

        [When(@"the Employer navigates back to Qualification page for (Single|Multiple) entity account")]
        [When(@"the Employer Initiates EI Application journey for (Single|Multiple) entity account")]
        public void WhenTheEmployerInitiatesEIApplicationJourneyForSingleEntityAccount(Entities entities)
        {
            _eIStartPage = new HomePageFinancesSection(_context).NavigateToEIStartPage();

            if (entities == Entities.Single)
                _qualificationQuestionPage = _eIStartPage.ClickStartNowButtonInEIStartPageForSingleEntityJourney();
            else if (entities == Entities.Multiple)
                _qualificationQuestionPage = _eIStartPage.ClickStartNowButtonInEIStartPageForMultipleEntityJourney().SelectFirstEntityInChooseOrgPageAndContinue();
        }

        [Then(@"Select apprentices shutter page is displayed for selecting Yes option in Qualification page")]
        public void ThenSelectApprenticesShutterPageIsDisplayedForSelectingYesOptionInQualificationPage() =>
            _selectApprenticesShutterPage = _qualificationQuestionPage.SelectYesAndContinueForNoEligibleApprenticesScenario();

        [Then(@"Qualification question shutter page is displayed for selecting No option in Qualification page")]
        public void ThenQualificationQuestionShutterPageIsDisplayedForSelectingNoOptionInQualificationPage() =>
            _qualificationQuestionShutterPage = _qualificationQuestionPage.SelectNoAndContinue();

        [Then(@"Approvals home page is displayed on clicking on Add apprentices link on Select apprentices shutter page")]
        public void ThenApprovalsHomePageIsDisplayedOnClickingOnAddApprenticesLinkOnSelectApprenticesShutterPage() => _selectApprenticesShutterPage.ClickOnAddApprenticesLink();

        [Then(@"Employer Home page is displayed on clicking on Return to Account Home button on Qualification shutter page")]
        public void ThenEmployerHomePageIsDisplayedOnClickingOnReturnToAccountHomeButtonOnQualificatioShutterPage() => _qualificationQuestionShutterPage.ClickOnReturnToAccountHomeLink();

        [Then(@"Employer agreement shutter page is displayed for selecting Yes option in the Qualification page")]
        public void ThenEmployerAgreementShutterPageIsDisplayedForSelectingYesOptionInTheQualificationPage() =>
            _employerAgreementShutterPage = _qualificationQuestionPage.SelectYesAndContinueForUnSignedAgreementScenario();

        [Then(@"Employer Home page is displayed on clicking on Return to Account home link on Employer agreement shutter page")]
        public void ThenEmployerHomePageIsDisplayedOnClickingOnReturnToAccountHomeLinkOnEmployerAgreementShutterPage() => 
            _employerAgreementShutterPage.ClickOnReturnToAccountHomeLink();

        [Then(@"Your Agreements page is displayed on clicking on View agreement button on Employer agreement shutter page")]
        public void ThenYourAgreementsPageIsDisplayedOnClickingOnViewAgreementButtonOnEmployerAgreementShutterPage() =>
            _employerAgreementShutterPage.ClickOnViewAgreementButton();
    }
}
