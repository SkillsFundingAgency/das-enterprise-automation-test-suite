namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages;

public class ApplicationSubmittedPage : SignInPage
{
    protected override string PageTitle => "Application submitted";

    private static By NetworkHubLink => By.CssSelector("a[href='/network-hub ']");

    public ApplicationSubmittedPage(ScenarioContext context) : base(context) => VerifyPage();

    public NetworkHubPage ContinueToAmbassadorHub()
    {
        formCompletionHelper.Click(NetworkHubLink);

        return new NetworkHubPage(context);
    }
}