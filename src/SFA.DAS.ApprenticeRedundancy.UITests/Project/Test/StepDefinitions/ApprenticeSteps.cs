using SFA.DAS.ApprenticeRedundancy.UITests.Project.Helpers;
using SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.StepDefinitions
{
    [Binding]
    public class ApprenticeSteps
    {
        private readonly ScenarioContext _context;
        private readonly ApprenticeHelper _apprenticeHelper;

        public ApprenticeSteps(ScenarioContext context)
        {
            _context = context;
            _apprenticeHelper = new ApprenticeHelper(context);
        }

        [Given(@"the Apprentice Completes Apprentice details form successfully")]
        public void GivenTheApprenticeCompletesApprenticeDetailsFormSuccessfully() => _apprenticeHelper.CompleteApprenticeForm_HappyPath(new MainLandingPage(_context));

    }
}
