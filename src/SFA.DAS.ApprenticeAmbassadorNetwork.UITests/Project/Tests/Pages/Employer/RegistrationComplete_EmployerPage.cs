namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer;

public class RegistrationComplete_EmployerPage : AanBasePage
{
    protected override string PageTitle => "Registration complete";

    public RegistrationComplete_EmployerPage(ScenarioContext context) : base(context) => VerifyPage();

    public Employer_NetworkHubPage ContinueToAmbassadorHub()
    {
        Continue();

        return new Employer_NetworkHubPage(context);
    }
}