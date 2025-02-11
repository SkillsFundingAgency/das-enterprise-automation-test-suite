using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.TestDataExport.Helper;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Hooks
{
    [Binding]
    public class BeforeScenarioHooks(ScenarioContext context)
    {
        private readonly DbConfig _dbConfig = context.Get<DbConfig>();
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            var a = context.Get<ApprenticePPIDataHelper>();

            _objectContext.SetApprenticeDetail(a.ApprenticeFirstname, a.ApprenticeLastname, a.ApprenticeDob, a.ApprenticeEmail);

            context.Set(new CommitmentsSqlHelper(_objectContext, _dbConfig));

            context.Set(new AccountsAndCommitmentsSqlHelper(_objectContext, _dbConfig));

            context.Set(new ApprenticeLoginSqlDbHelper(_objectContext, _dbConfig));

            context.Set(new ApprenticeCommitmentsSqlDbHelper(_objectContext, _dbConfig));

            context.Set(new ApprenticeCommitmentsAccountsSqlDbHelper(_objectContext, _dbConfig));

            context.SetRestClient(new Inner_CommitmentsApiRestClient(_objectContext, context.Get<Inner_ApiFrameworkConfig>()));
        }
    }
}