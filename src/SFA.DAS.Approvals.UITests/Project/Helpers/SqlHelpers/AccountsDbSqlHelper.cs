using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers
{
    public class AccountsDbSqlHelper : SqlDbHelper
    {
        private readonly DbConfig _dbConfig;

        public AccountsDbSqlHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig.AccountsDbConnectionString) { _dbConfig = dbConfig; }

        public string GetAgreementId(string email, string name) => ReadDataFromDataBase(FileHelper.GetSql("GetAgreementId"), connectionString, new Dictionary<string, string> { { "@email", email }, { "@name", name } });

        public string GetAgreementIdByCohortRef(string cohortRef) => ReadDataFromDataBase($"Select PublicHashedId from [AccountLegalEntities] ALE Inner Join Commitment C on C.AccountLegalEntityId = ALE.Id Where C.Reference = '{cohortRef}'", _dbConfig.CommitmentsDbConnectionString, null);

        public string GetEmployerNameByAgreementId(string agreementId) => ReadDataFromDataBase($"Select Ac.Name from AccountLegalEntities ale inner join Accounts Ac on ale.AccountId = ac.Id where ale.PublicHashedId = '{agreementId}'", _dbConfig.CommitmentsDbConnectionString, null);

        public string GetIsLevyByAgreementId(string agreementId) => ReadDataFromDataBase($"Select Ac.LevyStatus from AccountLegalEntities ale inner join Accounts Ac on ale.AccountId = ac.Id where ale.PublicHashedId = '{agreementId}'", _dbConfig.CommitmentsDbConnectionString, null);

        public int GetEmployerAccountId(string email, string organisationName)
        {
            string query = @$"SELECT TOP 1 acc.Id FROM[employer_account].[Membership] msp 
                                INNER JOIN[employer_account].[User] usr
                                ON msp.UserId = usr.Id
                                INNER JOIN[employer_account].[Account] acc
                                ON acc.Id = msp.AccountId
                                WHERE usr.Email = '{email}'
                                AND Name Like '{organisationName}%'";

            return Convert.ToInt32(GetDataAsObject(query));
        }

        private string ReadDataFromDataBase(string queryToExecute, string connectionString, Dictionary<string, string> parameters)
        {
            var (data, _) = SqlDatabaseConnectionHelper.ReadDataFromDataBase(queryToExecute, connectionString, parameters, waitForResults);

            if (data.Count == 0)
                return null;
            else
                return data[0][0].ToString();
        }
    }
}
