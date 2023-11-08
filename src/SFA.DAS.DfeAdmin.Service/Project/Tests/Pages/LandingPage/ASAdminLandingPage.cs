namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;

public class ASAdminLandingPage : ASLandingBasePage
{
    public static string ASAdminPageTitle => "Apprenticeship service admin";

    public static By ASAdminPageheader => ASLandingPageheader;

    protected override string PageTitle => ASAdminPageTitle;

    public ASAdminLandingPage(ScenarioContext context) : base(context) { }

    public PreProdDIGBEADFSPage StartNow()
    {
        ClickStartNowButton();
        return new PreProdDIGBEADFSPage(context);
    }
}
