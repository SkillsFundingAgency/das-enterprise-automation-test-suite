namespace SFA.DAS.Login.Service.Helpers
{
    public abstract class LoginUser
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class CampaingnsEmployerUser : LoginUser { }

    public class RAAV2EmployerUser : LoginUser { }

    public class ProviderLoginUser : LoginUser
    {
        public string Ukprn { get; set; }
    }

    public class ProviderPermissionLevyUser : LoginUser { }

    public class AgreementNotSignedTransfersUser : LoginUser { }

    public class TransfersUser : LoginUser { }

    public class LevyUser : LoginUser { }

    public class NonLevyUser : LoginUser { }

    public class LoggedInUser : LoginUser { }
    
    public class EPAOStandardApplyUser : LoginUser { }

    public class EPAOAssessorUser : LoginUser { }

    public class EPAODeleteAssessorUser : LoginUser { }

    public class EPAOWithdrawalUser : LoggedInUser { }

    public class EPAOManageUser : LoginUser { }

    public class EPAOApplyUser : LoginUser
    {
        public string FullName { get; set; }
    }

    public class EPAOStageTwoStandardCancelUser : LoginUser { }

    public class EPAOE2EApplyUser : LoginUser { }

    public class EPAOAdminUser : LoginUser { }

    public class SupportConsoleTier1User : LoginUser { }

    public class SupportConsoleTier2User : LoginUser { }

    public class SupportToolsUser : LoginUser { }

    public class EILevyUser : LoginUser { }

    public class TransactorUser : LoginUser { }

    public class ViewOnlyUser : LoginUser { }

    public class MultipleAccountUser : LoginUser
    {
        public string SecondOrganisationName { get; set; }
    }

    public class ProviderViewOnlyUser : LoginUser { }

    public class ProviderContributorUser : LoginUser { }

    public class ProviderContributorWithApprovalUser : LoginUser { }

    public class ProviderAccountOwnerUser : LoginUser { }

    public class LoginUserWithSpecificOrg : LoginUser
    {
        public string OrganisationName { get; set; }
    }

    public class Version4AgreementUser : LoginUserWithSpecificOrg { }

    public class Version5AgreementUser : LoginUserWithSpecificOrg { }
}