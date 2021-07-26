using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataCleanup.Project.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFA.DAS.TestDataCleanup.Project.Tests.StepDefinitions
{
    public class TestdataCleanUpStepsHelper
    {
        private readonly DbConfig _dbConfig;
        private readonly int _greaterThan;
        private readonly int _lessThan;
        private readonly List<string> _easaccountidsnottodelete;

        public TestdataCleanUpStepsHelper(DbConfig dbConfig, int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
        {
            _dbConfig = dbConfig;
            _greaterThan = greaterThan;
            _lessThan = lessThan;
            _easaccountidsnottodelete = easaccountidsnottodelete;
        }

        internal async Task<(List<string> usersdeleted, List<string> userswithconstraints)> CleanUpComtTestData()
        {
            return AddDbName(await new TestDataCleanupComtSqlDataHelper(_dbConfig).CleanUpComtTestData(_greaterThan, _lessThan, _easaccountidsnottodelete), "comt");
        }

        internal async Task<(List<string> usersdeleted, List<string> userswithconstraints)> CleanUpPrelTestData()
        {
            return AddDbName(await new TestDataCleanUpPrelDbSqlDataHelper(_dbConfig).CleanUpPrelTestData(_greaterThan, _lessThan, _easaccountidsnottodelete), "prel");
        }

        internal async Task<(List<string> usersdeleted, List<string> userswithconstraints)> CleanUpPfbeTestData()
        {
            return AddDbName(await new TestDataCleanUpPfbeDbSqlDataHelper(_dbConfig).CleanUpPfbeTestData(_greaterThan, _lessThan, _easaccountidsnottodelete), "pfbe");
        }

        internal async Task<(List<string> usersdeleted, List<string> userswithconstraints)> CleanUpEmpFcastTestData()
        {
            return AddDbName(await new TestDataCleanUpEmpFcastSqlDataHelper(_dbConfig).CleanUpEmpFcastTestData(_greaterThan, _lessThan, _easaccountidsnottodelete), "fcast");
        }

        internal async Task<(List<string> usersdeleted, List<string> userswithconstraints)> CleanUpEmpFinTestData()
        {
            return AddDbName(await new TestDataCleanUpEmpFinSqlDataHelper(_dbConfig).CleanUpEmpFinTestData(_greaterThan, _lessThan, _easaccountidsnottodelete), "empfin");
        }

        private (List<string> usersdeleted, List<string> userswithconstraints) AddDbName((List<string>, List<string>) users, string dbname)
        {
            List<string> x(List<string> users, string dbname) => users.Select(x => $"{x},{dbname}").ToList();

            return (x(users.Item1, dbname), x(users.Item2, dbname));
        }
    }
}
