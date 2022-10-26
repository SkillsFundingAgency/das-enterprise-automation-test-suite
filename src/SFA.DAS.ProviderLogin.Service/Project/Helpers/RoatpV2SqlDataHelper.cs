using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.ProviderLogin.Service.Project.Helpers;

public class RoatpV2SqlDataHelper : SqlDbHelper
{
    public RoatpV2SqlDataHelper(DbConfig dbConfig) : base(dbConfig.ManagingStandardsDbConnectionString) { }

    internal string GetPortableFlexiJobLarsCode(string ukprn) => GetDataAsString($"select top 1 pc.LarsCode from ProviderCourse pc Join [Provider] p on pc.ProviderId = p.id where HasPortableFlexiJobOption = 1 and ukprn = {ukprn} order by NEWID();");
}
