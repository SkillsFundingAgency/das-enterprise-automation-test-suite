using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.EarlyConnect.APITests.Project.Helpers;

public class EarlyConnectSqlHelper(ObjectContext objectContext, DbConfig config) : SqlDbHelper(objectContext, config.EarlyConnectConnectionString)
{
    public void DeleteStudentData(string email)
    {
        string sqlQuery = $@"select id into #StudentId from StudentData where email = '{email}';
        select Id into #StudentSurveyId from StudentSurvey where StudentId in (select id from #StudentId);
        delete from StudentAnswer where StudentSurveyId in (select id from #StudentSurveyId)
        delete from StudentSurvey where StudentId in (select id from #StudentId)
        delete from StudentData where Id in (select id from #StudentId)
        drop table #StudentId
        drop table #StudentSurveyId";

        ExecuteSqlCommand(sqlQuery);
    }
}
