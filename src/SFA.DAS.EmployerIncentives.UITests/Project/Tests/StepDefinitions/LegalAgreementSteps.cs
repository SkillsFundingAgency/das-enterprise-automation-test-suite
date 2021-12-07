using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerIncentives.UITests.Project.Helpers;
using SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class LegalAgreementSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly EINavigationHelper _eINavigationHelper;
        private QualificationQuestionPage _qualificationQuestionPage;

        public LegalAgreementSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _eINavigationHelper = new EINavigationHelper(_context);
        }

        [Given(@"the employer signs the agreement version 7")]
        public void GivenTheEmployerSignsTheAgreementVersion()
        {
            (string accountId, string _) = _context.Get<RegistrationSqlDataHelper>().GetAccountIds(_objectContext.GetRegisteredEmail());

            _context.Get<EISqlHelper>().SetSignedAgreementVersion(accountId);
        }

        [When(@"the Employer Initiates EI Application journey for version 4|5|6 legal agreement account")]
        public void TheEmployerInitiatesEIApplicationJourneyForSingleEntityAccount() =>
            _qualificationQuestionPage = _eINavigationHelper.NavigateToEISelectApprenticesPage();

        [Then(@"the Employer is shown the legal agreement shutter page")]
        public void ThenTheEmployerIsShownTheLegalAgreementShutterPage() => 
            _qualificationQuestionPage.SelectYesAndContinueForUnSignedAgreementScenario().ClickOnViewAgreementButton();
    }
}
