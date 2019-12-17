using SFA.DAS.EPAO.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AssessmentServiceSteps
    {
        private readonly ScenarioContext _context;
        private readonly AssessmentServiceStepsHelper _stepsHelper;
        private readonly EPAODataHelper _ePAODataHelper;
        private readonly SqlDatabaseConnectionHelper _sqlDatabaseConnectionHelper;

        public AssessmentServiceSteps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new AssessmentServiceStepsHelper(_context);
            _ePAODataHelper = context.Get<EPAODataHelper>();
            _sqlDatabaseConnectionHelper = context.Get<SqlDatabaseConnectionHelper>();
        }

        [Given(@"the User is logged into Assessment Service Application")]
        public void GivenTheUserIsLoggedIntoAssessmentServiceApplication()
        {
            _stepsHelper.LoginToAssessmentServiceApplication();
        }

        [When(@"the User goes through certifying an Apprentice who has enrolled for '(.*)' standard")]
        public void WhenTheUserGoesThroughCertifyingAnApprenticeWhoHasEnrolledForStandard(string enrolledStandards)
        {
            
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
