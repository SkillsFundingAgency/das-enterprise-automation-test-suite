using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper;
using SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.BaseSqlDbHelper;
using SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.TestDataCleanUpSqlDataHelper;
using System;
using System.Collections.Generic;

namespace SFA.DAS.TestDataCleanup.Project.Helpers
{
    public class AllDbTestDataCleanUpHelper 
    {
        private readonly DbConfig _dbConfig;

        private string _sqlFileName, _dbName;

        private readonly List<string> usersdeleted = new List<string>();

        private readonly List<string> userswithconstraints = new List<string>();

        public AllDbTestDataCleanUpHelper(DbConfig dbConfig) => _dbConfig = dbConfig;

        public (List<string>, List<string>) CleanUpAllDbTestData(string email)
        {
            var easAccDbSqlDataHelper = new TestDataCleanUpEasAccDbSqlDataHelper(_dbConfig);

            SetDetails(easAccDbSqlDataHelper);

            var userEmailList = easAccDbSqlDataHelper.GetUserEmailList(email);

            if (userEmailList.IsNoDataFound()) return (usersdeleted, userswithconstraints);

            TestDataCleanUpEmailsInUse.AddInUseEmails(userEmailList.ListOfArrayToList(0));

            foreach (var userEmailArray in userEmailList)
            {
                var userEmail = userEmailArray[0];

                try
                {
                    var accountids = easAccDbSqlDataHelper.GetAccountIds(userEmail);

                    var noOfRowsDeleted = CleanUpTestData(userEmail);

                    var accountidsTodelete = accountids.ListOfArrayToList(0);

                    if (!string.IsNullOrEmpty(accountidsTodelete[0])) noOfRowsDeleted += CleanUpAllDbTestData(accountidsTodelete);

                    noOfRowsDeleted += CleanUpEasDbTestData(easAccDbSqlDataHelper, userEmail);

                    usersdeleted.Add($"{userEmail},{accountidsTodelete.ToString(",")},{noOfRowsDeleted} total rows deleted across the dbs");
                }
                catch (Exception ex)
                {
                    userswithconstraints.Add($"{userEmail},{_dbName}({_sqlFileName}){Environment.NewLine}{ex.Message}");
                }
            }

            return (usersdeleted, userswithconstraints);
        }

        private int CleanUpTestData(string userEmail) => CleanUpUsersDbTestData(userEmail) + CleanUpPregDbTestData(userEmail);

        private int CleanUpAllDbTestData(List<string> accountidsTodelete) 
        {
            return CleanUpRsvrTestData(accountidsTodelete) 
                + CleanUpPrelTestData(accountidsTodelete) 
                + CleanUpPsrTestData(accountidsTodelete) 
                + CleanUpPfbeTestData(accountidsTodelete) 
                + CleanUpEmpFcastTestData(accountidsTodelete) 
                + CleanUpEmpFinTestData(accountidsTodelete) 
                + CleanUpEmpIncTestData(accountidsTodelete) 
                + CleanUpAComtTestData(accountidsTodelete) 
                + CleanUpEasLtmTestData(accountidsTodelete) 
                + CleanUpComtTestData(accountidsTodelete);
        }

        private int CleanUpEasDbTestData(TestDataCleanUpEasAccDbSqlDataHelper helper, string email)
        {
            SetDetails(helper);

            return SetDebugMessage(() => helper.CleanUpEasDbTestData(email));
        }

        private int CleanUpComtTestData(List<string> accountidsTodelete)
        {
            var helper = new TestDataCleanupComtSqlDataHelper(_dbConfig);

            SetDetails(helper);

            return SetDebugMessage(() => helper.CleanUpComtTestData(accountidsTodelete));
        }

        private int CleanUpEasLtmTestData(List<string> accountidsTodelete)
        {
            var helper = new TestDataCleanUpEasLtmcSqlDataHelper(_dbConfig);

            SetDetails(helper);

            return SetDebugMessage(() => helper.CleanUpEasLtmTestData(accountidsTodelete));
        }

