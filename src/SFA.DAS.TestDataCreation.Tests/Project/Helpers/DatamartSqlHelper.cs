using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.TestDataCreation.Tests.Project.Helpers
{
    public class DatamartSqlHelper : SqlDbHelper
    {
        public DatamartSqlHelper(DbConfig dBConfig) : base(dBConfig.DatamartDbConnectionString) { }

        public List<string []> GetPaymentsData() => GetMultipleData("select LearnerUln, ApprenticeshipId from StgPmts.Payment GROUP by LearnerUln, ApprenticeshipId");

        public void ExecuteSqlCommand(List<string> queryToExecute) => ExecuteSqlCommand(string.Join(string.Empty, queryToExecute));
    }
}
