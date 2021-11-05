using System.Collections.Generic;

namespace SFA.DAS.Login.Service.Project.Helpers
{
    public class LoggedInAccountUser : AccountUser { }

    public abstract class LoginUser
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
    #region SingleAccountUser

    public abstract class AccountUser : LoginUser
    {
        public string OrganisationName { get; set; }

        public List<string> LegalEntities { get; set; }
    }

    public class AuthTestUser : AccountUser { }

    public class RAAV2EmployerUser : AccountUser { }

    public class RAAV2EmployerProviderPermissionUser : AccountUser { }

    public class ProviderPermissionLevyUser : AccountUser { }

    public class AgreementNotSignedTransfersUser : AccountUser { }

    public class LevyUser : AccountUser { }

    public class NonLevyUser : AccountUser { }

    public class EILevyUser : AccountUser { }

    public class EIWithdrawLevyUser : AccountUser { }

    public class TransactorUser : AccountUser { }

    public class ViewOnlyUser : AccountUser { }

    public class Version4AgreementUser : AccountUser { }

    public class Version5AgreementUser : AccountUser { }

    public class Version6AgreementUser : AccountUser { }

    public class ASListedLevyUser : AccountUser { }

    #endregion

    #region MultipleAccountUser
    public abstract class MultipleAccountUser : AccountUser
    {
        public string SecondOrganisationName { get; set; }
    }

    public class EIMultipleAccountUser : MultipleAccountUser { }

    public class TransfersUser : MultipleAccountUser { }

    public class TransfersUserNoFunds : MultipleAccountUser { }

    public class TransferMatchingUser : MultipleAccountUser { }

    public class ChangeOfEmployerLevyUser : MultipleAccountUser { }

    #endregion

    #region NonAccountUser
    public abstract class NonAccountUser : LoginUser { }

    public class EPAOStandardApplyUser : NonAccountUser { }

    public class EPAOAssessorUser : NonAccountUser { }

    public class EPAODeleteAssessorUser : NonAccountUser { }

    public class EPAOWithdrawalUser : NonAccountUser { }

    public class EPAOManageUser : NonAccountUser { }

    public class EPAOApplyUser : NonAccountUser
    {
        public string FullName { get; set; }
    }

    public class EPAOStageTwoStandardCancelUser : NonAccountUser { }

    public class EPAOE2EApplyUser : NonAccountUser { }

    public class EPAOAdminUser : NonAccountUser { }

    public class SupportToolsUser : NonAccountUser { }

    public class SupportConsoleTier1User : NonAccountUser { }

    public class SupportConsoleTier2User : NonAccountUser { }

    #endregion

}