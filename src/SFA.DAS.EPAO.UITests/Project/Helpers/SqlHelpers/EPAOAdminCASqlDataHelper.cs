namespace SFA.DAS.EPAO.UITests.Project.Helpers.SqlHelpers;

public class EPAOAdminCASqlDataHelper : SqlDbHelper
{
    public EPAOAdminCASqlDataHelper(DbConfig dbConfig) : base(dbConfig.AssessorDbConnectionString) { }

    public void DeleteCertificate(string uln, string standardcode)
    {
        if (string.IsNullOrEmpty(uln)) return;

        ExecuteSqlCommand($"DELETE from certificatelogs where certificateid = (select id from certificates where uln = {uln} and StandardCode = {standardcode});" +
        $"DELETE from certificates where uln = {uln} and StandardCode = {standardcode}");

        EPAOCAInUseUlns.RemoveInUseUln(uln);
    }

    public List<string> GetStaticTestData((string familyName, string uln) data)
    {
        var query = $"select top 1 uln, StdCode, title, GivenNames, FamilyName from [Ilrs] join standards on larscode = stdcode and uln = {data.uln} and FamilyName = '{data.familyName}'";

        return GetTestData(() => GetData(query));
    }

    public List<string> GetCATestData(string email, LearnerCriteria learnerCriteria) => GetTestData(() => GetTestData(email, learnerCriteria));

    private List<string> GetTestData(Func<List<string>> func)
    {
        List<string> data = new List<string>();

        int i = 0;

        while (i <= 2)
        {
            data = func();

            var uln = data[0];

            if (!string.IsNullOrEmpty(uln) && EPAOCAInUseUlns.IsNotInUseUln(uln))
            {
                return data;
            }
            else i++;
        }

        return data;
    }

    private List<string> GetTestData(string email, LearnerCriteria learnerCriteria)
    {
        string query = FileHelper.GetSql(GetLearnersDataSqlFileName(learnerCriteria));

        Dictionary<string, string> sqlParameters = new Dictionary<string, string>
        {
            { "@endPointAssessorEmail", email }
        };

        query = GetTestData(query, learnerCriteria.IsActiveStandard, learnerCriteria.HasMultipleVersions, learnerCriteria.WithOptions, learnerCriteria.VersionConfirmed, learnerCriteria.OptionIsSet);

        return GetData(query, sqlParameters);
    }

    private string GetTestData(string sqlQueryFromFile, bool isActiveStandard, bool hasMultipleVersions, bool withOptions, bool versionConfirmed, bool optionSet)
    {
        sqlQueryFromFile = Regex.Replace(sqlQueryFromFile, @"__Isactivestandard__", isActiveStandard ? $"{1}" : $"{0}");
        sqlQueryFromFile = Regex.Replace(sqlQueryFromFile, @"__HasVersions__", hasMultipleVersions ? $"{1}" : $"{0}");
        sqlQueryFromFile = Regex.Replace(sqlQueryFromFile, @"__HasOptions__", withOptions ? $"{1}" : $"{0}");
        sqlQueryFromFile = Regex.Replace(sqlQueryFromFile, @"__InUseUln__", EPAOCAInUseUlns.GetInUseUln());

        sqlQueryFromFile = Regex.Replace(sqlQueryFromFile, @"__VersionConfirmed__", versionConfirmed ? $"{1}" : $"{0}");
        sqlQueryFromFile = Regex.Replace(sqlQueryFromFile, @"__OptionSet__", optionSet ? $"{1}" : $"{0}");


        return sqlQueryFromFile;
    }

    private string GetLearnersDataSqlFileName(LearnerCriteria learnerCriteria) => learnerCriteria.HasMultiStandards ? "GetMultiStandardLearnersData" : "GetSingleStandardLearnersData";
}
