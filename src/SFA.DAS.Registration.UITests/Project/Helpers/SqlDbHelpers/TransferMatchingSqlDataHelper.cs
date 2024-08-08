using System.Collections.Generic;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.Registration.UITests.Project.Helpers.SqlDbHelpers
{
    public class TransferMatchingSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : SqlDbHelper(objectContext, dbConfig.TMDbConnectionString)
    {       
        public int GetNumberTransferPledgeApplicationsToReview(string employerAccountId)
        {
            Dictionary<string, string> sqlParameters = new()
            {
                { "@EmployerAccountId", employerAccountId }
            };

            string query = @"select COUNT(app.Id) from [dbo].[Application] app
                                inner join [dbo].[Pledge] pledge
                                on pledge.Id = app.PledgeId
                                where app.Status = 0
                                and pledge.EmployerAccountId = @EmployerAccountId;";

            return (int)GetDataAsObject(query, sqlParameters);
        }

    }
}
