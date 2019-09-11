using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using SFA.DAS.EAS.AutomatedApiTests.Database;
using SFA.DAS.EAS.AutomatedApiTests.Helpers;
using SFA.DAS.EAS.AutomatedApiTests.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EAS.AutomatedApiTests.Steps
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private static string CreateAccount(SeedAccount a)
        {
            return $"EXECUTE #CreateAccount '{a.AccountHashedId}', '{a.AccountPublicHashedId}', '{a.LegalEntityCode}', '{a.LegalEntityName}', '{a.LegalEntityAddress}', '{a.DateOfIncorporation.ToString("U")}', '{a.LegalEntityStatus}', {a.LegalEntitySource}, '{a.PayeRef}', '{a.PayeName}', '{a.PublicHashId}', '{a.UserFirstName}', '{a.UserLastName}', '{a.UserEmailAddress}'";
        }

        private static string ClearAccount(string accountHashedId, string legalEntityName, string userEmailAddress)
        {
            return $"EXECUTE #ClearSeededData '{accountHashedId}', '{legalEntityName}', '{userEmailAddress}'";
        }

        [BeforeTestRun]
        public static void BeforeFeature()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationHelper.Instance.Configuration["AccountsDbConnectionString"]))
            {
                // Clear Existing Accounts
                var clearSB = new StringBuilder();
                SeedData.SeedAccounts.ForEach(s => clearSB.AppendLine(ClearAccount(s.AccountHashedId, s.LegalEntityName, s.UserEmailAddress)));
                var clearScript = string.Format(Resources.ClearSeededData, clearSB.ToString());

                var server = new Server(new ServerConnection(connection));
                server.ConnectionContext.ExecuteNonQuery(clearScript);

                // Seed the Database:
                var addSB = new StringBuilder();
                SeedData.SeedAccounts.ForEach(s => addSB.AppendLine(CreateAccount(s)));
                var populatedSeedScript = string.Format(Resources.SeedScript, addSB.ToString());
                server.ConnectionContext.ExecuteNonQuery(populatedSeedScript);
            }
        }

        [AfterTestRun]
        public static void AfterFeature()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationHelper.Instance.Configuration["AccountsDbConnectionString"]))
            {
                // Clear Existing Accounts
                var clearSB = new StringBuilder();
                SeedData.SeedAccounts.ForEach(s => clearSB.AppendLine(ClearAccount(s.AccountHashedId, s.LegalEntityName, s.UserEmailAddress)));
                var clearScript = string.Format(Resources.ClearSeededData, clearSB.ToString());

                var server = new Server(new ServerConnection(connection));
                server.ConnectionContext.ExecuteNonQuery(clearScript);
            }
        }
    }
}
