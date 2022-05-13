using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper;
using TechTalk.SpecFlow;

namespace SFA.DAS.TestDataExport.StepDefinitions
{
    [Binding]
    public class VerifyDbConnectionSteps
    {
        private readonly DbConfig _dbConfig;

        public VerifyDbConnectionSteps(ScenarioContext context) => _dbConfig = context.Get<DbConfig>();
        
        [Then(@"the db connection are verified")]
        public void ThenTheDbConnectionAreVerified()
        {
                AssertDbConnection(new EasAccDbSqlDataHelper(_dbConfig));
            AssertDbConnection(new ApprenticeCommitmentLoginDbSqlDataHelper(_dbConfig));
            AssertDbConnection(new EmploymentCheckDbSqlDataHelper(_dbConfig));
            AssertDbConnection(new CrsDbSqlDataHelper(_dbConfig));
            AssertDbConnection(new TprDbSqlDataHelper(_dbConfig));
            AssertDbConnection(new UsersDbSqlDataHelper(_dbConfig));
            AssertDbConnection(new AssessorDbSqlDataHelper(_dbConfig));
            AssertDbConnection(new LoginDbSqlDataHelper(_dbConfig));
            AssertDbConnection(new QnaDbSqlDataHelper(_dbConfig));
            AssertDbConnection(new ApplyDbSqlDataHelper(_dbConfig));
            AssertDbConnection(new RoatpDbSqlDataHelper(_dbConfig));

            AssertDbConnection(new TestDataCleanupAComtSqlDataHelper(_dbConfig));
                AssertDbConnection(new TestDataCleanupComtSqlDataHelper(_dbConfig));
                AssertDbConnection(new TestDataCleanUpEasLtmcSqlDataHelper(_dbConfig));
                AssertDbConnection(new TestDataCleanUpEmpFcastSqlDataHelper(_dbConfig));
                AssertDbConnection(new TestDataCleanUpEmpFinSqlDataHelper(_dbConfig));
                AssertDbConnection(new TestDataCleanUpEmpIncSqlDataHelper(_dbConfig));
                AssertDbConnection(new TestDataCleanUpPfbeDbSqlDataHelper(_dbConfig));
                AssertDbConnection(new TestDataCleanUpPrelDbSqlDataHelper(_dbConfig));
                AssertDbConnection(new TestDataCleanUpPsrDbSqlDataHelper(_dbConfig));
                AssertDbConnection(new TestDataCleanUpRsvrSqlDataHelper(_dbConfig));
        }

        private void AssertDbConnection(ProjectSqlDbHelper helper) => StringAssert.StartsWith("das-", helper.GetTableCatalog());
    }
}
