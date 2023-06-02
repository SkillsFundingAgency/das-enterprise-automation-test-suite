using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;

public class RoatpV2SqlDataHelper : SqlDbHelper
{
    public RoatpV2SqlDataHelper(DbConfig dbConfig) : base(dbConfig.ManagingStandardsDbConnectionString) { }

    internal List<string> GetPortableFlexiJobLarsCode(string ukprn) => string.IsNullOrEmpty(ukprn) ? new List<string>() {""} : GetMultipleData($"select pc.LarsCode from ProviderCourse pc Join [Provider] p on pc.ProviderId = p.id where HasPortableFlexiJobOption = 1 and ukprn = '{ukprn}' order by NEWID();").ListOfArrayToList(0);

    internal List<string> GetCourseProviderDeosNotOffer(string ukprn)
    {
        if (string.IsNullOrEmpty(ukprn)) return new List<string>() { "" };

        string query = $"SELECT LarsCode FROM [dbo].[Standard] WHERE LarsCode NOT IN ( SELECT LarsCode FROM [dbo].[ProviderCourse] WHERE ProviderId = (SELECT id FROM [Provider] WHERE ukprn = {ukprn})) order by NEWID();";

        var data = GetMultipleData(query);

        if (data.IsNoDataFound()) throw new System.Exception($"No course found that the {ukprn} provider does not offer using query {query}");

        return data.ListOfArrayToList(0);
    }
}
