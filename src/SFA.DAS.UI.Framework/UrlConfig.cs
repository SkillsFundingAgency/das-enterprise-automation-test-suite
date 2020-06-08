namespace SFA.DAS.UI.Framework
{
    public static class UrlConfig
    {
        public static string AdminBaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-admin.apprenticeships.education.gov.uk/";
        public static string ApplyBaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-apply.apprenticeships.education.gov.uk/";
        public static string CABaseURL => EnvironmentConfig.IsPPEnvironment ? "https://preprod.apprenticeships.gov.uk/" : $"https://{EnvironmentConfig.EnvironmentName}.apprenticeships.gov.uk/";
        public static string EPAOAssessmentServiceUrl => $"https://{EnvironmentConfig.EnvironmentName}-assessors.apprenticeships.education.gov.uk";
        public static string EmployerApprenticeshipServiceBaseURL => $"https://{EnvironmentConfig.EnvironmentName}-eas.apprenticeships.education.gov.uk/";
        public static string FAABaseUrl => $"https://{EnvironmentConfig.EnvironmentName}.findapprenticeship.service.gov.uk/";
        public static string FATUrl => EnvironmentConfig.IsTestEnvironment ? "https://test-fatweb.apprenticeships.education.gov.uk/" : $"https://{EnvironmentConfig.EnvironmentName}-findapprenticeshiptraining.apprenticeships.education.gov.uk";
        public static string MailinatorURL => "https://www.mailinator.com/";
        public static string ManageBaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-manageapprenticeship.apprenticeships.education.gov.uk/";
        public static string ProviderBaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-pas.apprenticeships.education.gov.uk/";
        public static string RAAV2QABaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-review.apprenticeships.education.gov.uk/";
        public static string RecruitBaseUrl => $"https://{EnvironmentConfig.EnvironmentName}.recruit-apprentice.service.gov.uk/";
        public static string SupportConsoleUrl => $"https://{EnvironmentConfig.EnvironmentName}-console.apprenticeships.education.gov.uk/";
        public static string ProviderFeedbackUrl => $"https://{EnvironmentConfig.EnvironmentName}-feedback.apprenticeships.education.gov.uk/";
    }
}
