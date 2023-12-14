namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;

public class CheckASEmpSupportToolLandingPage : CheckPageUsingPageTitle
{
    protected override string PageTitle => ASEmpSupportToolLandingPage.ASEmpSupportToolPageTitle;

    protected override By Identifier => ASLandingBasePage.ASLandingPageheader;

    public CheckASEmpSupportToolLandingPage(ScenarioContext context) : base(context) { }
}