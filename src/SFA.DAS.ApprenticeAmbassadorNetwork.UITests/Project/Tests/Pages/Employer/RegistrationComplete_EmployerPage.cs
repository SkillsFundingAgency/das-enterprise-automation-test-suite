namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer;

public class RegistrationComplete_EmployerPage(ScenarioContext context) : AanBasePage(context)
{
    protected override string PageTitle => "Registration complete";

    public Employer_NetworkHubPage ContinueToAmbassadorHub()
    {
        Continue();

        return new Employer_NetworkHubPage(context);
    }
}