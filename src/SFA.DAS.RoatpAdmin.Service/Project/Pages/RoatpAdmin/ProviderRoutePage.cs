namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class ProviderRoutePage(ScenarioContext context) : RoatpAdminBasePage(context)
{
    protected override string PageTitle => $"Choose a provider route for {objectContext.GetProviderName()}";

    protected override string AccessibilityPageTitle => "Change a provider route for provider";


    protected override By ContinueButton => By.CssSelector(".govuk-button[value='Continue']");

    public TypeOrganisationsPage SubmitProviderType(string providerType)
    {
        SelectRadioOptionByText(providerType);
        Continue();
        return new TypeOrganisationsPage(context);
    }
}
