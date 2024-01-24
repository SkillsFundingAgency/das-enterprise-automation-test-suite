namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;

public class ASAdminLandingPage(ScenarioContext context) : ASLandingBasePage(context)
{
    public static string ASAdminPageTitle => "Apprenticeship service admin";

    protected override string PageTitle => ASAdminPageTitle;
}
