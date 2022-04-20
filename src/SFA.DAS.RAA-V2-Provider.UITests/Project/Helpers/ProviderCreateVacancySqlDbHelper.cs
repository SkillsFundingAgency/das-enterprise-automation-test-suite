using SFA.DAS.FrameworkHelpers;
using SFA.DAS.ConfigurationBuilder;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Helpers
{
    public class ProviderCreateVacancySqlDbHelper : SqlDbHelper
    {
        public ProviderCreateVacancySqlDbHelper(DbConfig config) : base(config.AccountsDbConnectionString) { }

        public List<object[]> GetValidHashedId(List<string> hashedid)
        {
            string query = $@"select HashedId, count(HashedId) from 
                                (select a.HashedId HashedId, count(a.HashedId) ctr from employer_account.AccountLegalEntity al join employer_account.Account a 
                                on a.id = al.AccountId 
                                GROUP by a.HashedId, al.Deleted, al.SignedAgreementId
                                having al.SignedAgreementId IS NOT NULL AND al.Deleted IS NULL AND a.HashedId in ({hashedid.Select(x => $"'{x}'").ToString(",")}) ) 
                            t GROUP by t.HashedId";

            return GetListOfDataAsObject(query);
        }
    }
}
