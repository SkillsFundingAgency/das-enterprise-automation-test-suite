namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class ChangeLegalNamePage : ChangeBasePage
{
    protected override string PageTitle => $"Change legal name for {objectContext.GetProviderName()}";

    protected override string AccessibilityPageTitle => "Change legal name for provider";

    public ChangeLegalNamePage(ScenarioContext context) : base(context) { }
}
