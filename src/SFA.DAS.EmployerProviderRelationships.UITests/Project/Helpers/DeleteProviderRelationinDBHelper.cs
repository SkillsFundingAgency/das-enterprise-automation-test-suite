namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Helpers;

public class DeleteProviderRelationinDbHelper(ScenarioContext context)
{
    private ObjectContext ObjectContext => context.Get<ObjectContext>();

    private ProviderConfig ProviderConfig => context.GetProviderConfig<ProviderConfig>();

    public void DeleteProviderRelation() => context.Get<RelationshipsSqlDataHelper>().DeleteProviderRelation(ProviderConfig.Ukprn, ObjectContext.GetDBAccountId(), ObjectContext.GetRegisteredEmail());

    public void DeleteProviderRequest(string requestId) => context.Get<RelationshipsSqlDataHelper>().DeleteProviderRequest(requestId);

}
