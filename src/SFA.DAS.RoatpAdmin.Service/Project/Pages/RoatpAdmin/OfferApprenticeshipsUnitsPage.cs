namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class OfferApprenticeshipsUnitsPage(ScenarioContext context) : ChangeBasePage(context)
{
    protected override string PageTitle => "Do they offer apprenticeship units?";

    protected override string AccessibilityPageTitle => "Do they offer apprenticeship units?";

    public ResultsFoundPage ConfirmOfferApprenticeshipsUnits_NO()
    {
        SelectRadioOptionByText("No");
        Continue();
        return new ResultsFoundPage(context);
    }
    public TypeOrganisationsPage ConfirmOfferApprenticeshipsUnits_NO_AddJourney()
    {
        SelectRadioOptionByText("No");
        Continue();
        return new TypeOrganisationsPage(context);
    }
}

