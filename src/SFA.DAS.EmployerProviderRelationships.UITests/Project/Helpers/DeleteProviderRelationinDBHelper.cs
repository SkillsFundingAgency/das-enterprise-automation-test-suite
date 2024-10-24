using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Helpers
{
    public class DeleteProviderRelationinDbHelper(ScenarioContext context)
    {
        private DbConfig DbConfig => context.Get<DbConfig>();

        private ObjectContext ObjectContext => context.Get<ObjectContext>();

        private ProviderConfig ProviderConfig => context.GetProviderConfig<ProviderConfig>();

        internal void DeleteProviderRelation() => DeleteProviderRelation(ProviderConfig);

        public void DeleteProviderRelation(ProviderConfig providerConfig) => DeleteProviderRelation(providerConfig.Ukprn, ObjectContext.GetDBAccountId(), ObjectContext.GetRegisteredEmail());

        private void DeleteProviderRelation(string ukprn, string accountid, string empemail) => new RelationshipsSqlDataHelper(ObjectContext, DbConfig).DeleteProviderRelation(ukprn, accountid, empemail);
    }
}
