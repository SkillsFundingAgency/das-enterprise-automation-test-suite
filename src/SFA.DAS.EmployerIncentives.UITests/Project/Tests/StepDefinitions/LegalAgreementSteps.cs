using SFA.DAS.EmployerIncentives.UITests.Project.Helpers;
using SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class LegalAgreementSteps
    {
        private readonly ScenarioContext _context;
        private readonly EINavigationHelper _eINavigationHelper;
        private QualificationQuestionPage _qualificationQuestionPage;

        public LegalAgreementSteps(ScenarioContext context)
        {
            _context = context;
            _eINavigationHelper = new EINavigationHelper(_context);
        }

        [When(@"the Employer Initiates EI Application journey for version 4 legal agreement account")]
        [When(@"the Employer Initiates EI Application journey for version 5 legal agreement account")]

        public void TheEmployerInitiatesEIApplicationJourneyForSingleEntityAccount() =>
            _qualificationQuestionPage = _eINavigationHelper.NavigateToEISelectApprenticesPage();

        [Then(@"the Employer is shown the legal agreement shutter page")]
        public void ThenTheEmployerIsShownTheLegalAgreementShutterPage()
        {
            _qualificationQuestionPage
                .SelectYesAndContinueForUnSignedAgreementScenario()
                .ClickOnViewAgreementButton();
        }
    }
}
