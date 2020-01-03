using SFA.DAS.EPAO.UITests.Project.Helpers;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AssessmentServiceSteps
    {
        private readonly ScenarioContext _context;
        private readonly AssessmentServiceStepsHelper _stepsHelper;
        private readonly EPAOConfig _ePAOConfig;
        private AS_RecordAGradePage recordAGradePage;

        public AssessmentServiceSteps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new AssessmentServiceStepsHelper(_context);
            _ePAOConfig = context.GetEPAOConfig<EPAOConfig>();
        }

        [Given(@"the User is logged into Assessment Service Application")]
        public void GivenTheUserIsLoggedIntoAssessmentServiceApplication()
        {
            _stepsHelper.LoginToAssessmentServiceApplication();
        }

        [When(@"the User goes through certifying an Apprentice as '(.*)' who has enrolled for '(.*)' standard")]
        public void WhenTheUserGoesThroughCertifyingAnApprenticeAsWhoHasEnrolledForStandard(string grade, string enrolledStandard)
        {
            _stepsHelper.CertifyApprentice(grade, enrolledStandard);
        }

        [When(@"the User goes through certifying a Privately funded Apprentice")]
        public void WhenTheUserGoesThroughCertifyingAPrivatelyFundedApprentice()
        {
            _stepsHelper.CertifyPrivatelyFundedApprentice();
        }


        [Then(@"the Assessment is recorded and the User is able to navigate back to certifying another Apprentice")]
        public void ThenTheAssessmentIsRecordedAndTheUserIsAbleToNavigateBackToCertifyingAnotherApprentice()
        {
            new AS_AssessmentRecordedPage(_context).ClickRecordAnotherGradeLinkInAssessmentRecordedPage();
        }

        [When(@"the User goes through certifying an already assessed Apprentice")]
        public void WhenTheUserGoesThroughCertifyingAnAlreadyAssessedApprentice()
        {
            new AS_LoggedInHomePage(_context).ClickOnRecordAGrade();
            recordAGradePage = new AS_RecordAGradePage(_context);
            recordAGradePage.EnterApprentcieDetailsAndContinue(_ePAOConfig.EPAOAlreadyAssessedApprenticeName, _ePAOConfig.EPAOAlreadyAssessedApprenticeUln);
        }

        [Then(@"'(.*)' message is displayed")]
        public void ThenMessageIsDisplayed(string errorMessage)
        {
            recordAGradePage.VerifyErrorMessage(errorMessage);
        }
    }
}
