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

        public override string ToString() => $"{base.ToString()}, IdOrUserRef:'{IdOrUserRef}'";
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

    public class RAAEmployerUser : EasAccountUser { }

    public class RAAEmployerProviderPermissionUser : EasAccountUser { }

    public class ProviderPermissionLevyUser : EasAccountUser { }

    public class AgreementNotSignedTransfersUser : EasAccountUser { }

    public class LevyUser : EasAccountUser { }

    public class NonLevyUser : EasAccountUser { }

    public class NonLevyUserAtMaxReservationLimit : EasAccountUser { }

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

    public abstract class RatEmployerBaseUser : EasAccountUser { }

    public class RatEmployerUser : RatEmployerBaseUser { }

    public class RatMultiEmployerUser : RatEmployerBaseUser { }

    public class RatCancelEmployerUser : RatEmployerBaseUser { }

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

    public class AanEmployerOnBoardedUser : MultipleEasAccountUser { }

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

    #region FAAUser

    public abstract class FAAPortalUser : GovSignUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MobilePhone { get; set; }
    }

    public class FAAApplyUser : FAAPortalUser
    {

    }

    #region ApprenticeAccount

    public class CocApprenticeUser : ApprenticeUser { }

    public class ApprenticeFeedbackUser : ApprenticeUser { }

    public abstract class ApprenticeUser : GovSignUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Id { get; set; }
    }

    public abstract class AanBaseUser : ApprenticeUser { }

    public class AanApprenticeUser : AanBaseUser { }

    public class AanApprenticeNonBetaUser : AanBaseUser { }

    public class AanApprenticeOnBoardedUser : AanBaseUser { }

    #endregion

    #endregion

    #region EmployerProviderRelationshipUser

    public abstract class EPRBaseUser : EasAccountUser { }

    public class EPRLevyUser : EPRBaseUser { }
    
    public class EPRNonLevyUser : EPRBaseUser { }

    public class EPRAcceptRequestUser : EPRBaseUser { }

    public class EPRDeclineRequestUser : EPRBaseUser { }

    public class EPRMultiOrgUser : EPRBaseUser { }

    public class EPRMultiAccountUser : MultipleEasAccountUser { }

    #endregion

    #endregion

}