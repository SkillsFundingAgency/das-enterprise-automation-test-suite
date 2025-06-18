namespace SFA.DAS.Registration.UITests.Project.Tests.Pages;

public class ManageYourApprenticesPage : RegistrationBasePage
{
    protected override string PageTitle => "Manage your apprentices";

    protected override bool TakeFullScreenShot => false;

    public ManageYourApprenticesPage(ScenarioContext context) : base(context) => VerifyPage();

}