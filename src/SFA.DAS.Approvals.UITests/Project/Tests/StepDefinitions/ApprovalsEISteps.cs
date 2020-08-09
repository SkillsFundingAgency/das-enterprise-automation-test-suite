using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ApprovalsEISteps
    {
        private readonly ScenarioContext _context;
        private readonly EmployerSteps _employerSteps;
        private readonly ProviderSteps _providerSteps;

        public ApprovalsEISteps(ScenarioContext context)
        {
            _context = context;
            _employerSteps = new EmployerSteps(_context);
            _providerSteps = new ProviderSteps(_context);
        }

        [Given(@"the Employer adds (.*) apprentices with start date as JUL 2020")]
        public void GivenTheEmployerAddsApprenticesWithStartDateAsJUL2020(int numberOfApprentices)
        {
            _employerSteps.TheEmployerApprovesCohortAndSendsToProvider(numberOfApprentices);
            _providerSteps.TheProviderAddsUlnsAndApprovesTheCohorts();
        }
    }
}
