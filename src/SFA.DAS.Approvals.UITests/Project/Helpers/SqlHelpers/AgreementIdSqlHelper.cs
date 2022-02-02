using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers
{
    public class AgreementIdSqlHelper : SqlDbHelper
    {
        DbConfig _dbConfig;
        public AgreementIdSqlHelper(DbConfig dbConfig) : base(dbConfig.AccountsDbConnectionString) { _dbConfig = dbConfig; }
    
        public string GetAgreementId(string email, string name)
        {
            string sqlQueryFromFile = FileHelper.GetSql("GetAgreementId");

            Dictionary<string, string> sqlParameters = new Dictionary<string, string> { { "@email", email }, { "@name", name } };

            var (data, _) = SqlDatabaseConnectionHelper.ReadDataFromDataBase(sqlQueryFromFile, connectionString, sqlParameters);

            if (data.Count == 0)
                return null;
            else
                return data[0][0].ToString();
        }

        public string GetAgreementIdByCohortRef(string cohortRef)
        {
            string sqlQueryFromFile = @$"Select PublicHashedId from [AccountLegalEntities] ALE
            Inner Join Commitment C on C.AccountLegalEntityId = ALE.Id
             Where C.Reference = '{cohortRef}'";

            var data = SqlDatabaseConnectionHelper.ReadDataFromDataBase(sqlQueryFromFile, _dbConfig.CommitmentsDbConnectionString);

            if (data.Count == 0)
                return null;
            else
                return data[0][0].ToString();
        }

        public string GetEmployerNameByAgreementId(string agreementId)
        {
            string sqlQueryFromFile = @$"  Select Ac.Name from AccountLegalEntities ale 
                  inner join Accounts Ac on ale.AccountId = ac.Id
                  where ale.PublicHashedId = '{agreementId}'";

            var data = SqlDatabaseConnectionHelper.ReadDataFromDataBase(sqlQueryFromFile, _dbConfig.CommitmentsDbConnectionString);

            if (data.Count == 0)
                return null;
            else
                return data[0][0].ToString();
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
