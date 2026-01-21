namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class OfferApprenticeshipPage(ScenarioContext context) : ChangeBasePage(context)
{
    protected override string PageTitle => "Do they offer apprenticeships?";

    protected override string AccessibilityPageTitle => "update apprenticeships";

    public OfferApprenticeshipsUnitsPage ConfirmOfferApprenticeships()
    {
        SelectRadioOptionByText("Yes");
        Continue();
        return new OfferApprenticeshipsUnitsPage(context);
    }
}
