using SFA.DAS.Live.SmokeTests.Project.Tests.Pages;

namespace SFA.DAS.Live.SmokeTests.Project.Tests.Steps;

[Binding]
public class Steps(ScenarioContext context)
{
    private HomePage _homePage;

    [Given(@"the Employer logins using existing Levy Account")]
    public void TheEmployerLoginsUsingExistingLevyAccount()
    {
        _homePage = new SignInToYourApprenticeshipServiceAccountPage(context)
            .SignInToYourApprenticeshipServiceAccount()
            .SignInToGovUkLogin()
            .EnterUsername()
            .EnterPassword()
            .EnterCode();
            
    }

    [Then(@"Employer is able to navigate to all the link under Settings")]
    public void EmployerIsAbleToNavigateToAllTheLinkUnderSettings()
    {

    }

    [Then(@"Employer is able to navigate to Help Page")]
    public void EmployerIsAbleToNavigateToHelpPage()
    {

    }

}


