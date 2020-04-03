using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ApprovalsSteps
    {
        private readonly ScenarioContext _context;
        private readonly ApprovalsStepsHelper _stepsHelper;

        public ApprovalsSteps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new ApprovalsStepsHelper(context);
        }

        [Given(@"The User creates Employer account and sign an agreement")]
        public void TheUserCreatesEmployerAccountAndSignAnAgreement()
        {
            _stepsHelper.CreatesAccountAndSignAnAgreement();
        }
    }
}
