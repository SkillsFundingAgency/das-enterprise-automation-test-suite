using SFA.DAS.API.Framework;
using SFA.DAS.AssessorCertification.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.AssessorCertification.APITests.Project
{
    [Binding]
    public class BeforeScenarioHooks(ScenarioContext context)
    {
        private readonly DbConfig _dbConfig = context.Get<DbConfig>();

        [BeforeScenario(Order = 32)]

        public void SetUpHelpers()
        {
            var objectContext = context.Get<ObjectContext>();

            context.Set(new AssessorCertificationSqlDbHelper(objectContext, _dbConfig));

            context.SetRestClient(new Outer_AssessorCertificationApiRestClient(objectContext, context.GetOuter_ApiAuthTokenConfig()));
        }
    }
}
