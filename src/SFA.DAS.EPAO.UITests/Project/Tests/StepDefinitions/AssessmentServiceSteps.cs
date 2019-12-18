using SFA.DAS.EPAO.UITests.Project.Helpers;
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

        [When(@"the User goes through certifying an Apprentice who has enrolled for '(.*)' standard")]
        public void WhenTheUserGoesThroughCertifyingAnApprenticeWhoHasEnrolledForStandard(string enrolledStandards)
        {
            _stepsHelper.CertifyApprentice(enrolledStandards);
        }

        [Then(@"the Assessment is recorded successfully")]
        public void ThenTheAssessmentIsRecordedSuccessfully()
        {

        }

        [Then(@"the User is able to navigate back to certifying another Apprentice")]
        public void ThenTheUserIsAbleToNavigateBackToCertifyingAnotherApprentice()
        {

        }
    }
}
