using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public abstract class TestDataCleanupSqlDataHelper : ProjectSqlDbHelper
    {
        public abstract string SqlFileName { get; }

        public TestDataCleanupSqlDataHelper(string connectionString) : base(connectionString) { }

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

    public abstract class ProjectSqlDbHelper : FrameworkHelpers.SqlDbHelper
    {
        public readonly string dbName;

        public virtual bool ExcludeEnvironments => false;

        protected ProjectSqlDbHelper(string connectionString) : base(connectionString) => dbName = GetDbName();

        public string GetTableCatalog() => GetDataAsString("select top 1 TABLE_CATALOG from INFORMATION_SCHEMA.TABLES");

        public string GetCaller() => GetType().Name;

        protected List<string> GetAccountids(string query) => GetMultipleData(query).ListOfArrayToList(0);

        protected List<string[]> GetMultipleAccountData(string sqlQuery)
        {
            var id = GetMultipleData(sqlQuery);

            if (id.IsNoDataFound()) id[0][0] = "0";

            return id;
        }

        private string GetDbName()
        {
            var list = connectionString.Split(";");

            var dbName = list.Any(x => x.StartsWith("Database")) ? list.SingleOrDefault(x => x.StartsWith("Database")) : list.SingleOrDefault(x => x.StartsWith("Initial Catalog"));

            return dbName.Split("=")[1];
        }
    }
}
