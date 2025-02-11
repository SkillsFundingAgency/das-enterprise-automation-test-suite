namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages;

public abstract class ProviderRelationshipsBasePage(ScenarioContext context) : EmployerProviderRelationshipsBasePage(context)
{
    protected readonly EprDataHelper eprDataHelper = context.Get<EprDataHelper>();
}
