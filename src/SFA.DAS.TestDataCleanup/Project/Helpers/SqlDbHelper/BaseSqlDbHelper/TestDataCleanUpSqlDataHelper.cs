using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.BaseSqlDbHelper
{
    public abstract class TestDataCleanUpSqlDataHelper : ProjectSqlDbHelper
    {
        public abstract string SqlFileName { get; }

        public TestDataCleanUpSqlDataHelper(string connectionString) : base(connectionString) { }

        protected int CleanUpUsingEmail(string email) => TryExecuteSqlCommand(GetSql(), connectionString, new Dictionary<string, string> { { "@email", email } });

        protected int CleanUpUsingAccountIds(List<string> accountIdToDelete) => CleanUpTestData(accountIdToDelete, (x) => $"Insert into #accountids values ({x})", "create table #accountids (id bigint)");

        protected int CleanUpTestData(List<string> accountIdToDelete, Func<string, string> insertQueryFunc, string createQuery)
        {
            if (ExcludeEnvironments) return 0;

            var insertquery = accountIdToDelete.Select(x => insertQueryFunc(x)).ToList();

            var sqlQuery = $"{createQuery};{insertquery.ToString(";")};" + GetSql();

            var noOfRowsDeleted = TryExecuteSqlCommand(sqlQuery, connectionString) - accountIdToDelete.Count;

            return noOfRowsDeleted;
        }

        protected (List<string>, List<string>) CleanUpTestData(Func<List<string>> getAccountidfunc, Func<List<string>, int> deleteAccountidfunc)
        {
            List<string> accountIdToDelete = new List<string>();

            List<string> accountIdNotDeleted = new List<string>();

            if (ExcludeEnvironments) return (accountIdToDelete, accountIdNotDeleted);

            try
            {
                accountIdToDelete = getAccountidfunc.Invoke();

                if (accountIdToDelete.IsNoDataFound()) return (new List<string>(), new List<string>());

                deleteAccountidfunc(accountIdToDelete);

            }
            catch (Exception ex)
            {
                accountIdNotDeleted.Add($"({SqlFileName}){Environment.NewLine}{ex.Message}");
            }
            finally
            {
                var accountIdNotDeletedindb = getAccountidfunc.Invoke();

                if (!accountIdNotDeletedindb.IsNoDataFound()) accountIdNotDeleted.AddRange(accountIdNotDeletedindb);
            }

            return (accountIdToDelete.Except(accountIdNotDeleted).ToList(), accountIdNotDeleted);
        }

        private string GetSql() { return FileHelper.GetSql(SqlFileName); }
    }
}
