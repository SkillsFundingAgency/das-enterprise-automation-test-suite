namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.Relationships;

public abstract class EmployerProviderRelationshipsBasePage : RegistrationBasePage
{
    protected EmployerProviderRelationshipsBasePage(ScenarioContext context) : base(context) => VerifyPage();

    protected override By ContinueButton => By.CssSelector("button[id='continue'][type='submit']");
}