        private int CleanUpAComtTestData(List<string> accountidsTodelete)
        {
            var helper = new TestDataCleanupAComtSqlDataHelper(_dbConfig);

            SetDetails(helper);

            return SetDebugMessage(() => helper.CleanUpAComtTestData(accountidsTodelete));
        }

        private int CleanUpEmpIncTestData(List<string> accountidsTodelete)
        {
            var helper = new TestDataCleanUpEmpIncSqlDataHelper(_dbConfig);

            SetDetails(helper);

            return SetDebugMessage(() => helper.CleanUpEmpIncTestData(accountidsTodelete));
        }

        private int CleanUpEmpFinTestData(List<string> accountidsTodelete)
        {
            var helper = new TestDataCleanUpEmpFinSqlDataHelper(_dbConfig);

            SetDetails(helper);

            return SetDebugMessage(() => helper.CleanUpEmpFinTestData(accountidsTodelete));
        }

        private int CleanUpEmpFcastTestData(List<string> accountidsTodelete)
        {
            var helper = new TestDataCleanUpEmpFcastSqlDataHelper(_dbConfig);

            SetDetails(helper);

            return SetDebugMessage(() => helper.CleanUpEmpFcastTestData(accountidsTodelete));
        }

        private int CleanUpPfbeTestData(List<string> accountidsTodelete)
        {
            var helper = new TestDataCleanUpPfbeDbSqlDataHelper(_dbConfig);

            SetDetails(helper);

            return SetDebugMessage(() => helper.CleanUpPfbeTestData(accountidsTodelete));
        }

        private int CleanUpPsrTestData(List<string> accountidsTodelete)
        {
            var helper = new TestDataCleanUpPsrDbSqlDataHelper(_dbConfig);

            SetDetails(helper);

            return SetDebugMessage(() => helper.CleanUpPsrTestData(accountidsTodelete));
        }

        private int CleanUpPrelTestData(List<string> accountidsTodelete)
        {
            var helper = new TestDataCleanUpPrelDbSqlDataHelper(_dbConfig);

            SetDetails(helper);

            return SetDebugMessage(() => helper.CleanUpPrelTestData(accountidsTodelete));
        }

        private int CleanUpRsvrTestData(List<string> accountidsTodelete)
        {
            var helper = new TestDataCleanUpRsvrSqlDataHelper(_dbConfig);
            
            SetDetails(helper);

            return SetDebugMessage(() => helper.CleanUpRsvrTestData(accountidsTodelete));
        }

        private int CleanUpPregDbTestData(string email)
        {
            var helper = new TestDataCleanUpPregDbSqlDataHelper(_dbConfig);
            
            SetDetails(helper);
            
            return SetDebugMessage(() => helper.CleanUpPregDbTestData(email));
        }

        private int CleanUpUsersDbTestData(string email)
        {
            var helper = new TestDataCleanUpUsersDbSqlDataHelper(_dbConfig);
            
            SetDetails(helper);
            
            return SetDebugMessage(() => helper.CleanUpUsersDbTestData(email));
        }

        private void SetDetails(TestDataCleanUpSqlDataHelper helper)
        {
            _dbName = helper.dbName;

            _sqlFileName = helper.SqlFileName;
        }

        private int SetDebugMessage(Func<int> func) 
        {
            int noOfrowsDeleted;

            string message;

            try
            {
                noOfrowsDeleted = func();

                message = $"{noOfrowsDeleted} rows deleted from {_dbName}";
            }
            catch (Exception ex)
            {
                noOfrowsDeleted = 0;

                message = $"FAILED to delete from {_dbName}({_sqlFileName})";

                userswithconstraints.Add($"{_dbName}({_sqlFileName}){Environment.NewLine}{ex.Message}");
            }

            usersdeleted.Add(message);

            return noOfrowsDeleted;
        }
    }
}
