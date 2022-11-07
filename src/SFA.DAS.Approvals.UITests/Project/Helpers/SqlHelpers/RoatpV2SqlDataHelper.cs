using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;

public class RoatpV2SqlDataHelper : SqlDbHelper
{
    private readonly string _ukprn;

    public RoatpV2SqlDataHelper(DbConfig dbConfig, string ukprn) : base(dbConfig.ManagingStandardsDbConnectionString) => _ukprn = ukprn;

    internal List<string> GetPortableFlexiJobLarsCode() => string.IsNullOrEmpty(_ukprn) ? new List<string>() {""} : GetMultipleData($"select pc.LarsCode from ProviderCourse pc Join [Provider] p on pc.ProviderId = p.id where HasPortableFlexiJobOption = 1 and ukprn = '{_ukprn}' order by NEWID();").ListOfArrayToList(0);
}
