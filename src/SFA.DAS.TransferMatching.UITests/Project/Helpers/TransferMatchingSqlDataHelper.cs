using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

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

        public void UpdateCreatedDateForApplicationTo3MonthsAgo(string details)
        {
            string sqlQueryFromFile = FileHelper.GetSql("TMUpdateApplicationCreatedDate3MonthsAgo");

            sqlQueryFromFile = MyRegex3().Replace(sqlQueryFromFile, details);

            ExecuteSqlCommand(sqlQueryFromFile);
        }

        public (int status, int remainingAmount) GetPledgeDetails(string details)
        {
            waitForResults = true;

            Dictionary<string, string> sqlParameters = new()
            {
                { "@DETAILS", details }
            };

            string query = @"SELECT 
                            TOP (1) pl.[Status], pl.[RemainingAmount]
                                FROM
                            [dbo].[Application] app   
                            inner join [dbo].[Pledge] pl
                            on pl.Id = app.PledgeId                    
                            Where app.Details =  @DETAILS;";

            var data = GetData(query, sqlParameters);


            return (Convert.ToInt32(data[0]), Convert.ToInt32(data[1]));
        }

        public int GetPledgeApplicationStatusByDetails(string details)
        {
            waitForResults = true;

            Dictionary<string, string> sqlParameters = new()
            {
                { "@DETAILS", details }
            };

            string query = @"SELECT TOP (1) Status
                            FROM
                           [dbo].[Application]                       
                         Where Details = @DETAILS;";

            var data = GetData(query, sqlParameters);

            return Convert.ToInt32(data[0]);
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
