using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Helpers
{
    public class DeleteProviderRelationHelper(ScenarioContext context)
    {
        private DbConfig DbConfig => context.Get<DbConfig>();

        private ObjectContext ObjectContext => context.Get<ObjectContext>();

        private ProviderConfig ProviderConfig => context.GetProviderConfig<ProviderConfig>();

        internal void DeleteProviderRelation()
        {
            new EmployerProviderRelationshipsSqlDataHelper(ObjectContext, DbConfig).DeleteProviderRelation(ProviderConfig.Ukprn, ObjectContext.GetDBAccountId());
        }
    }
}
