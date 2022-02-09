using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ApprovalsSteps
    {
        private readonly AccountCreationStepsHelper _stepsHelper;

        public ApprovalsSteps(ScenarioContext context) => _stepsHelper = new AccountCreationStepsHelper(context);

        [Given(@"The User creates NonLevyEmployer account and sign an agreement")]
        [Given(@"The User creates LevyEmployer account and sign an agreement")]
        public void TheUserCreatesNonLevyEmployerAccountAndSignAnAgreement() => _stepsHelper.CreateUserAccount();
    }
}