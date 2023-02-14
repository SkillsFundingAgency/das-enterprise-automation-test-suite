namespace SFA.DAS.EsfaAdmin.Service.Project.Pages.RoatpAdmin;

public class ChangeLegalNamePage : ChangeBasePage
{
    protected override string PageTitle => $"Change legal name for {objectContext.GetProviderName()}";

    public ChangeLegalNamePage(ScenarioContext context) : base(context) { }
}
