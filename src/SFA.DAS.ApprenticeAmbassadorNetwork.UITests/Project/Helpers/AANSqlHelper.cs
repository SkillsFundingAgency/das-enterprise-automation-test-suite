using System;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Helpers;

public class AANSqlHelper(ObjectContext objectContext, DbConfig dbConfig) : SqlDbHelper(objectContext, dbConfig.AANDbConnectionString)
{
    public (string id, string FullName) GetLiveApprenticeDetails(bool isRegionalChair, string email)
    {
        string GetuserType() => isRegionalChair ? string.Empty : "UserType = 'Apprentice' and";

        int GetIsRegionalChairint() => isRegionalChair ? 1 : 0;

        var query = $"select top 1 Id, FirstName, LastName from Member where {GetuserType()} IsRegionalChair = {GetIsRegionalChairint()} and Email != '{email}' and status = 'Live' order by NEWID()";

        var list = GetData(query);

        return (list[0], $"{list[1]} {list[2]}");
    }

    public (string id , DateTime startdate) GetNextActiveEventDetails(string email)
    {
        var date = DateTime.UtcNow.AddDays(1).ToString("yyyy-MM-dd");

        var query = $"select Id, startdate from CalendarEvent where startdate > '{date}' and IsActive = 'True' and id not in (select CalendarEventId from Attendance where MemberId = (select Id from Member where email = '{email}')) order by StartDate";

        var list = GetData(query);

        return (list[0], DateTime.Parse(list[1]));
    }

    public void ResetApprenticeOnboardingJourney(string email) => ExecuteSqlCommand
         ($"IF EXISTS(select * from Member where email = '{email}')" +
         $" BEGIN " +
         $"DECLARE @MemberId VARCHAR(36);" +
         $"SELECT @MemberId = Id from Member where email = '{email}'" +
         $"DELETE FROM Audit WHERE ActionedBy = @MemberId;" +
         $"DELETE FROM MemberLeavingReason WHERE MemberId = @MemberId;" +
         $"DELETE FROM EventGuest where CalendarEventId in (Select CalendarEventId from Apprentice WHERE MemberId = @MemberId);" +
         $"DELETE FROM Apprentice WHERE MemberId = @MemberId;" +
         $"DELETE FROM MemberProfile WHERE MemberId = @MemberId;" +
         $"DELETE FROM MemberPreference WHERE MemberId = @MemberId;" +
         $"DELETE FROM Attendance WHERE MemberId = @MemberId;" +
         $"DELETE FROM Notification WHERE MemberId = @MemberId;" +
         $"DELETE FROM Member WHERE Id = @MemberId;" +
         $" END ");

    public void ResetEmployerOnboardingJourney(string email) => ExecuteSqlCommand
     ($"IF EXISTS(select * from Member where email = '{email}')" +
     $" BEGIN " +
     $"DECLARE @MemberId VARCHAR(36);" +
     $"SELECT @MemberId = Id from Member where email = '{email}'" +
     $"DELETE FROM Audit WHERE ActionedBy = @MemberId;" +
     $"DELETE FROM MemberLeavingReason WHERE MemberId = @MemberId;" +
     $"DELETE FROM EventGuest where CalendarEventId in (Select CalendarEventId from Apprentice WHERE MemberId = @MemberId);" +
     $"DELETE FROM Employer WHERE MemberId = @MemberId;" +
     $"DELETE FROM MemberProfile WHERE MemberId = @MemberId;" +
     $"DELETE FROM MemberPreference WHERE MemberId = @MemberId;" +
     $"DELETE FROM Attendance WHERE MemberId = @MemberId;" +
     $"DELETE FROM Notification WHERE MemberId = @MemberId;" +
     $"DELETE FROM Member WHERE Id = @MemberId;" +
     $" END ");


    public (string id, string isActive) GetEventId(string eventTitle)
    {
        waitForResults = true;

        var data = GetData($"select Id, IsActive from CalendarEvent where title = '{eventTitle}'");

        return (data[0], data[1]);
    }

    public void DeleteAdminCreatedEvent(string eventId) => ExecuteSqlCommand
        ($"DECLARE @EventId VARCHAR(36) = '{eventId}' " +
        $"IF EXISTS(select * from CalendarEvent where Id = @EventId) " +
        $"BEGIN " +
        $"DELETE FROM EventGuest where CalendarEventId = @EventId " +
        $"DELETE FROM CalendarEvent WHERE Id = @EventId; " +
        $"END");
}
