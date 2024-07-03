namespace SFA.DAS.Live.SmokeTests.Project.Tests.Steps;

[Binding]
public class CommonSteps(ScenarioContext context)
{
    [Given(@"the Employer logins using existing Levy Account")]
    public void TheEmployerLoginsUsingExistingLevyAccount()
    {
        new SignInToYourApprenticeshipServiceAccountPage(context)
            .SignInToYourApprenticeshipServiceAccount()
            .SignInToGovUkLogin()
            .EnterUsername()
            .EnterPassword()
            .EnterCode();
    }
}


