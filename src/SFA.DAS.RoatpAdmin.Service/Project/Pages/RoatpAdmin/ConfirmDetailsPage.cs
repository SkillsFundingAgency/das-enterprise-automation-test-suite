namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class ConfirmDetailsPage : RoatpAdminBasePage
{
    protected override string PageTitle => "Confirm details";

    protected override By ContinueButton => By.CssSelector(".govuk-button[value='Confirm and add organisation']");

    public ConfirmDetailsPage(ScenarioContext context) : base(context) { }

    public SearchPage ConfirmOrganisationsDetails()
    {
        Continue();
        return new SearchPage(context);
    }
}
