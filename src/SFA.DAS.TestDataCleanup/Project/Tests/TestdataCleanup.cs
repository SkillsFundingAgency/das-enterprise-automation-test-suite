using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataCleanup.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.TestDataCleanup.Project.Tests
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
        public async Task ThenTheTestDataAreCleanedUpForEmail(string email) => await CleanUpTestData(email);


        [Then(@"the test data are cleaned up")]
        public async Task ThenTheTestDataAreCleanedUp() => await CleanUpTestData("hemanjali.cheruku@digital.education.gov.uk");

        [Then(@"the test data are cleaned up in provider relationship for accounts between '([^']*)' and '([^']*)'")]
        public async Task ThenTheTestDataAreCleanedUpForAccountsBetweenAndAndNotIn(int greaterThan, int lessThan)
        {
            var (usersdeleted, userswithconstraints) = await new TestDataCleanUpPrelDbSqlDataHelper(_dbConfig).CleanUpPrelTestData(greaterThan, lessThan);

            TestCleanUpReport(usersdeleted, userswithconstraints);
        }

        private async Task CleanUpTestData(string email)
        {
            var (usersdeleted, userswithconstraints) = await new TestDataCleanUpSqlDataHelper(_dbConfig).CleanUpTestData(email);

            TestCleanUpReport(usersdeleted, userswithconstraints);
        }

        private void TestCleanUpReport(List<string> usersdeleted, List<string> userswithconstraints)
        {
            int x = usersdeleted.Count;

            if (x > 0)
            {
                _objectContext.Set($"{NextNumberGenerator.GetNextCount()}_testdatadeleted", $"{x} account{(x == 1 ? string.Empty : "s")} deleted" +
                    $"{ Environment.NewLine}{ string.Join(Environment.NewLine, usersdeleted)}");
            }

            if (userswithconstraints.Count > 0)
            {
                throw new Exception($"{Environment.NewLine}{string.Join(Environment.NewLine, userswithconstraints)}");
            }
        }
    }
}
