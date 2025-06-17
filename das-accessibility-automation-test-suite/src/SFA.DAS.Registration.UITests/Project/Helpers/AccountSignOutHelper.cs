namespace SFA.DAS.Registration.UITests.Project.Helpers;

public class AccountSignOutHelper(ScenarioContext context)
{
    public CreateAnAccountToManageApprenticeshipsPage SignOut() => new HomePage(context, true).SignOut().CickContinueInYouveLoggedOutPage().GoManageApprenticeLandingPage();

    public static YouveLoggedOutPage SignOut(HomePage page) => page.SignOut();

    public static YouveLoggedOutPage SignOut(AccountUnavailablePage page) => page.SignOut();
}
