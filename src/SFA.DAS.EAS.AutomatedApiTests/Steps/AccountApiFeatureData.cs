using SFA.DAS.EAS.AutomatedApiTests.Models;
using System.Collections.Generic;

namespace SFA.DAS.EAS.AutomatedApiTests.Steps
{
    public class AccountApiFeatureData
    {
        public PagedApiResponseWrapper<AccountWithBalanceViewModel> Accounts { get; internal set; }
        public string HashedAccountId { get; internal set; }
        public AccountDetail Account { get; internal set; }
        public List<TeamMember> TeamMembers { get; internal set; }
    }
}
