using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;

public class ProviderAPIListPage(ScenarioContext context) : ApprovalsBasePage(context)
{
    protected override string PageTitle => "API list";
}
