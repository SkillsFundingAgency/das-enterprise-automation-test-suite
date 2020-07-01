using SFA.DAS.ApprenticeRedundancy.UITests.Project.Helpers;
using SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.StepDefinitions
{
    [Binding]
    public class EmployerSteps
    {
        private readonly ScenarioContext _context;
        private readonly ApprenticeHelpers _apprenticeHeleprs;

        public EmployerSteps(ScenarioContext context) 
        {   _context = context;
            _apprenticeHeleprs = new ApprenticeHelpers(context);
        }     

        [Given(@"the Employer Completes Employer details form successfully")]
        public void GivenTheEmployerCompletesEmployerDetailsFormSuccessfully() => _apprenticeHeleprs.CompleteApprenticeForm_HappyPath(new MainLandingPage(_context));
    }
}
