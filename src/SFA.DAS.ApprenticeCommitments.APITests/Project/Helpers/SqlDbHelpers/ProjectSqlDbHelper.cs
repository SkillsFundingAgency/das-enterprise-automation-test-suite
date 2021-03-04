using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers
{
    public static class ProjectSqlDbHelper
    {
        public static (string item1, string item2) ReadDataFromDatabase(string query, string connectionString)
        {
            List<object[]> apprenticeData = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, connectionString);

            if (apprenticeData.Count == 0) return (string.Empty, string.Empty);
            else
            {
                var item1 = apprenticeData[0][0].ToString();

                var item2 = apprenticeData[0][1].ToString();

                return (item1, item2);
            }
        }
    }
}
