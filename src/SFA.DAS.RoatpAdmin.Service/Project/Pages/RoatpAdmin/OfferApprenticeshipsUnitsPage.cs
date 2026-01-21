namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class OfferApprenticeshipsUnitsPage(ScenarioContext context) : ChangeBasePage(context)
{
    protected override string PageTitle => $"Change company number for {objectContext.GetProviderName()}";

    protected override string AccessibilityPageTitle => "Change company number for provider";

    public ResultsFoundPage ConfirmOfferApprenticeshipsUnits_NO()
    {
        SelectRadioOptionByText("No");
        Continue();
        return new ResultsFoundPage(context);
    }
}
}
