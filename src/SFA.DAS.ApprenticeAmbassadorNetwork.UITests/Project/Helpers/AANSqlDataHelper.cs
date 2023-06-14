namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Helpers;

public class AANSqlDataHelper : SqlDbHelper
{
    public AANSqlDataHelper(DbConfig dbConfig) : base(dbConfig.AANDbConnectionString) { }

    public void ResetApprenticeOnboardingJourney(string email) => ExecuteSqlCommand
         ($"IF EXISTS(select * from Member where email = '{email}'" +
         $" BEGIN " +
         $"DECLARE @MemberId VARCHAR(36);" +
         $"SELECT @MemberId = Id from Member where email = '{email}'" +
         $"DELETE FROM EventGuest where CalendarEventId in (Select CalendarEventId from Apprentice WHERE MemberId = @MemberId);" +
         $"DELETE FROM Apprentice WHERE MemberId = @MemberId;" +
         $"DELETE FROM MemberProfile WHERE MemberId = @MemberId;" +
         $"DELETE FROM Attendance WHERE MemberId = @MemberId;" +
         $"DELETE FROM Notification WHERE MemberId = @MemberId;" +
         $"DELETE FROM Member WHERE Id = @MemberId;" +
         $" END ");

}
