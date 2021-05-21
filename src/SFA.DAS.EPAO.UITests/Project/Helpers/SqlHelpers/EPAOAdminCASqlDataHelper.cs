using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EPAO.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SFA.DAS.EPAO.UITests.Project.Helpers.SqlHelpers
{
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

        public List<string> GetCATestData(string email, LeanerCriteria leanerCriteria)
        {
            List<string> data = new List<string>();

            int i = 0;

            while (i <= 2)
            {
                data = GetTestData(email, leanerCriteria);

                var uln = data[0];

                if (EPAOCAInUseUlns.IsNotInUseUln(uln))
                {
                    return data;
                }
                else i++;
            }

            return data;
        }

        private List<string> GetTestData(string email, LeanerCriteria leanerCriteria)
        {
            string query = FileHelper.GetSql(GetLearnersDataSqlFileName(leanerCriteria));

            Dictionary<string, string> sqlParameters = new Dictionary<string, string>
            {
                { "@endPointAssessorEmail", email }
            };

            query = GetTestData(query, leanerCriteria.IsActiveStandard, leanerCriteria.HasMultipleVersions, leanerCriteria.WithOptions);

            TestContext.Progress.WriteLine(query);

            return GetData(query, 5, sqlParameters);
        }

        private string GetTestData(string sqlQueryFromFile, bool isActiveStandard, bool hasMultipleVersions, bool withOptions)
        {
            sqlQueryFromFile = Regex.Replace(sqlQueryFromFile, @"__Isactivestandard__", isActiveStandard ? $"{1}" : $"{0}");
            sqlQueryFromFile = Regex.Replace(sqlQueryFromFile, @"__HasVersions__", hasMultipleVersions ? $"{1}" : $"{0}");
            sqlQueryFromFile = Regex.Replace(sqlQueryFromFile, @"__HasOptions__", withOptions ? $"{1}" : $"{0}");
            sqlQueryFromFile = Regex.Replace(sqlQueryFromFile, @"__InUseUln__", EPAOCAInUseUlns.GetInUseUln());
            

            return sqlQueryFromFile;
        }

        private string GetLearnersDataSqlFileName(LeanerCriteria leanerCriteria) => leanerCriteria.HasMultiStandards ? "GetMultiStandardLearnersData" : "GetSingleStandardLearnersData";
    }
}
