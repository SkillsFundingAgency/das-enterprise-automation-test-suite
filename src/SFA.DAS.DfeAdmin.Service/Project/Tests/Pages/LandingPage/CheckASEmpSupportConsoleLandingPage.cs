namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;

public class CheckASEmpSupportConsoleLandingPage : CheckASLandingPage
{
    protected override string PageTitle => ASEmpSupportConsoleLandingPage.ASEmpSupportConsolePageTitle;

    protected override By Identifier => ASEmpSupportConsoleLandingPage.ASEmpSupportonsolePageheader;

    public CheckASEmpSupportConsoleLandingPage(ScenarioContext context) : base(context) { }
}
