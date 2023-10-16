namespace SFA.DAS.RAA_V2.APITests.Project.Helpers.SqlDbHelpers;

public class EmployerLegalEntitiesSqlDbHelper : SqlDbHelper
{
    public EmployerLegalEntitiesSqlDbHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig.AccountsDbConnectionString) { }

    public (string, string) GetEmployerAccountDetails()
    {
        List<string> queryResult = GetData("select top (1) a.HashedId, '\"accountLegalEntityPublicHashedId\":\"'+ ale.PublicHashedId +'\",\"name\":\"'+ ale.Name + '\"' as expected " +
            "FROM [employer_account].[AccountLegalEntity] AS ale " +
            "JOIN[employer_account].[LegalEntity] AS le " +
            "ON le.Id = ale.LegalEntityId " +
            "JOIN [employer_account].[Account] AS a " +
            "ON a.Id = ale.AccountId " +
            "WHERE ale.Deleted IS NUll " +
            "Order by NEWID();");

        return (queryResult[0], queryResult[1]);
    }
}
