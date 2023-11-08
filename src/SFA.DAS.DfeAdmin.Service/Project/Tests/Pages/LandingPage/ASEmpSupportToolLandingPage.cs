namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;

public class ASEmpSupportToolLandingPage : ASLandingBasePage
{
    public static string ASEmpSupportToolPageTitle => "Apprenticeship service bulk stop utility";

    public static By ASEmpSupportToolPageheader => ASLandingPageheader;

    protected override string PageTitle => ASEmpSupportToolPageTitle;

    public ASEmpSupportToolLandingPage(ScenarioContext context) : base(context) { }
}
