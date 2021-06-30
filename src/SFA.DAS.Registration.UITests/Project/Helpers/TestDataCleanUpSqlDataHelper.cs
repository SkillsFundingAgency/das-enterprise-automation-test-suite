using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class TestDataCleanUpSqlDataHelper : SqlDbHelper
    {
        public TestDataCleanUpSqlDataHelper(DbConfig dbConfig) : base(dbConfig.AccountsDbConnectionString) { }

        public (List<string>, List<string>) CleanUpFromEasAccDb(string email)
        {
            List<string> usersdeleted = new List<string>();

            List<string> userswithconstraints = new List<string>();

            var userEmailList = GetMultipleData($"select Email from employer_account.[User] where Email like ('%{email}%')", 1);

            if (userEmailList.Count == 1 && string.IsNullOrEmpty(userEmailList[0][0])) return (usersdeleted, userswithconstraints);

            foreach (var userEmailArray in userEmailList)
            {
                string userEmail = userEmailArray[0];

                try
                {
                    SqlDatabaseConnectionHelper.ExecuteSqlCommand(FileHelper.GetSql("TestDataCleanUp"), connectionString, new Dictionary<string, string> { { "@email", userEmail } });

                    usersdeleted.Add(userEmail);
                }
                catch (Exception)
                {
                    userswithconstraints.Add(userEmail);
                }
            }

            return (usersdeleted, userswithconstraints);
        }
    }
}
