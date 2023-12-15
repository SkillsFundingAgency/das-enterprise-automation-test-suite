namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class ConfirmDetailsPage(ScenarioContext context) : RoatpAdminBasePage(context)
{
    protected override string PageTitle => "Confirm details";

    protected override By ContinueButton => By.CssSelector(".govuk-button[value='Confirm and add organisation']");

    public SearchPage ConfirmOrganisationsDetails()
    {
        Continue();
        return new SearchPage(context);
    }
}
