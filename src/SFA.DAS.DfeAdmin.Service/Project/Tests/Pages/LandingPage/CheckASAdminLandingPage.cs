namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;

public class CheckASAdminLandingPage : CheckASLandingPage
{
    protected override string PageTitle => ASAdminLandingPage.ASAdminPageTitle;

    protected override By Identifier => ASAdminLandingPage.ASAdminPageheader;

    public CheckASAdminLandingPage(ScenarioContext context) : base(context) { }
}
