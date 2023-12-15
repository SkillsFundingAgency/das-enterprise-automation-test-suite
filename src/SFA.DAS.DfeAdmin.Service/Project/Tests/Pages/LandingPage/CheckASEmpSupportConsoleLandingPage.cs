namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;

public class CheckASEmpSupportConsoleLandingPage(ScenarioContext context) : CheckPageUsingPageTitle(context)
{
    protected override string PageTitle => ASEmpSupportConsoleLandingPage.ASEmpSupportConsolePageTitle;

    protected override By Identifier => ASLandingBasePage.ASLandingPageheader;
}
