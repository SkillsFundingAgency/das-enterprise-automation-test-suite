using SFA.DAS.EPAO.UITests.Project.Helpers;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AssessmentServiceSteps
    {
        private readonly ScenarioContext _context;
        private readonly AssessmentServiceStepsHelper _stepsHelper;

        public AssessmentServiceSteps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new AssessmentServiceStepsHelper(_context);
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

        [Then(@"the Assessment is recorded and the User is able to navigate back to certifying another Apprentice")]
        public void ThenTheAssessmentIsRecordedAndTheUserIsAbleToNavigateBackToCertifyingAnotherApprentice()
        {
            new AS_AssessmentRecordedPage(_context).ClickRecordAnotherGradeLinkInAssessmentRecordedPage();
        }
    }
}
