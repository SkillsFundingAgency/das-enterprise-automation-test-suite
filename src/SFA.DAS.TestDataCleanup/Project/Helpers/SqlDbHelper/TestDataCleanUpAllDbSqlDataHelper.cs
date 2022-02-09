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

                    var noOfRowsDeletedinEasUsers = TryExecuteSqlCommand(GetSql("EasUsersTestDataCleanUp"), _dbConfig.UsersDbConnectionString, GetEmail());

                    _user = $"{noOfRowsDeletedinEasUsers} rows deleted in EasUsers db"; usersdeleted.Add(_user);

                    var noOfRowsDeletedinEasPreg = TryExecuteSqlCommand(GetSql("EasPregTestDataCleanUp"), _dbConfig.PregDbConnectionString, GetEmail());

                    _user = $"{noOfRowsDeletedinEasPreg} rows deleted in EasPreg db"; usersdeleted.Add(_user);

                    var noOfRowsDeleted = noOfRowsDeletedinEasUsers + noOfRowsDeletedinEasPreg;

                    var accountidsTodelete = accountids.ListOfArrayToList(0);

                    if (!string.IsNullOrEmpty(accountidsTodelete[0]))
                    {
                        var noOfRowsDeletedinEasRsrv = new TestDataCleanUpRsvrSqlDataHelper(_dbConfig).CleanUpRsvrTestData(accountidsTodelete);
                        _user = $"{noOfRowsDeletedinEasRsrv} rows deleted in EasRsrv db"; usersdeleted.Add(_user);

                        var noOfRowsDeletedinEasPrel = new TestDataCleanUpPrelDbSqlDataHelper(_dbConfig).CleanUpPrelTestData(accountidsTodelete);
                        _user = $"{noOfRowsDeletedinEasPrel} rows deleted in EasPrel db"; usersdeleted.Add(_user);

                        var noOfRowsDeletedinEasPsr = new TestDataCleanUpPsrDbSqlDataHelper(_dbConfig).CleanUpPsrTestData(accountidsTodelete);
                        _user = $"{noOfRowsDeletedinEasPsr} rows deleted in EasPsr db"; usersdeleted.Add(_user);

                        var noOfRowsDeletedinEasPfbe = new TestDataCleanUpPfbeDbSqlDataHelper(_dbConfig).CleanUpPfbeTestData(accountidsTodelete);
                        _user = $"{noOfRowsDeletedinEasPfbe} rows deleted in EasPref db"; usersdeleted.Add(_user);

                        var noOfRowsDeletedinEasFcast = new TestDataCleanUpEmpFcastSqlDataHelper(_dbConfig).CleanUpEmpFcastTestData(accountidsTodelete);
                        _user = $"{noOfRowsDeletedinEasFcast} rows deleted in EasEmpFact db"; usersdeleted.Add(_user);

                        var noOfRowsDeletedinEasFin = new TestDataCleanUpEmpFinSqlDataHelper(_dbConfig).CleanUpEmpFinTestData(accountidsTodelete);
                        _user = $"{noOfRowsDeletedinEasFin} rows deleted in EasEmpFin db"; usersdeleted.Add(_user);

                        var noOfRowsDeletedinEasInc = new TestDataCleanUpEmpIncSqlDataHelper(_dbConfig).CleanUpEmpIncTestData(accountidsTodelete);
                        _user = $"{noOfRowsDeletedinEasInc} rows deleted in EasEmpInc db"; usersdeleted.Add(_user);

                        var noOfRowsDeletedinAComt = new TestDataCleanupAComtSqlDataHelper(_dbConfig).CleanUpAComtTestData(accountidsTodelete);
                        _user = $"{noOfRowsDeletedinAComt} rows deleted in EasAComt db"; usersdeleted.Add(_user);

                        var noOfRowsDeletedinEasLtm = new TestDataCleanUpEasLtmcSqlDataHelper(_dbConfig).CleanUpEasLtmTestData(accountidsTodelete);
                        _user = $"{noOfRowsDeletedinEasLtm} rows deleted in EasLtm db"; usersdeleted.Add(_user);

                        var noOfRowsDeletedinEasComt = new TestDataCleanupComtSqlDataHelper(_dbConfig).CleanUpComtTestData(accountidsTodelete);
                        _user = $"{noOfRowsDeletedinEasComt} rows deleted in EasComt db"; usersdeleted.Add(_user);

                        noOfRowsDeleted += noOfRowsDeletedinEasRsrv + noOfRowsDeletedinEasPrel + noOfRowsDeletedinEasPsr + noOfRowsDeletedinEasPfbe + noOfRowsDeletedinEasFcast + 
                                          noOfRowsDeletedinEasFin + noOfRowsDeletedinEasInc + noOfRowsDeletedinAComt + noOfRowsDeletedinEasLtm + noOfRowsDeletedinEasComt;
                    }

                    var noOfRowsDeletedEasAcc = TryExecuteSqlCommand(GetSql("EasAccTestDataCleanUp"), connectionString, GetEmail());
                    _user = $"{noOfRowsDeletedEasAcc} rows deleted in EasAcc db"; usersdeleted.Add(_user);

                    noOfRowsDeleted += noOfRowsDeletedEasAcc;

                    _user = $"{_userEmail},{accountidsTodelete.ToString(",")},{noOfRowsDeleted} total rows deleted across the dbs"; usersdeleted.Add(_user);
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
