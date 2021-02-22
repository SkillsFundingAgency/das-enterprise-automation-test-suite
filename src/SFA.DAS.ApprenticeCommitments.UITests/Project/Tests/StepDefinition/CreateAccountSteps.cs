using SFA.DAS.UI.Framework.TestSupport;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class CreateAccountSteps : BaseSteps
    {
        protected readonly ApprenticeCommitmentsConfig config;

        public CreateAccountSteps(ScenarioContext context) : base(context) => config = context.GetApprenticeCommitmentsConfig<ApprenticeCommitmentsConfig>();

        [When(@"employer or provider submits the details to create an account")]
        public void WhenEmployerOrProviderSubmitsTheDetailsToCreateAnAccount() => appreticeCommitmentsStepsHelper.CreateApprenticeship();

        [Then(@"the apprentice is able to create an account using the invitation")]
        public void ThenTheApprenticeIsAbleToCreateAnAccountUsingTheInvitation() => appreticeCommitmentsStepsHelper.CreatePassword();

        [Then(@"an error is shown for invalid passwords")]
        public void ThenAnErrorIsShownForInvalidPasswords()
        {
            var passwordPage = appreticeCommitmentsStepsHelper.GetCreatePasswordPage();

            var invalidPasswords = new List<string []> 
            {
                new string [] { config.AC_AccountPassword, $"{config.AC_AccountPassword}1" },
                new string [] { "invalidpassword", "invalidpassword" },
                new string [] { "234547896", "234547896" },
                new string [] { "ac1234", "ac1234" },
                new string [] { "AccountsPassword123", "AccountsPassword123" }
            };

            foreach (var invalidPassword in invalidPasswords)
            {
                passwordPage = passwordPage.InvalidPassword(invalidPassword[0], invalidPassword[1]);

                passwordPage.VerifyErrorSummary();
            }
        }
    }
}
