namespace SFA.DAS.Registration.UITests.Project.Tests.Pages;

public class TransfersPage : RegistrationBasePage
{
    protected override string PageTitle => "Transfers";

    protected override bool TakeFullScreenShot => false;

    public TransfersPage(ScenarioContext context) : base(context) => VerifyPage();

}