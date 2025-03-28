namespace SFA.DAS.Registration.UITests.Project.Tests.Pages;
public class MyTransferApplicationsPage : RegistrationBasePage
{
    protected override string PageTitle => "My applications";
    public MyTransferApplicationsPage(ScenarioContext context) : base(context) => VerifyPage();
}