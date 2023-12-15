namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;

public class CheckASAdminLandingPage(ScenarioContext context) : CheckPageUsingPageTitle(context)
{
    protected override string PageTitle => ASAdminLandingPage.ASAdminPageTitle;

    protected override By Identifier => ASLandingBasePage.ASLandingPageheader;
}
