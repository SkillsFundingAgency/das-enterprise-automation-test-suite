using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.TestDataExport.StepDefinitions
{
    [Binding]
    public class VerifyDbConnectionSteps
    {
        private readonly DbConfig _dbConfig;

        private readonly ObjectContext _objectContext;

        private List<string> _exception;

        public VerifyDbConnectionSteps(ScenarioContext context)
        {
            _dbConfig = context.Get<DbConfig>();

            _objectContext = context.Get<ObjectContext>();
        }
        
        [Then(@"the db connection are verified")]
        public void ThenTheDbConnectionAreVerified()
        {
            _exception = new List<string>();

            AssertDbConnection(new AssessorDbSqlDataHelper(_dbConfig));
            AssertDbConnection(new LoginDbSqlDataHelper(_dbConfig));
            AssertDbConnection(new QnaDbSqlDataHelper(_dbConfig));
            AssertDbConnection(new ApplyDbSqlDataHelper(_dbConfig));
            AssertDbConnection(new RoatpDbSqlDataHelper(_dbConfig));

            AssertDbConnection(new TestDataCleanupAComtSqlDataHelper(_dbConfig));
            AssertDbConnection(new TestDataCleanupComtSqlDataHelper(_dbConfig));
            AssertDbConnection(new TestDataCleanUpEasLtmcSqlDataHelper(_dbConfig));
            AssertDbConnection(new TestDataCleanUpEmpFcastSqlDataHelper(_dbConfig));
            AssertDbConnection(new TestDataCleanUpEmpFinSqlDataHelper(_dbConfig));
            AssertDbConnection(new TestDataCleanUpEmpIncSqlDataHelper(_dbConfig));
            AssertDbConnection(new TestDataCleanUpPfbeDbSqlDataHelper(_dbConfig));
            AssertDbConnection(new TestDataCleanUpPrelDbSqlDataHelper(_dbConfig));
            AssertDbConnection(new TestDataCleanUpPsrDbSqlDataHelper(_dbConfig));
            AssertDbConnection(new TestDataCleanUpRsvrSqlDataHelper(_dbConfig));

            AssertDbConnection(new EmploymentCheckDbSqlDataHelper(_dbConfig));

            AssertDbConnection(new EasAccDbSqlDataHelper(_dbConfig));
            AssertDbConnection(new ApprenticeCommitmentLoginDbSqlDataHelper(_dbConfig));
            AssertDbConnection(new CrsDbSqlDataHelper(_dbConfig));
            AssertDbConnection(new TprDbSqlDataHelper(_dbConfig));
            AssertDbConnection(new UsersDbSqlDataHelper(_dbConfig));

            if (_exception.Any())
            {
                _exception.ForEach(x => _objectContext.SetDebugInformation(x));

                throw new Exception(string.Join(Environment.NewLine, _exception.Select(x => x)));
            }

        }

        private void AssertDbConnection(ProjectSqlDbHelper helper)
        {
            (string caller, string connectionString) = helper.GetCaller();

            string message = string.Empty; 
            string failuremessage = string.Empty;

            var list = connectionString.Split(";");

            if (connectionString.Contains("User ID="))
            {
                var user = list.Single(x => x.StartsWith("User ID=")).Remove(0, 8);
                var password = list.Single(x => x.StartsWith("Password=")).Remove(0, 9).Substring(0,3);
                var dbName = list.Single(x => x.StartsWith("Database=")).Remove(0, 9);

                var creds = $"'{user},{password}'";

                message = $"{creds} connected sucessfully to '{dbName}'";
                failuremessage = $"FAILED - {creds} could not be connected to '{dbName}'";
            }
            else
            {
                var dbName = list.Single(x => x.StartsWith("Initial Catalog="));
                message = $"AAD user connected sucessfully to '{dbName}'";
                failuremessage = $"FAILED - AAD user could not be connected to '{dbName}'";
            }

            try
            {
                string catalog = helper.GetTableCatalog();

                StringAssert.StartsWith("das-", catalog);

                _objectContext.SetDebugInformation(message);

            }
            catch (Exception)
            {
                _exception.Add(failuremessage);
            }
        }
    }
}
