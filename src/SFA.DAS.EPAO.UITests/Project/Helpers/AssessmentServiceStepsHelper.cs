using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Helpers
{
    public class AssessmentServiceStepsHelper
    {

        private readonly ScenarioContext _context;

        public AssessmentServiceStepsHelper(ScenarioContext context)
        {
            _context = context;
        }

        public void LoginToAssessmentServiceApplication() => new AS_LandingPage(_context).ClickStartButton().SignInWithValidDetails();
    }
}
