namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class OrganisationsDetailsPage(ScenarioContext context) : RoatpAdminBasePage(context)
{
    protected override string PageTitle => "Organisation's details";

    protected override By ContinueButton => By.CssSelector(".govuk-button[value='Continue']");

    public ProviderRoutePage ConfirmOrganisationsDetails()
    {
        Continue();
        return new ProviderRoutePage(context);
    }
}
