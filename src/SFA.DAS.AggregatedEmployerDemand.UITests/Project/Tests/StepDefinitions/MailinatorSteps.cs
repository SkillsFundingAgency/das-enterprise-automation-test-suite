using SFA.DAS.Mailinator.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class MailinatorSteps
    {
        private readonly ScenarioContext _context;
        
        public MailinatorSteps(ScenarioContext context) => _context = context;

        [Then(@"confirm the user is able to verify the email '(.*)'")]
        public void ThenConfirmTheUserIsAbleToVerifyTheEmail(string organisationEmailAddress) => new MailinatorStepsHelper(_context).VerifyLink(organisationEmailAddress);
    }
}
