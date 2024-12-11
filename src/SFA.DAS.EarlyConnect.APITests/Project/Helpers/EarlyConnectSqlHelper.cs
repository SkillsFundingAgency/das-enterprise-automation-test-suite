using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.EarlyConnect.APITests.Project.Helpers;

public class EarlyConnectSqlHelper(ObjectContext objectContext, DbConfig config) : SqlDbHelper(objectContext, config.EarlyConnectConnectionString)
{
    public void DeleteStudentData(string email)
    {
        string sqlQuery = $@" select id into #StudentId from StudentData where email = '{email}';
            delete from StudentData where Id in (select id from #StudentId);
            drop table #StudentId;";

        ExecuteSqlCommand(sqlQuery);
    }

    public void DeleteMetricsData()
    {
        string sqlQuery = $@"SELECT Id INTO #MetricIds FROM ApprenticeMetricsData WHERE DateAdded >= DATEADD(MINUTE, -15, GETDATE());
                DELETE FROM ApprenticeMetricsData
                WHERE Id IN (SELECT Id FROM #MetricIds);
                DROP TABLE #MetricIds;";


        ExecuteSqlCommand(sqlQuery);
    }
}
