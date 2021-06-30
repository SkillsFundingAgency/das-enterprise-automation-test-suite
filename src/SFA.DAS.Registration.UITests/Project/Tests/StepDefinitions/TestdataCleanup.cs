using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Registration.UITests.Project.Helpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class TestdataCleanup
    {
        private readonly DbConfig _dbConfig;
        private readonly ObjectContext _objectContext;

        public TestdataCleanup(ScenarioContext context)
        {
            _dbConfig = context.Get<DbConfig>();
            _objectContext = context.Get<ObjectContext>();
        }

        [Then(@"the test data are cleaned up for email (.*)")]
        public void ThenTheTestDataAreCleanedUpForEmailLE_Test_JunDasautomation_Com(string email)
        {
          var (usersdeleted, userswithconstraints) = new TestDataCleanUpSqlDataHelper(_dbConfig).CleanUpFromEasAccDb(email);

            if (usersdeleted.Count > 0)
            {
                _objectContext.Set("usersdeleted", $"{ Environment.NewLine}{ string.Join(Environment.NewLine, usersdeleted)}");
            }

            if (userswithconstraints.Count > 0)
            {
                throw new Exception($"Exception occurred while executing SQL query for the below user's {Environment.NewLine}{string.Join(Environment.NewLine, userswithconstraints)}");
            }
        }
    }
}
