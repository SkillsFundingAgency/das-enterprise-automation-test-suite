using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers
{
    public class AgreementIdSqlHelper : SqlDbHelper
    {
        public AgreementIdSqlHelper(DbConfig dbConfig) : base(dbConfig.AccountsDbConnectionString) { }
    
        public string GetAgreementId(string email, string name)
        {
            string sqlQueryFromFile = FileHelper.GetSql("GetAgreementId");

            Dictionary<string, string> sqlParameters = new Dictionary<string, string> { { "@email", email }, { "@name", name } };

            List<object[]> responseData = SqlDatabaseConnectionHelper.ReadDataFromDataBase(sqlQueryFromFile, connectionString, sqlParameters);

            if (responseData.Count == 0)
                return null;
            else
                return responseData[0][0].ToString();
        }
    }
}
