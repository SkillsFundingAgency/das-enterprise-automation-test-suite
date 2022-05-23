using SFA.DAS.ConfigurationBuilder;
using System.Collections.Generic;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class RoatpDbSqlDataHelper : ProjectSqlDbHelper
    {
        public RoatpDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.RoatpDatabaseConnectionString) { }
    }

    public class ApplyDbSqlDataHelper : ProjectSqlDbHelper
    {
        public ApplyDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.ApplyDatabaseConnectionString) { }
    }

    public class QnaDbSqlDataHelper : ProjectSqlDbHelper
    {
        public QnaDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.QnaDatabaseConnectionString) { }
    }

    public class LoginDbSqlDataHelper : ProjectSqlDbHelper
    {
        public LoginDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.LoginDatabaseConnectionString) { }
    }

    public class AssessorDbSqlDataHelper : ProjectSqlDbHelper
    {
        public AssessorDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.AssessorDbConnectionString) { }
    }

    public class UsersDbSqlDataHelper : ProjectSqlDbHelper
    {
        public UsersDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.UsersDbConnectionString) { }
    }

    public class TprDbSqlDataHelper : ProjectSqlDbHelper
    {
        public TprDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.TPRDbConnectionString) { }
    }

    public class CrsDbSqlDataHelper : ProjectSqlDbHelper
    {
        public CrsDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.CRSDbConnectionString) { }
    }
    public class EmploymentCheckDbSqlDataHelper : ProjectSqlDbHelper
    {
        public EmploymentCheckDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.EmploymentCheckDbConnectionString) { }
    }

    public class EasAccDbSqlDataHelper : ProjectSqlDbHelper
    {
        public EasAccDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.AccountsDbConnectionString) { }

        internal List<string[]> GetAccountIds(int greaterThan, int lessThan)
        {
            return GetMultipleAccountData($"select Id from employer_account.Account where id > {greaterThan} and id < {lessThan} order by id desc");
        }

        internal List<string[]> GetAccountHashedIds(List<string> accountIdToDelete)
        {
            return GetMultipleData($"select HashedId from employer_account.Account where id in ({string.Join(",", accountIdToDelete)})");
        }
    }
}
