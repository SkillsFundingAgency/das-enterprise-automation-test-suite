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

    public abstract class GovSignUser : LoginUser
    {
        public string IdOrUserRef { get; set; }
    }

    public abstract class NonEasAccountUser : LoginUser
    {
        public string Password { get; set; }

        public override string ToString() => $"{base.ToString()}, Password:'{Password}'";
    }

    public abstract class EasAccountUser : GovSignUser
    {
        public string OrganisationName => LegalEntities?.FirstOrDefault();

        public List<string> LegalEntities { get; set; }
    }

    #region SingleAccountEasUser

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

    public class AanEmployerUser : EasAccountUser { }

    public class AanEmployerOnBoardedUser : EasAccountUser { }

    public class AddMultiplePayeLevyUser : EasAccountUser
    {
        public string NoOfPayeToAdd { get; set; }
    }

    public class DeleteCohortLevyUser : EasAccountUser
    {
        public string NoOfCohortToDelete { get; set; }
    }

    #endregion

    #region MultipleAccountEasUser
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

    #region GovSignUser

    public abstract class EPAOAssessorPortalUser : GovSignUser
    {
        public string FullName { get; set; }
    }

    public class EPAOAssessorPortalLoggedInUser : EPAOAssessorPortalUser { }

    public class EPAOStandardApplyUser : EPAOAssessorPortalUser { }

    public class EPAOAssessorUser : EPAOAssessorPortalUser { }

    public class EPAODeleteAssessorUser : EPAOAssessorPortalUser { }

    public class EPAOWithdrawalUser : EPAOAssessorPortalUser { }

    public class EPAOManageUser : EPAOAssessorPortalUser { }

    public class EPAOApplyUser : EPAOAssessorPortalUser
    {
    }

    public class EPAOStageTwoStandardCancelUser : EPAOAssessorPortalUser { }

    public class EPAOE2EApplyUser : EPAOAssessorPortalUser { }

    #endregion

    #region AanApprenticeUser

    public abstract class AanBaseUser : NonEasAccountUser { }

    public class AanApprenticeUser : AanBaseUser { }

    public class AanApprenticeNonBetaUser : AanBaseUser { }

    public class AanApprenticeOnBoardedUser : AanBaseUser { }

    #endregion

    #endregion

}