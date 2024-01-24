namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class ChangeCompanyNumberPage(ScenarioContext context) : ChangeBasePage(context)
{
    protected override string PageTitle => $"Change company number for {objectContext.GetProviderName()}";

    protected override string AccessibilityPageTitle => "Change company number for provider";
}
