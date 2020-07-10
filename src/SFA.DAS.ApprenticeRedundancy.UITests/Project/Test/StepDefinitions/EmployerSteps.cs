using SFA.DAS.ApprenticeRedundancy.UITests.Project.Helpers;
using SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.StepDefinitions
{
    [Binding]
    public class EmployerSteps
    {
        private readonly ScenarioContext _context;
        private readonly EmployerHelper _employerHelper;

        public EmployerSteps(ScenarioContext context) 
        {   _context = context;
            _employerHelper = new EmployerHelper(context);
        }     

        [Given(@"the Employer Completes Employer details form successfully")]
        public void GivenTheEmployerCompletesEmployerDetailsFormSuccessfully() => _employerHelper.CompleteEmployerForm_HappyPath(new MainLandingPage(_context));
    }
}
