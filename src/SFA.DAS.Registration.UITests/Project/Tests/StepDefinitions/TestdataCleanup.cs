using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.MongoDb.DataGenerator.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using System;
using System.Threading.Tasks;
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

        [Then(@"the test data are cleaned up")]
        public async Task ThenTheTestDataAreCleanedUp()
        {
          var (usersdeleted, userswithconstraints) = await new TestDataCleanUpSqlDataHelper(_dbConfig).CleanUpTestData("commitments.example.com");

            int x = usersdeleted.Count;

            if (x > 0)
            {
                _objectContext.Set($"{NextNumberGenerator.GetNextCount()}_usersdeleted", $"{x} account{(x == 1 ? string.Empty : "s")} deleted" +
                    $"{ Environment.NewLine}{ string.Join(Environment.NewLine, usersdeleted)}");
            }

            if (userswithconstraints.Count > 0)
            {
                throw new Exception($"{Environment.NewLine}{string.Join(Environment.NewLine, userswithconstraints)}");
            }
        }
    }
}
