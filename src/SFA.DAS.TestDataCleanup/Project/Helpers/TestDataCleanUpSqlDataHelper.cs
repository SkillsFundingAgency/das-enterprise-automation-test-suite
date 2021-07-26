using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.TestDataCleanup.Project.Helpers
{
    public class TestDataCleanUpSqlDataHelper : ProjectSqlDbHelper
    {
        private readonly DbConfig _dbConfig;

        public TestDataCleanUpSqlDataHelper(DbConfig dbConfig) : base(dbConfig.AccountsDbConnectionString) => _dbConfig = dbConfig;

        public (List<string>, List<string>) CleanUpTestData(string email)
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

                    TryExecuteSqlCommand(GetSql("EasUsersTestDataCleanUp"), _dbConfig.UsersDbConnectionString, GetEmail());

                    if (accountids.Count == 1 && string.IsNullOrEmpty(accountids[0][0])) continue;

                    TryExecuteSqlCommand(GetSql("EasPregTestDataCleanUp"), _dbConfig.PregDbConnectionString, GetEmail());

                    var accountidsTodelete = accountids.ListOfArrayToList(0);

                    new TestDataCleanUpRsvrSqlDataHelper(_dbConfig).CleanUpRsvrTestData(accountidsTodelete);
                    new TestDataCleanUpPrelDbSqlDataHelper(_dbConfig).CleanUpPrelTestData(accountidsTodelete);
                    new TestDataCleanUpPsrDbSqlDataHelper(_dbConfig).CleanUpPsrTestData(accountidsTodelete);
                    new TestDataCleanUpPfbeDbSqlDataHelper(_dbConfig).CleanUpPfbeTestData(accountidsTodelete);
                    new TestDataCleanUpEmpFcastSqlDataHelper(_dbConfig).CleanUpEmpFcastTestData(accountidsTodelete);
                    new TestDataCleanUpEmpFinSqlDataHelper(_dbConfig).CleanUpEmpFinTestData(accountidsTodelete);
                    new TestDataCleanUpEmpIncSqlDataHelper(_dbConfig).CleanUpEmpIncTestData(accountidsTodelete);
                    new TestDataCleanupComtSqlDataHelper(_dbConfig).CleanUpComtTestData(accountidsTodelete);

                    TryExecuteSqlCommand(GetSql("EasAccTestDataCleanUp"), GetEmail());

                    _user = $"{_userEmail},{accountidsTodelete.ToString(",")}";

                    usersdeleted.Add(_user);
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
