using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataCleanup.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task ThenTheTestDataAreCleanedUp() => await CleanUpTestData("dele.odusanya@lynkmiigroup.com");

        [Then(@"the test data are cleaned up in other dbs for accounts between '(\d*)' and '(\d*)'")]
        public async Task ThenTheTestDataAreCleanedUpForAccountsBetweenAnd(int greaterThan, int lessThan)
        {
            var easAccountIds = new TestDataCleanUpEasAccDbSqlDataHelper(_dbConfig).GetAccountIds(greaterThan, lessThan);

            var easAccountsNotToDelete = easAccountIds.ListOfArrayToList(0);

            var (comtusersdeleted, comtuserswithconstraints) = await new TestDataCleanupComtSqlDataHelper(_dbConfig).CleanUpComtTestData(greaterThan, lessThan, easAccountsNotToDelete);
            comtusersdeleted = AddDbName(comtusersdeleted, "comt");
            comtuserswithconstraints = AddDbName(comtuserswithconstraints, "comt");

            var (prelusersdeleted, preluserswithconstraints) = await new TestDataCleanUpPrelDbSqlDataHelper(_dbConfig).CleanUpPrelTestData(greaterThan, lessThan, easAccountsNotToDelete);
            prelusersdeleted = AddDbName(prelusersdeleted, "prel");
            preluserswithconstraints = AddDbName(preluserswithconstraints, "prel");

            var (pfbeusersdeleted, pfbeuserswithconstraints) = await new TestDataCleanUpPfbeDbSqlDataHelper(_dbConfig).CleanUpPfbeTestData(greaterThan, lessThan, easAccountsNotToDelete);
            pfbeusersdeleted = AddDbName(pfbeusersdeleted, "pfbe");
            pfbeuserswithconstraints = AddDbName(pfbeuserswithconstraints, "pfbe");

            comtusersdeleted.AddRange(prelusersdeleted);
            comtuserswithconstraints.AddRange(preluserswithconstraints);

            prelusersdeleted.AddRange(pfbeusersdeleted);
            preluserswithconstraints.AddRange(pfbeuserswithconstraints);

            TestCleanUpReport(prelusersdeleted, preluserswithconstraints);
        }

        private List<string> AddDbName(List<string> users, string dbname) => users.Select(x => $"{x},{dbname}").ToList();

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
