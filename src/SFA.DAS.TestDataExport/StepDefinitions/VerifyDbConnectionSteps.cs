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
            AssertDbConnection(new TestDataCleanUpEasLtmcSqlDataHelper(_dbConfig).GetTableCatalog());
        }

        private void AssertDbConnection(string actual) => StringAssert.StartsWith("das-", actual);
    }
}
