using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public abstract class ProjectSqlDbHelper : FrameworkHelpers.SqlDbHelper
    {
        protected string _user, _userEmail, _accountId, _sqlFileName;

        protected ProjectSqlDbHelper(string connectionString) : base(connectionString) { }

        public string GetTableCatalog() => GetDataAsString("select top 1 TABLE_CATALOG from INFORMATION_SCHEMA.TABLES");

        public string GetCaller() => GetType().Name;

        protected string GetSql(string filename) { _sqlFileName = filename; return FileHelper.GetSql(_sqlFileName); }

        protected Dictionary<string, string> GetEmail() => new Dictionary<string, string> { { "@email", _userEmail } };

        protected Dictionary<string, string> GetAccountId() => new Dictionary<string, string> { { "@accountid", _accountId } };

        protected int CleanUpTestData(List<string> accountIdToDelete, Func<string, string> insertQueryFunc, string createQuery, string sqlfilename)
        {
            var insertquery = accountIdToDelete.Select(x => insertQueryFunc(x)).ToList();

            var sqlQuery = $"{createQuery};{insertquery.ToString(";")};" + GetSql(sqlfilename);

            var noOfRowsDeleted = TryExecuteSqlCommand(sqlQuery, connectionString) - accountIdToDelete.Count;

            return noOfRowsDeleted;
        }

        protected List<string> GetAccountids(string query) => GetMultipleData(query).ListOfArrayToList(0);

        protected (List<string>, List<string>) CleanUpTestData(Func<List<string>> getAccountidfunc, Func<List<string>, int> deleteAccountidfunc)
        {
            List<string> accountIdToDelete = new List<string>();

            List<string> accountIdNotDeleted = new List<string>();

            try
            {
                accountIdToDelete = getAccountidfunc.Invoke();

                if (IsNoDataFound(accountIdToDelete)) return (new List<string>(), new List<string>());

                deleteAccountidfunc(accountIdToDelete);

            }
            catch (Exception ex)
            {
                accountIdNotDeleted.Add($"({_sqlFileName}){Environment.NewLine}{ex.Message}");
            }
            finally
            {
                var accountIdNotDeletedindb = getAccountidfunc.Invoke();

                if (!IsNoDataFound(accountIdNotDeletedindb)) accountIdNotDeleted.AddRange(accountIdNotDeletedindb);
            }

            return (accountIdToDelete.Except(accountIdNotDeleted).ToList(), accountIdNotDeleted);
        }

        protected List<string[]> GetMultipleAccountData(string sqlQuery)
        {
            var id = GetMultipleData(sqlQuery);

            if (IsNoDataFound(id)) id[0][0] = "0";

            return id;
        }
    }
}
