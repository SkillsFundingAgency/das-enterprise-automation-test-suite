using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFA.DAS.TestDataCleanup.Project.Helpers
{
    public class TestDataCleanUpSqlDataHelper : ProjectSqlDbHelper
    {
        private readonly DbConfig _dbConfig;

        public TestDataCleanUpSqlDataHelper(DbConfig dbConfig) : base(dbConfig.AccountsDbConnectionString) => _dbConfig = dbConfig;

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
                        _sqlFileName = string.Empty;

                        usersdeleted.Add(_user);
                    }

                    await TryExecuteSqlCommand(GetSql("EasPregTestDataCleanUp"), _dbConfig.PregDbConnectionString, GetEmail());

                    var accountidsTodelete = accountids.ListOfArrayToList(0);

                    await new TestDataCleanUpPrelDbSqlDataHelper(_dbConfig).CleanUpPrelTestData(accountidsTodelete);
                    await new TestDataCleanUpPsrDbSqlDataHelper(_dbConfig).CleanUpPsrTestData(accountidsTodelete);
                    await new TestDataCleanUpPfbeDbSqlDataHelper(_dbConfig).CleanUpPfbeTestData(accountidsTodelete);
                    await new TestDataCleanupComtSqlDataHelper(_dbConfig).CleanUpComtTestData(accountidsTodelete);

                    await TryExecuteSqlCommand(GetSql("EasAccTestDataCleanUp"), GetEmail());
                }
                catch (Exception ex)
                {
                    userswithconstraints.Add($"{_user}({_sqlFileName}){Environment.NewLine}{ex.Message}");
                }
            }

            return (usersdeleted, userswithconstraints);
        }
    }
}
