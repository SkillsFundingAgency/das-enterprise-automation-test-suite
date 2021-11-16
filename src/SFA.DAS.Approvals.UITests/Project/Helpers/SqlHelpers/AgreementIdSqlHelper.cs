using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System;
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

            var responseData = SqlDatabaseConnectionHelper.ReadDataFromDataBase(sqlQueryFromFile, connectionString, sqlParameters);

            if (responseData.data.Count == 0)
                return null;
            else
                return responseData.data[0][0].ToString();
        }

        public int GetEmployerAccountId(string email, string organisationName)
        {
            string query = @$"SELECT TOP 1 acc.Id
                                FROM[employer_account].[Membership] msp
                                INNER JOIN[employer_account].[User] usr
                                ON msp.UserId = usr.Id
                                INNER JOIN[employer_account].[Account] acc
                                ON acc.Id = msp.AccountId
                                WHERE usr.Email = '{email}'
                                AND Name Like '{organisationName}%'";

            return Convert.ToInt32(GetDataAsObject(query));
        }
    }
}
