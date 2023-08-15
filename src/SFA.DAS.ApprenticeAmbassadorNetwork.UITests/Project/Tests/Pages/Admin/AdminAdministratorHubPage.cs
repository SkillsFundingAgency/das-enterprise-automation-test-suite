namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin;

public class AdminAdministratorHubPage : AanBasePage
{
    protected override string PageTitle => "Administrator hub";

    public AdminAdministratorHubPage(ScenarioContext context) : base(context) => VerifyPage();
}