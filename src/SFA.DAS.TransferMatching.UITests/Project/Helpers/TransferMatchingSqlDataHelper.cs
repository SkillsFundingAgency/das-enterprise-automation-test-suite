using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SFA.DAS.TransferMatching.UITests.Project.Helpers
{
    public class TransferMatchingSqlDataHelper : SqlDbHelper
    {
        public TransferMatchingSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig.TMDbConnectionString) { }

        public void DeletePledge(List<Pledge> pledges)
        {
            foreach (var pledge in pledges)
            {
                string sqlQueryFromFile = FileHelper.GetSql("TMTestDataCleanUp");

                sqlQueryFromFile = Regex.Replace(sqlQueryFromFile, @"__EmployerAccountId__", pledge.EmployerAccountId);

                sqlQueryFromFile = Regex.Replace(sqlQueryFromFile, @"__CreatedOn__", pledge.CreatedOn.ToString("dd/MM/yyyy HH:mm:ss"));

                sqlQueryFromFile = Regex.Replace(sqlQueryFromFile, @"__Amount__", pledge.Amount.ToString());

                ExecuteSqlCommand(sqlQueryFromFile);
            }
        }

        public void UpdateCreatedDateForApplicationToToday(string details)
        {
            string sqlQueryFromFile = FileHelper.GetSql("TMUpdateApplicationCreatedDate");

            sqlQueryFromFile = Regex.Replace(sqlQueryFromFile, @"__Details__", details);

            ExecuteSqlCommand(sqlQueryFromFile);
        }
    }
}
