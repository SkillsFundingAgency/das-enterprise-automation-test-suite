using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class TestDataCleanUpAllDbSqlDataHelper : ProjectSqlDbHelper
    {
        private readonly DbConfig _dbConfig;

        public TestDataCleanUpAllDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.AccountsDbConnectionString) => _dbConfig = dbConfig;

        public (List<string>, List<string>) CleanUpAllDbTestData(string email)
        {
            List<string> usersdeleted = new List<string>();

            List<string> userswithconstraints = new List<string>();

            var userEmailList = GetMultipleData($"select top 100 Email from employer_account.[User] where " +
                $"Email like ('{email}') " +
                $"and Email like '___Test__________________________@%' " +
                $"and Email not like '%perftest.com' " +
                $"and Email not like '%PerfTest%' " +
                $"and Email not like '%Oct2020%' " +
                $"and Email not like '%Nov2020%' " +
                $"and Email not like '%Dec2020%' " +
                $"and Email not like '%Jan2021%' " +
                $"and Email not like '%Feb2021%' " +
                $"and Email not like '%Mar2021%' " +
                $"and Email not like '%Apr2021%' " +
                $"and Email not like '%May2021%' " +
                $"and Email not like '%Jun2021%' " +
                $"and Email not like '%Jul2021%' " +
                $"and Email not like '%Aug2021%' " +
                $"and Email not like '%Sep2021%' " +
                $"and Email not like '%Oct2021%' " +
                $"and Email not like '%Nov2021%' " +
                $"and Email not like '%Dec2021%' " +
                $"and Email not in ({TestDataCleanUpEmailsInUse.GetInUseEmails()}) order by NEWID() desc");

            if (IsNoDataFound(userEmailList)) return (usersdeleted, userswithconstraints);

            TestDataCleanUpEmailsInUse.AddInUseEmails(userEmailList.ListOfArrayToList(0));

            foreach (var userEmailArray in userEmailList)
            {
                _userEmail = userEmailArray[0];

                try
                {
                    _user = $"{_userEmail}";

                    var accountids = GetMultipleData($"select AccountId from employer_account.Membership where UserId in (select id from employer_account.[User] where email = '{_userEmail}')");

                    var noOfRowsDeleted = TryExecuteSqlCommand(GetSql("EasUsersTestDataCleanUp"), _dbConfig.UsersDbConnectionString, GetEmail());

                    noOfRowsDeleted += TryExecuteSqlCommand(GetSql("EasPregTestDataCleanUp"), _dbConfig.PregDbConnectionString, GetEmail());

                    var accountidsTodelete = accountids.ListOfArrayToList(0);

                    if (!string.IsNullOrEmpty(accountidsTodelete[0]))
                    {
                        noOfRowsDeleted += new TestDataCleanUpRsvrSqlDataHelper(_dbConfig).CleanUpRsvrTestData(accountidsTodelete);
                        noOfRowsDeleted += new TestDataCleanUpPrelDbSqlDataHelper(_dbConfig).CleanUpPrelTestData(accountidsTodelete);
                        noOfRowsDeleted += new TestDataCleanUpPsrDbSqlDataHelper(_dbConfig).CleanUpPsrTestData(accountidsTodelete);
                        noOfRowsDeleted += new TestDataCleanUpPfbeDbSqlDataHelper(_dbConfig).CleanUpPfbeTestData(accountidsTodelete);
                        noOfRowsDeleted += new TestDataCleanUpEmpFcastSqlDataHelper(_dbConfig).CleanUpEmpFcastTestData(accountidsTodelete);
                        noOfRowsDeleted += new TestDataCleanUpEmpFinSqlDataHelper(_dbConfig).CleanUpEmpFinTestData(accountidsTodelete);
                        noOfRowsDeleted += new TestDataCleanUpEmpIncSqlDataHelper(_dbConfig).CleanUpEmpIncTestData(accountidsTodelete);
                        noOfRowsDeleted += new TestDataCleanupAComtSqlDataHelper(_dbConfig).CleanUpAComtTestData(accountidsTodelete);
                        noOfRowsDeleted += new TestDataCleanUpEasLtmcSqlDataHelper(_dbConfig).CleanUpEasLtmTestData(accountidsTodelete);
                        noOfRowsDeleted += new TestDataCleanupComtSqlDataHelper(_dbConfig).CleanUpComtTestData(accountidsTodelete);
                    }

                    noOfRowsDeleted += TryExecuteSqlCommand(GetSql("EasAccTestDataCleanUp"), connectionString, GetEmail());

                    _user = $"{_userEmail},{accountidsTodelete.ToString(",")},{noOfRowsDeleted} rows deleted";

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
