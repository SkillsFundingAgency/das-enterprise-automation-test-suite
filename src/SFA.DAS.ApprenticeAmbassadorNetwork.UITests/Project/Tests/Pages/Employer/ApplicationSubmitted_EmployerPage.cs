namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer;

public class ApplicationSubmitted_EmployerPage : AanBasePage
{
    protected override string PageTitle => "Application submitted";

    public ApplicationSubmitted_EmployerPage(ScenarioContext context) : base(context) => VerifyPage();

    public Employer_NetworkHubPage ContinueToAmbassadorHub()
    {
        Continue();

        return new Employer_NetworkHubPage(context);
    }
}