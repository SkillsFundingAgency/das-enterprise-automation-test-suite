using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Login.Service.Project.Helpers
{
    public class LoggedInAccountUser : EasAccountUser { public new string OrganisationName { get; set; } }

    public abstract class LoginUser
    {
        public string Username { get; set; }

        public override string ToString() => $"Username:'{Username}'";
    }

    #region SingleAccountUser

    public abstract class EasAccountUser : LoginUser
    {
        public string OrganisationName => LegalEntities?.FirstOrDefault();

        public List<string> LegalEntities { get; set; }

        public string IdOrUserRef { get; set; }

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

    public class FlexiJobUser : MultipleEasAccountUser { }

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

    #region NonEasAccountUser

    public abstract class NonEasAccountUser : LoginUser
    {
        public string Password { get; set; }

        public override string ToString() => $"{base.ToString()}, Password:'{Password}'";
    }

    public class EPAOStandardApplyUser : NonEasAccountUser { }

    public class EPAOAssessorUser : NonEasAccountUser { }

    public class EPAODeleteAssessorUser : NonEasAccountUser { }

    public class EPAOWithdrawalUser : NonEasAccountUser { }

    public class EPAOManageUser : NonEasAccountUser { }

    public class EPAOApplyUser : NonEasAccountUser
    {
        public string FullName { get; set; }
    }

    public class EPAOStageTwoStandardCancelUser : NonEasAccountUser { }

    public class EPAOE2EApplyUser : NonEasAccountUser { }

    public class EPAOAdminUser : NonEasAccountUser { }

    public class SupportConsoleTier1User : NonEasAccountUser { }

    public class SupportConsoleTier2User : NonEasAccountUser { }

    public class SupportToolsSCPUser : NonEasAccountUser { }

    public class SupportToolsSCSUser : NonEasAccountUser { }

    public abstract class AanBaseUser : NonEasAccountUser { }

    public class AanUser : AanBaseUser { }

    public class AanNonBetaUser : AanBaseUser { }

    #endregion

}