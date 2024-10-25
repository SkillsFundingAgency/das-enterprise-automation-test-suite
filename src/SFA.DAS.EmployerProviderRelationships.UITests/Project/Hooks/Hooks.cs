using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerProviderRelationships.UITests.Project.Helpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.TestDataExport.Helper;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Hooks
{
    [Binding]
    public class Hooks(ScenarioContext context)
    {
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();
        private readonly DbConfig _dbConfig = context.Get<DbConfig>();
        protected readonly TryCatchExceptionHelper _tryCatch = context.Get<TryCatchExceptionHelper>();

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            context.Set(new RelationshipsSqlDataHelper(_objectContext, _dbConfig));

            context.Set(new EprDataHelper());
        }

        [AfterScenario(Order = 22)]
        [Scope(Tag = "deletepermission")]
        public void DeleteProviderRelation() => _tryCatch.AfterScenarioException(() => new DeleteProviderRelationinDbHelper(context).DeleteProviderRelation());
    }
}
