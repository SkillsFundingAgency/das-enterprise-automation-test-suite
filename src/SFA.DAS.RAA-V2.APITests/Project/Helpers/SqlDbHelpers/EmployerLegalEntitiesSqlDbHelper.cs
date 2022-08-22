namespace SFA.DAS.RAA_V2.APITests.Project.Helpers.SqlDbHelpers;

public class EmployerLegalEntitiesSqlDbHelper : SqlDbHelper
{
    public EmployerLegalEntitiesSqlDbHelper(DbConfig dbConfig) : base(dbConfig.AccountsDbConnectionString) { }

    public string GetEmployerAccountLegalEntities(string employerAccountHashedId)
    {
        List<string> queryResult = GetData($"SELECT (" +
            $" SELECT  ale.Address as address, ale.Name as name, ale.PublicHashedId as accountLegalEntityPublicHashedId" +
            $" FROM[employer_account].[AccountLegalEntity] AS ale" +
            $" JOIN[employer_account].[LegalEntity] AS le" +
            $" ON le.Id = ale.LegalEntityId " +
            $" WHERE ale.AccountId in (select Id from[employer_account].[Account] where HashedId = '{employerAccountHashedId}') " +
            $" and ale.Deleted IS NULL " +
            $" FOR JSON PATH, ROOT('employerAccountLegalEntities') " +
            $" ) AS queryResponse");

        return queryResult[0];
    }

    public string GetEmployerAccountHashedID()
    {
        List<string> queryResult = GetData(" select top (1) a.HashedId FROM [employer_account].[AccountLegalEntity] AS ale " +
            " JOIN[employer_account].[LegalEntity] AS le ON le.Id = ale.LegalEntityId " +
            " JOIN[employer_account].[Account] AS a ON a.Id = ale.AccountId " +
            " Order by NEWID()");

        return queryResult[0];
    }
}
