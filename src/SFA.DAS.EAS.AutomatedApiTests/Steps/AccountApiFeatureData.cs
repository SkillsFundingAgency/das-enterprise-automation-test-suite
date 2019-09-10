using SFA.DAS.EAS.AutomatedApiTests.ApiModels;
using System.Collections.Generic;

namespace SFA.DAS.EAS.AutomatedApiTests.Steps
{
    public class AccountApiFeatureData
    {
        public PagedApiResponseWrapper<AccountWithBalanceViewModel> Accounts { get; internal set; }
        public string HashedAccountId { get; internal set; }
        public AccountDetail Account { get; internal set; }
        public List<TeamMember> TeamMembers { get; internal set; }
        public ResourceList PayeSchemesResourceList { get; internal set; }
    }

    public class AccountSeededData
    {



        //EXECUTE #CreateAccount 1, 'JRML7V', 'LDMVWV', @userId, '00445790', 'Tesco Plc', 'Tesco House, Shire Park, Kestrel Way, Welwyn Garden City, AL7 1GA', '1947-11-27 00:00:00.000', 'active', 1, '222/ZZ00002', 'NA', 'AAA123'

        //EXECUTE #CreateAccount 1, 'JRML7V', 'LDMVWV', @userId, '00445790', 'Tesco Plc', 'Tesco House, Shire Park, Kestrel Way, Welwyn Garden City, AL7 1GA', '1947-11-27 00:00:00.000', 'active', 1, '222/ZZ00002', 'NA', 'AAA123'
        //EXECUTE #CreateAccount 2, '84VBNV', 'BDXBDV', @userId, 'SC171417', 'SAINSBURY''S LIMITED', 'No 2 Lochrin Square, 96 Fountainbridge, Edinburgh, EH3 9QA', '1997-01-16 00:00:00.000', 'active', 1, '123/SFZZ029', 'NA', 'AAA124'
        //EXECUTE #CreateAccount 3, 'JLVKPM', 'XWBVWN', @userId, '07297044', 'DINE CONTRACT CATERING LIMITED', '1st Floor The Centre, Birchwood Park, Warrington, Lancashire, WA3 6YN', '2010-06-28 00:00:00.000', 'active', 1, '101/ZZR00016', 'NA', 'AAA125'

    }
}
