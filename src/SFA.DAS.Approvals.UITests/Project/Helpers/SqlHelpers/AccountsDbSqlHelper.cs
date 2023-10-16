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

        public string GetAgreementId(string email, string name) => ReadDataFromDataBase(FileHelper.GetSql("GetAgreementId"), new Dictionary<string, string> { { "@email", email }, { "@name", name } });

        public string GetAgreementIdByCohortRef(string cohortRef) => ReadDataFromCommtDataBase($"Select PublicHashedId from [AccountLegalEntities] ALE Inner Join Commitment C on C.AccountLegalEntityId = ALE.Id Where C.Reference = '{cohortRef}'");

        public string GetEmployerNameByAgreementId(string agreementId) => ReadDataFromCommtDataBase($"Select Ac.Name from AccountLegalEntities ale inner join Accounts Ac on ale.AccountId = ac.Id where ale.PublicHashedId = '{agreementId}'");

        public string GetIsLevyByAgreementId(string agreementId) => ReadDataFromCommtDataBase($"Select Ac.LevyStatus from AccountLegalEntities ale inner join Accounts Ac on ale.AccountId = ac.Id where ale.PublicHashedId = '{agreementId}'");

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

        private string ReadDataFromDataBase(string queryToExecute, Dictionary<string, string> parameters) => ReadDataFromDataBase(queryToExecute, connectionString, parameters);

        private string ReadDataFromCommtDataBase(string queryToExecute) => ReadDataFromDataBase(queryToExecute, _dbConfig.CommitmentsDbConnectionString, null);

        private string ReadDataFromDataBase(string queryToExecute, string connectionString, Dictionary<string, string> parameters)
        {
            var (data, _) = GetListOfData(queryToExecute, connectionString, parameters);

            if (data.Count == 0)
                return null;
            else
                return data[0][0].ToString();
        }
    }
}
