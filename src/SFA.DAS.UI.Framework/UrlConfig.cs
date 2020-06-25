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
        public static string FAT_BaseUrl => EnvironmentConfig.IsTestEnvironment ? "https://test-fatweb.apprenticeships.education.gov.uk/" : $"https://{EnvironmentConfig.EnvironmentName}-findapprenticeshiptraining.apprenticeships.education.gov.uk";
        public static string Mailinator_BaseUrl => "https://www.mailinator.com/";
        public static string Manage_BaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-manageapprenticeship.apprenticeships.education.gov.uk/";
        public static string Provider_BaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-pas.apprenticeships.education.gov.uk/";
        public static string RAAV2QA_BaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-review.apprenticeships.education.gov.uk/";
        public static string Recruit_BaseUrl => $"https://{EnvironmentConfig.EnvironmentName}.recruit-apprentice.service.gov.uk/";
        public static string SupportConsole_BaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-console.apprenticeships.education.gov.uk/";
        public static string ProviderFeedback_BaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-feedback.apprenticeships.education.gov.uk/";
        public static string AR_BaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-as-apprentice-support.apprenticeships.education.gov.uk/";
    }
}
