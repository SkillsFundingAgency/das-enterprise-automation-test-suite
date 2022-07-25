using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Helpers
{
    public class ManagingStandardsSqlDataHelper : SqlDbHelper
    {
        public ManagingStandardsSqlDataHelper(DbConfig dbConfig) : base(dbConfig.ManagingStandardsDatabaseConnectionString) { }

        public void ClearRegulation(string ukprn) => ExecuteSqlCommand($"update providercourse set IsApprovedByRegulator = NULL " +
            $"where LarsCode = '203' and providerid = (select Id from provider where ukprn = {ukprn})");

        public void AddSingleProviderLocation(string ukprn) => ExecuteSqlCommand($"DECLARE @providerId int;" +
            $"select @providerId=id from provider where ukprn = 10001259;" +
            $"DECLARE @CentralHairHarlowLocationId  int;" +
            $"select @CentralHairHarlowLocationId=id from ProviderLocation where LocationName='CENTRAL HAIR HARLOW' and ProviderId=@providerId;" +
            $"DECLARE @ProviderCourseIdLarsCode203 int;" +
            $"select @ProviderCourseIdLarsCode203 = id from providerCourse where providerId = @providerId and larsCode=203;" +
            $"Delete from ProviderCourseLocation where ProviderCourseId = @ProviderCourseIdLarsCode203;" +
            $"if (not exists (select * from providerCourseLocation where ProviderCourseId = @ProviderCourseIdLarsCode203))" +
            $"BEGIN INSERT INTO [dbo].[ProviderCourseLocation]" +
            $"([NavigationId],[ProviderCourseId],[ProviderLocationId],[HasDayReleaseDeliveryOption],[HasBlockReleaseDeliveryOption],[IsImported])" +
            $"VALUES (newId(), @ProviderCourseIdLarsCode203, @CentralHairHarlowLocationId,1, 0,0) END;");

    }
}
