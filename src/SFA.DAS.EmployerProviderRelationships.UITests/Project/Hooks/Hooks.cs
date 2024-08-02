using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerProviderRelationships.UITests.Project.Helpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.TestDataExport.Helper;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Hooks
{
    [Binding]
    public class Hooks(ScenarioContext context)
    {
        [AfterScenario(Order = 22)]
        [Scope(Tag = "grantpermission")]
        public void DeleteProviderRelation()
        {
            var _dbConfig = context.Get<DbConfig>();

            var _objectContext = context.Get<ObjectContext>();

            var _tryCatch = context.Get<TryCatchExceptionHelper>();

            var providerConfig = context.GetProviderConfig<ProviderConfig>();

            _tryCatch.AfterScenarioException(() => new EmployerProviderRelationshipsSqlDataHelper(_objectContext, _dbConfig).DeleteProviderRelation(providerConfig.Ukprn, _objectContext.GetDBAccountId()));
        }
    }
}
