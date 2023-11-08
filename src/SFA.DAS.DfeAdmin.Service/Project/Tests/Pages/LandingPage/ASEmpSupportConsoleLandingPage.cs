namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;

public class ASEmpSupportConsoleLandingPage : ASLandingBasePage
{
    public static string ASEmpSupportConsolePageTitle => "Apprenticeship service employer support tool";

    public static By ASEmpSupportonsolePageheader => ASLandingPageheader;

    protected override string PageTitle => ASEmpSupportConsolePageTitle;

    public ASEmpSupportConsoleLandingPage(ScenarioContext context) : base(context) { }
}