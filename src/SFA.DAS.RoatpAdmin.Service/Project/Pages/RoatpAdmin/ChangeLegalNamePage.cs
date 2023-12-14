namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class ChangeLegalNamePage(ScenarioContext context) : ChangeBasePage(context)
{
    protected override string PageTitle => $"Change legal name for {objectContext.GetProviderName()}";

    protected override string AccessibilityPageTitle => "Change legal name for provider";
}
