namespace SFA.DAS.IdamsLogin.Service.Project.Tests.Pages.LandingPage;

public class ApprenticeshipServiceAdminLandingPage : IdamsLoginBasePage
{
    protected override string PageTitle => "Apprenticeship service admin";

    public ApprenticeshipServiceAdminLandingPage(ScenarioContext context) : base(context) { }

    public PreProdDIGBEADFSPage StartNow()
    {
        ClickStartNowButton();
        return new PreProdDIGBEADFSPage(context);
    }
}
