namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Provider;

public class ContactEmployerShutterPage : ProviderRelationshipsBasePage
{
    private static By GovBody => By.CssSelector(".govuk-body");

    protected override string PageTitle => "Contact the employer";


    public ContactEmployerShutterPage(ScenarioContext context) : base(context)
    {
        VerifyPage(GovBody, "You cannot add this employer because there are multiple organisations linked to their details.");
    }
}
