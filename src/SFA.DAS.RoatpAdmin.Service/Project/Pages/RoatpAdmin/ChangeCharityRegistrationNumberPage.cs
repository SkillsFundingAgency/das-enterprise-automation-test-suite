namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class ChangeCharityRegistrationNumberPage(ScenarioContext context) : ChangeBasePage(context)
{
    protected override string PageTitle => $"Change charity registration number for {objectContext.GetProviderName()}";

    protected override string AccessibilityPageTitle => "Change charity registration number for provider";
}
