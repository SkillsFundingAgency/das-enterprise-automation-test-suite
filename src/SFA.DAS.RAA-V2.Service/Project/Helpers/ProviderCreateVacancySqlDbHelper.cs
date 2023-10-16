using SFA.DAS.FrameworkHelpers;
using SFA.DAS.ConfigurationBuilder;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.RAA_V2.Service.Project.Helpers
{
    public class RAAV2ProviderPermissionsSqlDbHelper : SqlDbHelper
    {
        public RAAV2ProviderPermissionsSqlDbHelper(ObjectContext objectContext, DbConfig config) : base(objectContext, config.PermissionsDbConnectionString) { }

        public int GetNoOfValidOrganisations(string hashedid)
        {
            string query = $@"SELECT count(AccountLegalEntityId) ctr FROM dbo.AccountProviderLegalEntities apl
                                JOIN AccountLegalEntities al ON al.id = apl.AccountLegalEntityId
                                JOIN Accounts A ON a.Id = al.AccountId
                                WHERE a.HashedId in ('{hashedid}')
                                GROUP by AccountLegalEntityId";

            return (int)GetDataAsObject(query);
        }
    }

    public class ProviderCreateVacancySqlDbHelper : SqlDbHelper
    {
        public ProviderCreateVacancySqlDbHelper(ObjectContext objectContext, DbConfig config) : base(objectContext, config.AccountsDbConnectionString) { }

        public List<object[]> GetValidHashedId(List<string> hashedid)
        {
            string query = $@"SELECT HashedId, count(HashedId) FROM 
                                (SELECT a.HashedId HashedId, count(a.HashedId) ctr from employer_account.AccountLegalEntity al JOIN employer_account.Account a 
                                ON a.id = al.AccountId 
                                GROUP by a.HashedId, al.Deleted, al.SignedAgreementId
                                HAVING al.SignedAgreementId IS NOT NULL AND al.Deleted IS NULL AND a.HashedId in ({hashedid.Select(x => $"'{x}'").ToString(",")}) ) t
                                GROUP by t.HashedId";

            return GetListOfDataAsObject(query);
        }
    }
}
