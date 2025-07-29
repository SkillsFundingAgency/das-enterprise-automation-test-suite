namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class ChangeProviderTypePage(ScenarioContext context) : ChangeBasePage(context)
{
    protected override string PageTitle => $"Change provider type for {objectContext.GetProviderName()}";

    protected override string AccessibilityPageTitle => "Change provider type for provider";

    public ResultsFoundPage ConfirmNewProviderTypeAsEmloyer()
    {
        SelectRadioOptionByText("Employer provider");
        Continue();
        return new ResultsFoundPage(context);
    }

    public ResultsFoundPage ConfirmNewProviderTypeAsMain()
    {
        SelectRadioOptionByText("Main provider");
        Continue();
        return new ResultsFoundPage(context);
    }
}
