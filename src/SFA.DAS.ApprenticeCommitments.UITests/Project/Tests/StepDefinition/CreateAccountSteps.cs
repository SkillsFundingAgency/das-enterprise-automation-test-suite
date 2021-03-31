using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class CreateAccountSteps : BaseSteps
    {
        public CreateAccountSteps(ScenarioContext context) : base(context) { }

        [When(@"employer or provider submits the details to create an account")]
        public void WhenEmployerOrProviderSubmitsTheDetailsToCreateAnAccount() => appreticeCommitmentsStepsHelper.CreateApprenticeship();

        [Then(@"the apprentice is able to create an account using the invitation")]
        public void ThenTheApprenticeIsAbleToCreateAnAccountUsingTheInvitation() => appreticeCommitmentsStepsHelper.CreateAccount(false);

        [Then(@"an error is shown for invalid passwords")]
        public void ThenAnErrorIsShownForInvalidPasswords()
        {
            var createPasswordPage = appreticeCommitmentsStepsHelper.GetCreatePasswordPage();

            appreticeCommitmentsStepsHelper.InvalidPassword(createPasswordPage);
        }
    }
}
