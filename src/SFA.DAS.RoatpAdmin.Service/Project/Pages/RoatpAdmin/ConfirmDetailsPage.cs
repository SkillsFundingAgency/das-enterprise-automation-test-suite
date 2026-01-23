namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class ConfirmDetailsPage(ScenarioContext context) : RoatpAdminBasePage(context)
{
    protected override string PageTitle => "Confirm details";

    protected override By ContinueButton => By.Id("confirm");

    public SuccessPage ConfirmOrganisationsDetails()
    {
        Continue();
        return new SuccessPage(context);
    }
}
