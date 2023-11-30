using System;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Helpers;

public class AANSqlHelper : SqlDbHelper
{
    public AANSqlHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig.AANDbConnectionString) { }

    public (string, DateTime) GetNextEventStartDate()
    {
        var date = DateTime.UtcNow.AddDays(1).ToString("yyyy-MM-dd");
        var list = GetData($"select Id, startdate from CalendarEvent where startdate > '{date}' order by StartDate ");

        return (list[0], DateTime.Parse(list[1]));
    }

    public void ResetApprenticeOnboardingJourney(string email) => ExecuteSqlCommand
         ($"IF EXISTS(select * from Member where email = '{email}')" +
         $" BEGIN " +
         $"DECLARE @MemberId VARCHAR(36);" +
         $"SELECT @MemberId = Id from Member where email = '{email}'" +
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
     $"DELETE FROM EventGuest where CalendarEventId in (Select CalendarEventId from Apprentice WHERE MemberId = @MemberId);" +
     $"DELETE FROM Employer WHERE MemberId = @MemberId;" +
     $"DELETE FROM MemberProfile WHERE MemberId = @MemberId;" +
     $"DELETE FROM MemberPreference WHERE MemberId = @MemberId;" +
     $"DELETE FROM Attendance WHERE MemberId = @MemberId;" +
     $"DELETE FROM Notification WHERE MemberId = @MemberId;" +
     $"DELETE FROM Member WHERE Id = @MemberId;" +
     $" END ");


    public string GetEventId(string eventTitle)
    {
        waitForResults = true;

        return GetDataAsString($"select Id from CalendarEvent where title = '{eventTitle}'");
    }

    public void DeleteAdminCreatedEvent(string eventId) => ExecuteSqlCommand
        ($"DECLARE @EventId VARCHAR(36) = '{eventId}' " +
        $"IF EXISTS(select * from CalendarEvent where Id = @EventId) " +
        $"BEGIN " +
        $"DELETE FROM EventGuest where CalendarEventId = @EventId " +
        $"DELETE FROM CalendarEvent WHERE Id = @EventId; " +
        $"END");
}
