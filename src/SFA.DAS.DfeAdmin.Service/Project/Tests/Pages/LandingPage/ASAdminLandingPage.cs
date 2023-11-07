namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;

public class ASAdminLandingPage : IdamsLoginBasePage
{
    public static string ASAdminPageTitle => "Apprenticeship service admin";

    public static By ASAdminPageheader => By.CssSelector(".govuk-heading-l");

    protected override string PageTitle => ASAdminPageTitle;

    protected override By PageHeader => ASAdminPageheader;

    public ASAdminLandingPage(ScenarioContext context) : base(context) { }

    public PreProdDIGBEADFSPage StartNow()
    {
        ClickStartNowButton();
        return new PreProdDIGBEADFSPage(context);
    }
}
