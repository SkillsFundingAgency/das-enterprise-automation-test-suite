namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice;

public class RegistrationCompletePage(ScenarioContext context) : AanBasePage(context)
{
    protected override string PageTitle => "Registration complete";

    private static By NetworkHubLink => By.CssSelector("a[href='/network-hub ']");

    public Apprentice_NetworkHubPage ContinueToAmbassadorHub()
    {
        formCompletionHelper.Click(NetworkHubLink);

        return new Apprentice_NetworkHubPage(context);
    }
}