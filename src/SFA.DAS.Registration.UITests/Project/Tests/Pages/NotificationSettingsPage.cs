namespace SFA.DAS.Registration.UITests.Project.Tests.Pages;

public class NotificationSettingsPage : RegistrationBasePage
{
    protected override string PageTitle => "Notification settings";

    public NotificationSettingsPage(ScenarioContext context) : base(context) => VerifyPage();

}