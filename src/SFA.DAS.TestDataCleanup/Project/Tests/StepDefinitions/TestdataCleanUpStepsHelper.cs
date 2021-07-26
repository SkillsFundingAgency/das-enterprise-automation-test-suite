using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataCleanup.Project.Helpers;
using System.Collections.Generic;
using System.Linq;

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

        internal (List<string> usersdeleted, List<string> userswithconstraints) CleanUpComtTestData()
        {
            return AddDbName(new TestDataCleanupComtSqlDataHelper(_dbConfig).CleanUpComtTestData(_greaterThan, _lessThan, _easaccountidsnottodelete), "comt");
        }

        internal (List<string> usersdeleted, List<string> userswithconstraints) CleanUpPrelTestData()
        {
            return AddDbName(new TestDataCleanUpPrelDbSqlDataHelper(_dbConfig).CleanUpPrelTestData(_greaterThan, _lessThan, _easaccountidsnottodelete), "prel");
        }

        internal (List<string> usersdeleted, List<string> userswithconstraints) CleanUpPfbeTestData()
        {
            return AddDbName(new TestDataCleanUpPfbeDbSqlDataHelper(_dbConfig).CleanUpPfbeTestData(_greaterThan, _lessThan, _easaccountidsnottodelete), "pfbe");
        }

        internal (List<string> usersdeleted, List<string> userswithconstraints) CleanUpEmpFcastTestData()
        {
            return AddDbName(new TestDataCleanUpEmpFcastSqlDataHelper(_dbConfig).CleanUpEmpFcastTestData(_greaterThan, _lessThan, _easaccountidsnottodelete), "fcast");
        }

        internal (List<string> usersdeleted, List<string> userswithconstraints) CleanUpEmpFinTestData()
        {
            return AddDbName(new TestDataCleanUpEmpFinSqlDataHelper(_dbConfig).CleanUpEmpFinTestData(_greaterThan, _lessThan, _easaccountidsnottodelete), "empfin");
        }

        internal (List<string> usersdeleted, List<string> userswithconstraints) CleanUpRsvrTestData()
        {
            return AddDbName(new TestDataCleanUpRsvrSqlDataHelper(_dbConfig).CleanUpRsvrTestData(_greaterThan, _lessThan, _easaccountidsnottodelete), "rsvr");
        }

        internal (List<string> usersdeleted, List<string> userswithconstraints) CleanUpEmpIncTestData()
        {
            return AddDbName(new TestDataCleanUpEmpIncSqlDataHelper(_dbConfig).CleanUpEmpIncTestData(_greaterThan, _lessThan, _easaccountidsnottodelete), "empinc");
        }

        private (List<string> usersdeleted, List<string> userswithconstraints) AddDbName((List<string>, List<string>) users, string dbname)
        {
            List<string> x(List<string> users, string dbname) => users.Select(x => $"{x},{dbname}").ToList();

            return (x(users.Item1, dbname), x(users.Item2, dbname));
        }
    }
}
