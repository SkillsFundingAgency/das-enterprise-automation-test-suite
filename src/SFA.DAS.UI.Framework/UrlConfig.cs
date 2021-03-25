using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.UI.Framework
{
    public static class UrlConfig
    {
        public static string Admin_BaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-admin.apprenticeships.education.gov.uk/";
        public static string RoATPAssessor_BaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-roatp-assessor.apprenticeships.education.gov.uk/";
        public static string Apply_BaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-apply.apprenticeships.education.gov.uk/";
        public static string CA_BaseUrl => EnvironmentConfig.IsPPEnvironment ? "https://preprod.apprenticeships.gov.uk/" : $"https://{EnvironmentConfig.EnvironmentName}.apprenticeships.gov.uk/";
        public static string EPAOAssessmentService_BaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-assessors.apprenticeships.education.gov.uk";
        public static string EmployerApprenticeshipService_BaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-eas.apprenticeships.education.gov.uk/";
        public static string FAA_BaseUrl => $"https://{(EnvironmentConfig.EnvironmentName).ToLower()}.findapprenticeship.service.gov.uk/";
        public static string FATV2_BaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-findapprenticeshiptraining.apprenticeships.education.gov.uk";
        public static string FAT_BaseUrl => EnvironmentConfig.IsPPEnvironment ? "https://pp-findapprenticeshiptraining-v1.apprenticeships.education.gov.uk/" : $"https://{EnvironmentConfig.EnvironmentName}-fatweb.apprenticeships.education.gov.uk/";
        public static string Mailinator_BaseUrl => "https://www.mailinator.com/";
        public static string Manage_BaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-manageapprenticeship.apprenticeships.education.gov.uk/";
        public static string Provider_BaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-pas.apprenticeships.education.gov.uk/";
        public static string RAAV2QA_BaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-review.apprenticeships.education.gov.uk/";
        public static string Recruit_BaseUrl => $"https://{EnvironmentConfig.EnvironmentName}.recruit-apprentice.service.gov.uk/";
        public static string SupportConsole_BaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-console.apprenticeships.education.gov.uk/";
        public static string SupportTools_BaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-support-tools.apprenticeships.education.gov.uk";
        public static string ProviderFeedback_BaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-feedback.apprenticeships.education.gov.uk/";
        public static string AR_BaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-apprentice-support.apprenticeships.education.gov.uk/";
        public static string AR_AdminBaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-apprentice-support-admin.apprenticeships.education.gov.uk/";
        public static string FindEPAO_BaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-find-epao.apprenticeships.education.gov.uk/";

        public static string EI_VRFUrl => "https://dfeuat.achieveservice.com/forms";
        public static string ConsolidatedSupport_BaseUrl => true switch
        {
            bool _ when EnvironmentConfig.IsTestEnvironment => "https://esfa1567428279.zendesk.com",
            bool _ when EnvironmentConfig.IsPPEnvironment => "https://esfa-preprod.zendesk.com",
            _ => "",
        };
        public static string RoatpApply_InvitationUrl => $"https://{EnvironmentConfig.EnvironmentName}-aslogin.apprenticeships.education.gov.uk/Invitations/CreatePassword/";

        public static string Apprentice_InvitationUrl(string invitationId) => $"https://login.{EnvironmentConfig.EnvironmentName}-aas.apprenticeships.education.gov.uk/Invitations/CreatePassword/{invitationId}";

        public static string Apprentice_ResetPasswordUrl(string clientId, string requestId) => $"https://login.{EnvironmentConfig.EnvironmentName}-aas.apprenticeships.education.gov.uk/NewPassword/{clientId}/{requestId}";

    }
}
