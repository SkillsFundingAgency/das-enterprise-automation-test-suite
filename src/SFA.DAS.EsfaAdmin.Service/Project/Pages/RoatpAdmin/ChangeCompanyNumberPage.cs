using TechTalk.SpecFlow;

namespace SFA.DAS.EsfaAdmin.Service.Project.Pages.RoatpAdmin;

public class ChangeCompanyNumberPage : ChangeBasePage
{
    protected override string PageTitle => $"Change company number for {objectContext.GetProviderName()}";

    public ChangeCompanyNumberPage(ScenarioContext context) : base(context) { }

}
