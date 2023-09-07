namespace SFA.DAS.EsfaAdmin.Service.Project.Pages.RoatpAdmin;

public class ChangeUkprnPage : ChangeBasePage
{
    protected override string PageTitle => $"Change UKPRN for {objectContext.GetProviderName()}";

    protected override string AccessibilityPageTitle => "Change ukprn for provider";

    public ChangeUkprnPage(ScenarioContext context) : base(context) { }
}
