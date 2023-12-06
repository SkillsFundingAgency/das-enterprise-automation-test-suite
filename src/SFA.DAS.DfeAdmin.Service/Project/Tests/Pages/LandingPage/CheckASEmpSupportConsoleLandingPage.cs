namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;

public class CheckASEmpSupportConsoleLandingPage : CheckPageUsingPageTitle
{
    protected override string PageTitle => ASEmpSupportConsoleLandingPage.ASEmpSupportConsolePageTitle;

    protected override By Identifier => ASLandingBasePage.ASLandingPageheader;

    public CheckASEmpSupportConsoleLandingPage(ScenarioContext context) : base(context) { }
}
