namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class ChangeTradingNamePage(ScenarioContext context) : ChangeBasePage(context)
{
    protected override string PageTitle => $"Change trading name for {objectContext.GetProviderName()}";

    protected override string AccessibilityPageTitle => "Change trading name for provider";
}
