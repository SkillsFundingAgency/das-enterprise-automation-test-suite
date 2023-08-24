namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice;

public class ApplicationSubmittedPage : SignInPage
{
    protected override string PageTitle => "Application submitted";

    private By NetworkHubLink => By.CssSelector("a[href='/network-hub ']");

    public ApplicationSubmittedPage(ScenarioContext context) : base(context) => VerifyPage();

    public Apprentice_NetworkHubPage ContinueToAmbassadorHub()
    {
        formCompletionHelper.Click(NetworkHubLink);

        return new Apprentice_NetworkHubPage(context);
    }
}