using SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ExistingUserSteps
    {
        private readonly ScenarioContext _context;

        public ExistingUserSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Given(@"an existing user emails the helpdesk")]
        public void GivenAnExistingUserEmailsTheHelpdesk()
        {
            new SignInPage(_context).SignIntoApprenticeshipServiceSupport();
        }

    }
}
