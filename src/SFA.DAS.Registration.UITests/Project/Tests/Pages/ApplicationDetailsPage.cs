namespace SFA.DAS.Registration.UITests.Project.Tests.Pages;
public class ApplicationDetailsPage : RegistrationBasePage
{
    protected override string PageTitle => "application details";
    public ApplicationDetailsPage(ScenarioContext context) : base(context) => VerifyPage();
}