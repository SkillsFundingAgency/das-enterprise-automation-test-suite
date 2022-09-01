using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Login.Service.Project.Helpers
{
    public class LoggedInAccountUser : EasAccountUser { public new string OrganisationName { get; set; } }

    public abstract class LoginUser
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    #region SingleAccountUser

    public abstract class EasAccountUser : LoginUser
    {
        public string OrganisationName => LegalEntities?.FirstOrDefault();

        public List<string> LegalEntities { get; set; }
    }

    public class EmployerFeedbackUser : EasAccountUser { }

    public class AuthTestUser : EasAccountUser { }

    public class RAAV2EmployerUser : EasAccountUser { }

    public class RAAV2EmployerProviderPermissionUser : EasAccountUser { }

    public class ProviderPermissionLevyUser : EasAccountUser { }

    public class AgreementNotSignedTransfersUser : EasAccountUser { }

    public class LevyUser : EasAccountUser { }

    public class NonLevyUser : EasAccountUser { }

    public class EINoApplicationUser : EasAccountUser { }

    public class EIAmendVrfUser : EasAccountUser { }

    public class EIAddVrfUser : EasAccountUser { }

    public class EIWithdrawLevyUser : EasAccountUser { }

    public class TransactorUser : EasAccountUser { }

    public class ViewOnlyUser : EasAccountUser { }

    public class ASListedLevyUser : EasAccountUser { }

    public class FlexiJobUser : EasAccountUser { }

    public class EmployerConnectedToPortableFlexiJobProvider : EasAccountUser { }

    #endregion

    #region MultipleAccountUser
    public abstract class MultipleEasAccountUser : EasAccountUser
    {
        public string SecondOrganisationName => LegalEntities?.ElementAtOrDefault(1);
    }

    public class TransfersUser : MultipleEasAccountUser { }

    public class TransfersUserNoFunds : MultipleEasAccountUser { }

    public class TransferMatchingUser : MultipleEasAccountUser { }

    public class EmployerWithMultipleAccountsUser : MultipleEasAccountUser
    {
        public string ThirdOrganisationName => LegalEntities?.ElementAtOrDefault(2);
    }

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