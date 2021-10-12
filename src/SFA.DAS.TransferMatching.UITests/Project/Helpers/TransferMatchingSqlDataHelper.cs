using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SFA.DAS.TransferMatching.UITests.Project.Helpers
{
    public class TransferMatchingSqlDataHelper : SqlDbHelper
    {
        public TransferMatchingSqlDataHelper(DbConfig dbConfig) : base(dbConfig.TMDbConnectionString) { }

        public void DeletePledge(List<Pledge> pledges)
        {
            foreach (var pledge in pledges)
            {
                string sqlQueryFromFile = FileHelper.GetSql("TMTestDataCleanUp");

                sqlQueryFromFile = Regex.Replace(sqlQueryFromFile, @"__EmployerAccountId__", pledge.EmployerAccountId);

                var sqlparams = new Dictionary<string, string> { { "@amount", pledge.Amount.ToString() }, { "@createdon", pledge.CreatedOn.ToString("dd/MM/yyyy HH:mm:ss") } };

                ExecuteSqlCommand(sqlQueryFromFile, connectionString, sqlparams);
            }
        }
    }
}
