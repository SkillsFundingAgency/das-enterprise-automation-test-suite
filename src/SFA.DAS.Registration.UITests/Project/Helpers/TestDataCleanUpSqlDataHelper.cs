using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class TestDataCleanUpSqlDataHelper : SqlDbHelper
    {
        private readonly DbConfig _dbConfig;

        private string _user, _userEmail, _accountId, _sqlFileName;

        public TestDataCleanUpSqlDataHelper(DbConfig dbConfig) : base(dbConfig.AccountsDbConnectionString) => _dbConfig = dbConfig;

        public (List<string>, List<string>) CleanUpTestData(string email)
        {
            List<string> usersdeleted = new List<string>();

            List<string> userswithconstraints = new List<string>();

            var userEmailList = GetMultipleData($"select Email from employer_account.[User] where Email like ('%{email}%')", 1);

            if (userEmailList.Count == 1 && string.IsNullOrEmpty(userEmailList[0][0])) return (usersdeleted, userswithconstraints);

            foreach (var userEmailArray in userEmailList)
            {
                _userEmail = userEmailArray[0];

                try
                {
                    _user = $"{_userEmail}";

                    var accountids = GetMultipleData($"select AccountId from employer_account.Membership where UserId in (select id from employer_account.[User] where email = '{_userEmail}')", 1);

                    TryExecuteSqlCommand(GetSql("EasAccTestDataCleanUp"), connectionString, GetEmail());
                    TryExecuteSqlCommand(GetSql("EasUsersTestDataCleanUp"), _dbConfig.UsersDbConnectionString, GetEmail());

                    if (accountids.Count == 1 && string.IsNullOrEmpty(accountids[0][0])) continue;

                    foreach (var accountId in accountids)
                    {
                        _accountId = accountId[0];

                        _user = $"{_userEmail},{_accountId}";
                        TryExecuteSqlCommand(GetSql("EasFinTestDataCleanUp"), _dbConfig.FinanceDbConnectionString, GetAccountId());
                        TryExecuteSqlCommand(GetSql("EasFcastTestDataCleanUp"), _dbConfig.FcastDbConnectionString, GetAccountId());
                        TryExecuteSqlCommand(GetSql("EmpIncTestDataCleanUp"), _dbConfig.IncentivesDbConnectionString, GetAccountId());
                        TryExecuteSqlCommand(GetSql("EasRsrvTestDataCleanUp"), _dbConfig.ReservationsDbConnectionString, GetAccountId());
                        TryExecuteSqlCommand(GetSql("EasComtTestDataCleanUp"), _dbConfig.CommitmentsDbConnectionString, GetAccountId());
                        _sqlFileName = string.Empty;
                        
                        usersdeleted.Add(_user);
                    }
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
    }
}
