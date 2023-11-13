namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class ChangeApplicationDateDeterminedPage : ChangeBasePage
{
    protected override string PageTitle => $"Change application determined date for {objectContext.GetProviderName()}";

    protected override string AccessibilityPageTitle => "Change application determined date for provider";

    public ChangeApplicationDateDeterminedPage(ScenarioContext context) : base(context) { }

}
