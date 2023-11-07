namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;

public class ASEmpSupportToolLandingPage : IdamsLoginBasePage
{
    public static string ASEmpSupportToolPageTitle => "Apprenticeship service employer support tool";

    public static By ASEmpSupportToolPageheader => By.CssSelector(".govuk-heading-l");

    protected override string PageTitle => ASEmpSupportToolPageTitle;

    protected override By PageHeader => ASEmpSupportToolPageheader;

    public ASEmpSupportToolLandingPage(ScenarioContext context) : base(context) { }
}
