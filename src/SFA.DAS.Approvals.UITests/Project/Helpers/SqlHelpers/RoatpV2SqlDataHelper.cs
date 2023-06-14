using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;

public class RoatpV2SqlDataHelper : SqlDbHelper
{
    public RoatpV2SqlDataHelper(DbConfig dbConfig) : base(dbConfig.ManagingStandardsDbConnectionString) { }

    internal List<string> GetPortableFlexiJobLarsCode(string ukprn) => GetCourses($"select pc.LarsCode from ProviderCourse pc Join [Provider] p on pc.ProviderId = p.id where HasPortableFlexiJobOption = 1 and ukprn = '{ukprn}' order by NEWID();");

    internal List<string> GetCoursesthatProviderDeosNotOffer(string ukprn) => GetCourses($"SELECT LarsCode FROM [dbo].[Standard] WHERE LarsCode NOT IN ({ProviderCourseQuery(ukprn)}) order by NEWID();");

    internal List<string> GetCoursesThatProviderDeosOffer(string ukprn) => GetCourses($"{ProviderCourseQuery(ukprn)} order by NEWID();");
    
    private List<string> GetCourses(string query) 
    {
        var data = GetMultipleData(query);

        if (data.IsNoDataFound()) throw new System.Exception($"No rows found for query {query}");

        return data.ListOfArrayToList(0);
    }

    private string ProviderCourseQuery(string ukprn) => $"SELECT LarsCode FROM [dbo].[ProviderCourse] WHERE ProviderId = (SELECT id FROM [Provider] WHERE ukprn = {ukprn})";
}
