namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice;

public class RegistrationCompletePage : AanBasePage
{
    protected override string PageTitle => "Registration complete";

    private static By NetworkHubLink => By.CssSelector("a[href='/network-hub ']");

    public RegistrationCompletePage(ScenarioContext context) : base(context) => VerifyPage();

    public Apprentice_NetworkHubPage ContinueToAmbassadorHub()
    {
        formCompletionHelper.Click(NetworkHubLink);

        return new Apprentice_NetworkHubPage(context);
    }
}