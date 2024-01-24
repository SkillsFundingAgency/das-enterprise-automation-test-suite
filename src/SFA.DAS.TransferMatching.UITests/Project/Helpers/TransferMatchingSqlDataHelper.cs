using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SFA.DAS.TransferMatching.UITests.Project.Helpers
{
    public partial class TransferMatchingSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : SqlDbHelper(objectContext, dbConfig.TMDbConnectionString)
    {
        public void DeletePledge(List<Pledge> pledges)
        {
            foreach (var pledge in pledges)
            {
                string sqlQueryFromFile = FileHelper.GetSql("TMTestDataCleanUp");

                sqlQueryFromFile = MyRegex().Replace(sqlQueryFromFile, pledge.EmployerAccountId);

                sqlQueryFromFile = MyRegex1().Replace(sqlQueryFromFile, pledge.CreatedOn.ToString("dd/MM/yyyy HH:mm:ss"));

                sqlQueryFromFile = MyRegex2().Replace(sqlQueryFromFile, pledge.Amount.ToString());

                ExecuteSqlCommand(sqlQueryFromFile);
            }
        }

        public void UpdateCreatedDateForApplicationToToday(string details)
        {
            string sqlQueryFromFile = FileHelper.GetSql("TMUpdateApplicationCreatedDate");

            sqlQueryFromFile = MyRegex3().Replace(sqlQueryFromFile, details);

            ExecuteSqlCommand(sqlQueryFromFile);
        }

        [GeneratedRegex(@"__EmployerAccountId__")]
        private static partial Regex MyRegex();
        [GeneratedRegex(@"__CreatedOn__")]
        private static partial Regex MyRegex1();
        [GeneratedRegex(@"__Amount__")]
        private static partial Regex MyRegex2();
        [GeneratedRegex(@"__Details__")]
        private static partial Regex MyRegex3();
    }
}
