namespace SFA.DAS.EsfaAdmin.Service.Project.Pages.RoatpAdmin;

public class ChangeCompanyNumberPage : ChangeBasePage
{
    protected override string PageTitle => $"Change company number for {objectContext.GetProviderName()}";

    protected override string AccessibilityPageTitle => "Change company number for provider";

    public ChangeCompanyNumberPage(ScenarioContext context) : base(context) { }

}
