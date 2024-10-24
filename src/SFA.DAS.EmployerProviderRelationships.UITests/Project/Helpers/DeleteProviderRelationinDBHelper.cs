using SFA.DAS.FrameworkHelpers;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Helpers
{
    public class DeleteProviderRelationinDbHelper(ScenarioContext context)
    {
        private ObjectContext ObjectContext => context.Get<ObjectContext>();

        private ProviderConfig ProviderConfig => context.GetProviderConfig<ProviderConfig>();

        public void DeleteProviderRelation() => context.Get<RelationshipsSqlDataHelper>().DeleteProviderRelation(ProviderConfig.Ukprn, ObjectContext.GetDBAccountId(), ObjectContext.GetRegisteredEmail());

    }
}
