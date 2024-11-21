namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Provider;

public class EmailAccountFoundPage : ProviderRelationshipsBasePage
{
    protected override By ContinueButton => By.CssSelector("a.govuk-button[href*='addEmployer']");

    private static By GovBody => By.CssSelector(".govuk-body");

    protected override string PageTitle => "Account found";

    private readonly string email;

    public EmailAccountFoundPage(ScenarioContext context, string email) : base(context)
    {
        this.email = email;

        VerifyPage(GovBody, email);
    }

    public void VerifyAlreadyLinkedToThisEmployer()
    {
        VerifyPage(GovBody, $"We’ve found an apprenticeship service account linked to {email}. Your organisation is already linked to this employer.");
    }

    public AddEmployerAndRequestPermissionsPage ContinueToInvite()
    {
        Continue();

        return new(context);
    }
}
