namespace SFA.DAS.ManagingStandards.UITests.Project.Helpers;

public class ManagingStandardsSqlDataHelper : SqlDbHelper
{
    public ManagingStandardsSqlDataHelper(DbConfig dbConfig) : base(dbConfig.ManagingStandardsDatabaseConnectionString) { }

    public void ClearRegulation(string ukprn, string larsCode) => ExecuteSqlCommand($"update providercourse set IsApprovedByRegulator = NULL " +
        $"where LarsCode = '{larsCode}' and providerid = (select Id from provider where ukprn = {ukprn})");

    public void AddSingleProviderLocation(string ukprn, string larsCode) => ExecuteSqlCommand($"DECLARE @providerId int;" +
        $"select @providerId = id from provider where ukprn = {ukprn};" +
        $"DECLARE @CentralHairHarlowLocationId  int;" +
        $"select @CentralHairHarlowLocationId = id from ProviderLocation where LocationName = 'CENTRAL HAIR HARLOW' and ProviderId = @providerId;" +
        $"DECLARE @ProviderCourseIdLarsCode int;" +
        $"select @ProviderCourseIdLarsCode = id from providerCourse where providerId = @providerId and larsCode={larsCode};" +
        $"Delete from ProviderCourseLocation where ProviderCourseId = @ProviderCourseIdLarsCode;" +
        $"if (not exists (select * from providerCourseLocation where ProviderCourseId = @ProviderCourseIdLarsCode))" +
        $"BEGIN INSERT INTO [dbo].[ProviderCourseLocation] " +
        $"([NavigationId],[ProviderCourseId],[ProviderLocationId],[HasDayReleaseDeliveryOption],[HasBlockReleaseDeliveryOption],[IsImported]) " +
        $"VALUES (newId(), @ProviderCourseIdLarsCode, @CentralHairHarlowLocationId,1, 0, 0) END;");

}
