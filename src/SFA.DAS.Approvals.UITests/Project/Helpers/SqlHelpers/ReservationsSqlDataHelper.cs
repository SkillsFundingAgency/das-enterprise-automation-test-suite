using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers
{
    public class ReservationsSqlDataHelper : SqlDbHelper
    {
        public ReservationsSqlDataHelper(ObjectContext objectContext, DbConfig dBConfig) : base(objectContext, dBConfig.ReservationsDbConnectionString) { }

        public void UpdateDynamicPauseGlobalRule(DateTime activeFrom, DateTime activeTo) => UpdateGlobalRule(activeFrom, activeTo, 1, 3);

        private void UpdateGlobalRule(DateTime activeFrom, DateTime activeTo, int restriction, int ruleType)
        {
            var activeFromDbDateTime = activeFrom.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var activeToDbDateTime = activeTo.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string updateQuery = $@"UPDATE [dbo].[GlobalRule]
                                      SET   ActiveFrom = '{activeFromDbDateTime}',
                                            ActiveTo = '{activeToDbDateTime}',
                                            Restriction = {restriction}
                                      WHERE RuleType = {ruleType}";

            ExecuteSqlCommand(updateQuery);            
        }
    }
}
