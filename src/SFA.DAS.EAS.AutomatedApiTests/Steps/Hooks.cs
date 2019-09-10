using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
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

        private static string CreateAccount(string accountHashedId, string accountPublicHashedId, string legalEntityCode, string legalEntityName,
             string legalEntityAddress, DateTime dateOfIncorporation, string legalEntityStatus, short legalEntitySource, string payeRef, string payeName, string publicHashId)
        {
            return $"EXECUTE #CreateAccount '{accountHashedId}', '{accountPublicHashedId}', '{legalEntityCode}', '{legalEntityName}', '{legalEntityAddress}', '{dateOfIncorporation.ToString("U")}', '{legalEntityStatus}', {legalEntitySource}, '{payeRef}', '{payeName}', '{publicHashId}'";
        }

        private static string ClearAccount(string accountHashedId, string legalEntityName)
        {
            return $"EXECUTE #ClearSeededData '{accountHashedId}', '{legalEntityName}'";
        }

        [BeforeTestRun]
        public static void BeforeFeature()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationHelper.Instance.Configuration["AccountsDbConnectionString"]))
            {
                // Clear Existing Accounts
                var clear = ClearAccount("JRML7V", "Tesco Plc");
                var clearScript = string.Format(Resources.ClearSeededData, clear);

                var server = new Server(new ServerConnection(connection));
                server.ConnectionContext.ExecuteNonQuery(clearScript);

                // Seed the Database:
                var add = CreateAccount("JRML7V", "LDMVWV", "00445790", "Tesco Plc", "Tesco House, Shire Park, Kestrel Way, Welwyn Garden City, AL7 1GA", new DateTime(1947, 11, 27), "active", 1, "222/ZZ00002", "NA", "AAA123");
                var populatedSeedScript = string.Format(Resources.SeedScript, add);

                server.ConnectionContext.ExecuteNonQuery(populatedSeedScript);
            }
        }

        [AfterTestRun]
        public static void AfterFeature()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationHelper.Instance.Configuration["AccountsDbConnectionString"]))
            {
                // Clear Existing Accounts
                var clear = ClearAccount("JRML7V", "Tesco Plc");
                var clearScript = string.Format(Resources.ClearSeededData, clear);

                var server = new Server(new ServerConnection(connection));
                server.ConnectionContext.ExecuteNonQuery(clearScript);
            }
        }
    }
}
