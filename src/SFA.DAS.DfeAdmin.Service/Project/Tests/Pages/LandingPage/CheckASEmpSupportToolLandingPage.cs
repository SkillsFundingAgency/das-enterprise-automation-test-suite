namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;

public class CheckASEmpSupportToolLandingPage : CheckASLandingPage
{
    protected override string PageTitle => ASEmpSupportToolLandingPage.ASEmpSupportToolPageTitle;

    protected override By Identifier => ASEmpSupportToolLandingPage.ASEmpSupportToolPageheader;

    public CheckASEmpSupportToolLandingPage(ScenarioContext context) : base(context) { }
}
