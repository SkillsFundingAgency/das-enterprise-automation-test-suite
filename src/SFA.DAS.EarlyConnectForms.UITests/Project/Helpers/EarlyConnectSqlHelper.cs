using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Helpers;

public class EarlyConnectSqlHelper(ObjectContext objectContext, DbConfig config) : SqlDbHelper(objectContext, config.EarlyConnectConnectionString)
{
    public string GetAnEducationalOrganisation()
    {
        //var query = "select [Name] from EducationalOrganisation";

        //var names = GetListOfData(query).Select(x => (string)x[0]).ToList();

        //List<string> names = ["Bishop ", "Cramlington ", "North East Futures ", "Haydon Bridge High School", "East Durham College"];

        var name = "college";

        //objectContext.SetDebugInformation($"'{name}' is selected from the table [Name]");

        return name;
    }

    public void DeleteStudentDataAndAnswersByEmail(string email)
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