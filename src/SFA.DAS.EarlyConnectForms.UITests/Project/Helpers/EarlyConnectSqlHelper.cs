using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;
using System.Linq;

public class EarlyConnectSqlHelper(ObjectContext objectContext, DbConfig config) : SqlDbHelper(objectContext, config.EarlyConnectConnectionString)
{
    public string GetAnEducationalOrganisation()
    {
        //var query = "select [Name] from EducationalOrganisation";

        //var names = GetListOfData(query).Select(x => (string)x[0]).ToList();

        List<string> names = ["Bishop ", "Cramlington ", "North East Futures ", "Haydon Bridge High School", "East Durham College"];

        var name = RandomDataGenerator.GetRandomElementFromListOfElements(names);

        objectContext.SetDebugInformation($"'{name}' is selected from the table [Name]");

        return name;
    }

    public void DeleteStudentDataAndAnswersByEmail(string email)
    {
        string sqlQuery = $@"
        IF EXISTS(SELECT 1 FROM StudentData WHERE Email = '{email}')
        BEGIN
            DECLARE @StudentId INT;
            SELECT @StudentId = Id FROM StudentData WHERE Email = '{email}';
            -- Delete related StudentAnswers
            DELETE sa
            FROM StudentAnswer sa
            JOIN StudentSurvey ss ON sa.StudentSurveyId = ss.Id
            WHERE ss.StudentId = @StudentId;
            -- Delete related StudentSurveys
            DELETE ss
            FROM StudentSurvey ss
            WHERE ss.StudentId = @StudentId;
            -- Delete the StudentData record
            DELETE FROM StudentData WHERE Email = '{email}';
        END";

        ExecuteSqlCommand(sqlQuery);
    }
}
