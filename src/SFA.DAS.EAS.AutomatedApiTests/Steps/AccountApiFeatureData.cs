using SFA.DAS.EAS.AutomatedApiTests.ApiModels;
using SFA.DAS.EAS.AutomatedApiTests.Database;
using System.Collections.Generic;

namespace SFA.DAS.EAS.AutomatedApiTests.Steps
{
    public class AccountApiFeatureData
    {
        public AccountApiFeatureData()
        {
            SeedData = new Seed();
            ApiResponseData = new ApiResponses();
        }

        public Seed SeedData { get; }
        public ApiResponses ApiResponseData { get; }


        public class Seed
        {
            // Seed Properties
            public string HashedAccountId { get; set; }
            public SeedAccount SeedAccount { get; set; }
            public List<SeedAccount> SeededAccounts { get; set; }
        }

        public class ApiResponses
        {
            // Api Response MOdels
            public PagedApiResponseWrapper<AccountWithBalanceViewModel> Accounts { get; internal set; }
            public AccountDetail Account { get; internal set; }
            public List<TeamMember> TeamMembers { get; internal set; }
            public ResourceList PayeSchemesResourceList { get; internal set; }
        }
    }
}
