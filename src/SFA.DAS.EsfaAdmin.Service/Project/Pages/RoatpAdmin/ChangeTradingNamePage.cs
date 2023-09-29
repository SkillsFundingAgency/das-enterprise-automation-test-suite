namespace SFA.DAS.EsfaAdmin.Service.Project.Pages.RoatpAdmin;

public class ChangeTradingNamePage : ChangeBasePage
{
    protected override string PageTitle => $"Change trading name for {objectContext.GetProviderName()}";

    protected override string AccessibilityPageTitle => "Change trading name for provider";

    public ChangeTradingNamePage(ScenarioContext context) : base(context) { }
}
