using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.RAA_V2.APITests.Project.Helpers.SqlDbHelpers
{
    public class EmployerLegalEntitiesSqlDbHelper : SqlDbHelper
    {
        private readonly DbConfig _dbConfig;

        public EmployerLegalEntitiesSqlDbHelper(DbConfig dbConfig) : base (dbConfig.AccountsDbConnectionString) { _dbConfig = dbConfig; }

        public List<string> GetEmployerAccountLegalEntities (string employerAccountHashedId)
        {
            var query = $"SELECT (" +
                $" SELECT  ale.Address as address, ale.Name as name, ale.PublicHashedId as accountLegalEntityPublicHashedId" +
                $" FROM[employer_account].[AccountLegalEntity] AS ale" +
                $" JOIN[employer_account].[LegalEntity] AS le" +
                $" ON le.Id = ale.LegalEntityId " +
                $" WHERE   ale.AccountId in (select Id from[employer_account].[Account] where HashedId = '{employerAccountHashedId}') " +
                $" and ale.Deleted IS NULL " +
                $" FOR JSON PATH, ROOT('employerAccountLegalEntities') " +
                $" ) AS queryResponse";

            return GetData(query, _dbConfig.AccountsDbConnectionString, 1);
        }
    }
}
