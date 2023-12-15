namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;

public class CheckASEmpSupportToolLandingPage(ScenarioContext context) : CheckPageUsingPageTitle(context)
{
    protected override string PageTitle => ASEmpSupportToolLandingPage.ASEmpSupportToolPageTitle;

    protected override By Identifier => ASLandingBasePage.ASLandingPageheader;
}