namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;

public class CheckASAdminLandingPage : CheckASLandingBasePage
{
    protected override string PageTitle => ASAdminLandingPage.ASAdminPageTitle;

    protected override By Identifier => ASLandingBasePage.ASLandingPageheader;

    public CheckASAdminLandingPage(ScenarioContext context) : base(context) { }
}
