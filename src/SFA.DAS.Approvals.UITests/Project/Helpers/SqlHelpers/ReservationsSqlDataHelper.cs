using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers
{
    public class ReservationsSqlDataHelper : SqlDbHelper
    {
        public ReservationsSqlDataHelper(DbConfig dBConfig) : base(dBConfig.ReservationsDbConnectionString) { }

        public int InsertDynamicPauseGlobalRule(DateTime activeFrom, DateTime activeTo, string title)
        {
            return InsertGlobalRule(activeFrom, activeTo, 1, 3, title);
        }

        private int InsertGlobalRule(DateTime activeFrom, DateTime activeTo, int restriction, int ruleType, string title)
        {
            var activeFromDbDateTime = activeFrom.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var activeToDbDateTime = activeTo.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string insertQuery = $"INSERT INTO [dbo].[GlobalRule] (ActiveFrom, ActiveTo, Restriction, RuleType) " +
                $"VALUES ('{activeFromDbDateTime}', '{activeToDbDateTime}', {restriction}, {ruleType})";

            ExecuteSqlCommand(insertQuery);

            string selectQuery = $"SELECT Id FROM [dbo].[GlobalRule] WHERE ActiveFrom = '{activeFromDbDateTime}' AND ActiveTo = '{activeToDbDateTime}' " +
                $"AND Restriction = {restriction} AND RuleType = {ruleType}";

            return Convert.ToInt32(TryGetDataAsObject(selectQuery, title));
        }

        public void DeleteDynamicPauseGlobalRule(int id)
        {
            string query = $"DELETE FROM [dbo].[GlobalRule] WHERE Id = {id}";
            ExecuteSqlCommand(query);
        }
    }
}
