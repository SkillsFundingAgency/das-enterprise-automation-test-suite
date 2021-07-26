using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFA.DAS.TestDataCleanup.Project.Helpers
{
    public abstract class ProjectSqlDbHelper : SqlDbHelper
    {
        protected string _user, _userEmail, _accountId, _sqlFileName;

        protected ProjectSqlDbHelper(string connectionString) : base(connectionString) { }

        protected string GetSql(string filename) { _sqlFileName = filename; return FileHelper.GetSql(_sqlFileName); }

        protected Dictionary<string, string> GetEmail() => new Dictionary<string, string> { { "@email", _userEmail } };

        protected Dictionary<string, string> GetAccountId() => new Dictionary<string, string> { { "@accountid", _accountId } };

        protected bool IsNullOrEmpty(List<string[]> x) => IsNullOrEmpty(x.ListOfArrayToList(0));

        protected bool IsNullOrEmpty(List<string> x) => (x.Count == 1 && string.IsNullOrEmpty(x[0]));

        protected async Task CleanUpTestData(List<string> accountIdToDelete, Func<string, string> insertQueryFunc, string createQuery, string sqlfilename)
        {
            var insertquery = accountIdToDelete.Select(x => insertQueryFunc(x)).ToList();

            var sqlQuery = $"{createQuery};{insertquery.ToString(";")};" + GetSql(sqlfilename);

            await TryExecuteSqlCommand(sqlQuery);
        }

        protected List<string> GetAccountids(string query) => GetMultipleData(query, 1).ListOfArrayToList(0);

        protected async Task<(List<string>, List<string>)> CleanUpTestData(Func<List<string>> getAccountidfunc, Func<List<string>, Task> deleteAccountidfunc)
        {
            List<string> accountIdToDelete = new List<string>();

            List<string> accountIdNotDeleted = new List<string>();

            try
            {
                accountIdToDelete = getAccountidfunc.Invoke();

                if (IsNullOrEmpty(accountIdToDelete)) return (new List<string>(), new List<string>());

                await deleteAccountidfunc(accountIdToDelete);

            }
            catch (Exception ex)
            {
                accountIdNotDeleted.Add($"({_sqlFileName}){Environment.NewLine}{ex.Message}");
            }
            finally
            {
                var accountIdNotDeletedindb = getAccountidfunc.Invoke();

                if (!(IsNullOrEmpty(accountIdNotDeletedindb))) accountIdNotDeleted.AddRange(accountIdNotDeletedindb);
            }

            return (accountIdToDelete.Except(accountIdNotDeleted).ToList(), accountIdNotDeleted);
        }

    }
}
