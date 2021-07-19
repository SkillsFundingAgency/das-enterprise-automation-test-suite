using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SFA.DAS.TestDataCleanup.Project.Helpers
{
    public class TestDataCleanUpSqlDataHelper : SqlDbHelper
    {
        private readonly DbConfig _dbConfig;

        private string _user, _userEmail, _accountId, _sqlFileName;

        public TestDataCleanUpSqlDataHelper(DbConfig dbConfig) : base(dbConfig.AccountsDbConnectionString) => _dbConfig = dbConfig;

        public async Task<(List<string>, List<string>)> CleanUpPrelTestData(int greaterThan, int lessThan)
        {
            var easaccountids = GetMultipleData($"select Id from employer_account.Account where id > {greaterThan} and id < {lessThan} order by id desc", 1);

            if (IsNullOrEmpty(easaccountids)) easaccountids[0][0] = "0";

            return await CleanUpPrelTestData(greaterThan, lessThan, easaccountids);
        }

        public async Task<(List<string>, List<string>)> CleanUpTestData(string email)
        {
            List<string> usersdeleted = new List<string>();

            List<string> userswithconstraints = new List<string>();

            var userEmailList = GetMultipleData($"select top 200 Email from employer_account.[User] where Email like ('{email}') and email not in ({TestDataCleanUpEmailsInUse.GetInUseEmails()}) order by NEWID() desc", 1);

            if (IsNullOrEmpty(userEmailList)) return (usersdeleted, userswithconstraints);

            TestDataCleanUpEmailsInUse.AddInUseEmails(userEmailList.ListOfArrayToList(0));

            foreach (var userEmailArray in userEmailList)
            {
                _userEmail = userEmailArray[0];

                try
                {
                    _user = $"{_userEmail}";

                    var accountids = GetMultipleData($"select AccountId from employer_account.Membership where UserId in (select id from employer_account.[User] where email = '{_userEmail}')", 1);

                    await TryExecuteSqlCommand(GetSql("EasAccTestDataCleanUp"), connectionString, GetEmail());
                    await TryExecuteSqlCommand(GetSql("EasUsersTestDataCleanUp"), _dbConfig.UsersDbConnectionString, GetEmail());

                    if (accountids.Count == 1 && string.IsNullOrEmpty(accountids[0][0])) continue;

                    foreach (var accountId in accountids)
                    {
                        _accountId = accountId[0];

                        _user = $"{_userEmail},{_accountId}";
                        await TryExecuteSqlCommand(GetSql("EasFinTestDataCleanUp"), _dbConfig.FinanceDbConnectionString, GetAccountId());
                        await TryExecuteSqlCommand(GetSql("EasFcastTestDataCleanUp"), _dbConfig.FcastDbConnectionString, GetAccountId());
                        await TryExecuteSqlCommand(GetSql("EmpIncTestDataCleanUp"), _dbConfig.IncentivesDbConnectionString, GetAccountId());
                        await TryExecuteSqlCommand(GetSql("EasRsrvTestDataCleanUp"), _dbConfig.ReservationsDbConnectionString, GetAccountId());
                        await TryExecuteSqlCommand(GetSql("EasComtTestDataCleanUp"), _dbConfig.CommitmentsDbConnectionString, GetAccountId());
                        _sqlFileName = string.Empty;

                        usersdeleted.Add(_user);
                    }

                    await CleanUpPrelTestData(accountids.ListOfArrayToList(0));

                }
                catch (Exception ex)
                {
                    userswithconstraints.Add($"{_user}({_sqlFileName}){Environment.NewLine}{ex.Message}");
                }
            }

            return (usersdeleted, userswithconstraints);
        }

        private string GetSql(string filename) { _sqlFileName = filename; return FileHelper.GetSql(_sqlFileName); }

        private Dictionary<string, string> GetEmail() => new Dictionary<string, string> { { "@email", _userEmail } };

        private Dictionary<string, string> GetAccountId() => new Dictionary<string, string> { { "@accountid", _accountId } };

        private bool IsNullOrEmpty(List<string[]> x) => IsNullOrEmpty(x.ListOfArrayToList(0));

        private bool IsNullOrEmpty(List<string> x) => (x.Count == 1 && string.IsNullOrEmpty(x[0]));

        private List<string> GetPrelAccountids(int greaterThan, int lessThan, List<string[]> easaccountids)
        {
            var prelaccountids = GetMultipleData($"select Id from dbo.Accounts where Id > {greaterThan} and id < {lessThan} and Id not in ({string.Join(",", easaccountids.ListOfArrayToList(0))}) order by id desc", _dbConfig.PermissionsDbConnectionString, 1);

            return prelaccountids.ListOfArrayToList(0);
        }

        private async Task CleanUpPrelTestData(List<string> accountIdToDelete)
        {
            var insertquery = accountIdToDelete.Select(x => $"Insert into #accountids values ({x})").ToList();

            var sqlQuery = $"create table #accountids (id bigint);{string.Join(";", insertquery)};" + GetSql("EasPrelTestDataCleanUp");

            await TryExecuteSqlCommand(sqlQuery, _dbConfig.PermissionsDbConnectionString);
        }

        private async Task<(List<string>, List<string>)> CleanUpPrelTestData(int greaterThan, int lessThan, List<string[]> easaccountids)
        {
            List<string> accountIdToDelete = new List<string>();

            List<string> accountIdNotDeleted = new List<string>();

            try
            {
                accountIdToDelete = GetPrelAccountids(greaterThan, lessThan, easaccountids);

                if (IsNullOrEmpty(accountIdToDelete)) return (new List<string>(), new List<string>());

                await CleanUpPrelTestData(accountIdToDelete);

            }
            catch (Exception ex)
            {
                accountIdNotDeleted.Add($"({_sqlFileName}){Environment.NewLine}{ex.Message}");
            }
            finally
            {
                var accountIdNotDeletedinPrel = GetPrelAccountids(greaterThan, lessThan, easaccountids);

                if (!(IsNullOrEmpty(accountIdNotDeletedinPrel))) accountIdNotDeleted.AddRange(accountIdNotDeletedinPrel);
            }

            return (accountIdToDelete.Except(accountIdNotDeleted).ToList(), accountIdNotDeleted);

        }

    }
}
