using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SFA.DAS.EPAO.UITests.Project.Helpers.SqlHelpers
{
    public class EPAOAdminCASqlDataHelper : SqlDbHelper
    {
        private readonly string[] _tags;

        public EPAOAdminCASqlDataHelper(DbConfig dbConfig, string[] tags) : base(dbConfig.AssessorDbConnectionString) => _tags = tags;

        public void DeleteCertificate(string uln, string standardcode)
        {
            if (string.IsNullOrEmpty(uln)) return;

            ExecuteSqlCommand($"DELETE from certificatelogs where certificateid = (select id from certificates where uln = {uln} and StandardCode = {standardcode});" +
            $"DELETE from certificates where uln = {uln} and StandardCode = {standardcode}");

            EPAOCAInUseUlns.RemoveInUseUln(uln);
        }

        public List<string> GetCATestData(string email)
        {
            List<string> data = new List<string>();

            int i = 0;

            while (i <= 2)
            {
                data = GetTestData(email);

                var uln = data[0];

                if (EPAOCAInUseUlns.IsNotInUseUln(uln))
                {
                    return data;
                }
                else i++;
            }

            return data;
        }

        private List<string> GetTestData(string email)
        {
            string query = FileHelper.GetSql("GetLearnersData");

            Dictionary<string, string> sqlParameters = new Dictionary<string, string>
            {
                { "@endPointAssessorEmail", email }
            };

            switch (true)
            {
                case bool _ when _tags.Contains("epaoca1standard1version0option") : query = GetTestData(query, true, false, false, false); break;
                case bool _ when _tags.Contains("epaoca1standard1version1option") : query = GetTestData(query, true, false, true, false); break;
                case bool _ when _tags.Contains("epaoca1standard2version0option") : query = GetTestData(query, true, true, false, false); break;
                case bool _ when _tags.Contains("epaoca1standard2version1option") : query = GetTestData(query, true, true, true, false); break;
                case bool _ when _tags.Contains("epaoca2standard1version0option") : query = GetTestData(query, true, false, false, true); break;
                case bool _ when _tags.Contains("epaoca2standard1version1option") : query = GetTestData(query, true, false, true, true); break;
                case bool _ when _tags.Contains("epaoca2standard2version0option") : query = GetTestData(query, true, true, false, true); break;
                case bool _ when _tags.Contains("epaoca2standard2version1option") : query = GetTestData(query, true, true, true, true); break;
            };

            return GetData(query, 4, sqlParameters);
        }

        private string GetTestData(string sqlQueryFromFile, bool isActiveStandard, bool hasMultipleVersions, bool withOptions, bool hasMultiStandards)
        {
            sqlQueryFromFile = Regex.Replace(sqlQueryFromFile, @"__Isactivestandard__", isActiveStandard ? $"{1}" : $"{0}");
            sqlQueryFromFile = Regex.Replace(sqlQueryFromFile, @"__HasVersions__", hasMultipleVersions ? $"{1}" : $"{0}");
            sqlQueryFromFile = Regex.Replace(sqlQueryFromFile, @"__HasOptions__", withOptions ? $"{1}" : $"{0}");
            sqlQueryFromFile = Regex.Replace(sqlQueryFromFile, @"__multistandards__", hasMultiStandards ? $"{2},{3},{4}" : $"{1}");

            return sqlQueryFromFile;
        }
    }
}
