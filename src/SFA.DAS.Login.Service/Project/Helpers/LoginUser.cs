using System.Collections.Generic;

namespace SFA.DAS.Login.Service.Project.Helpers
{
    public class LoggedInAccountUser : EasAccountUser { }

    public abstract class LoginUser
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
    #region SingleAccountUser

    public abstract class EasAccountUser : LoginUser
    {
        public string OrganisationName { get; set; }

        public List<string> LegalEntities { get; set; }
    }

    public class AuthTestUser : EasAccountUser { }

    public class RAAV2EmployerUser : EasAccountUser { }

    public class RAAV2EmployerProviderPermissionUser : EasAccountUser { }

    public class ProviderPermissionLevyUser : EasAccountUser { }

    public class AgreementNotSignedTransfersUser : EasAccountUser { }

    public class LevyUser : EasAccountUser { }

    public class NonLevyUser : EasAccountUser { }

    public class EINonLevyUnsignedUser : EasAccountUser { }

    public class EILevyUser : EasAccountUser { }

    public class EIWithdrawLevyUser : EasAccountUser { }

    public class TransactorUser : EasAccountUser { }

    public class ViewOnlyUser : EasAccountUser { }

    public class Version4AgreementUser : EasAccountUser { }

    public class Version5AgreementUser : EasAccountUser { }

    public class Version6AgreementUser : EasAccountUser { }

    public class ASListedLevyUser : EasAccountUser { }

    #endregion

    #region MultipleAccountUser
    public abstract class MultipleEasAccountUser : EasAccountUser
    {
        public string SecondOrganisationName { get; set; }
    }

    public class EIMultipleAccountUser : MultipleEasAccountUser { }

    public class TransfersUser : MultipleEasAccountUser { }

    public class TransfersUserNoFunds : MultipleEasAccountUser { }

    public class TransferMatchingUser : MultipleEasAccountUser { }

    public class ChangeOfEmployerLevyUser : MultipleEasAccountUser { }

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