namespace SFA.DAS.UI.Framework
{
    public class UrlConfig
    {
        public string AdminBaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-admin.apprenticeships.education.gov.uk/";
        public string ApplyBaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-apply.apprenticeships.education.gov.uk/";
        public string CABaseURL => $"https://{EnvironmentConfig.EnvironmentName}.apprenticeships.gov.uk/";
        public string EPAOAssessmentServiceUrl => $"https://{EnvironmentConfig.EnvironmentName}-assessors.apprenticeships.education.gov.uk";
        public string EmployerApprenticeshipServiceBaseURL => $"https://{EnvironmentConfig.EnvironmentName}-eas.apprenticeships.education.gov.uk/";
        public string FAABaseUrl => $"https://{EnvironmentConfig.EnvironmentName}.findapprenticeship.service.gov.uk/";
        public string FATUrl => EnvironmentConfig.IsTestEnvironment ? "https ://test-fatweb.apprenticeships.education.gov.uk/" : $"https://{EnvironmentConfig.EnvironmentName}-findapprenticeshiptraining.apprenticeships.education.gov.uk";
        public string MailinatorURL => "https://www.mailinator.com/";
        public string ManageBaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-manageapprenticeship.apprenticeships.education.gov.uk/";
        public string ProviderBaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-pas.apprenticeships.education.gov.uk/";
        public string RAAV2QABaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-review.apprenticeships.education.gov.uk/";
        public string RecruitBaseUrl => $"https://{EnvironmentConfig.EnvironmentName}.recruit-apprentice.service.gov.uk/";
        public string SupportConsoleUrl => $"https://{EnvironmentConfig.EnvironmentName}-console.apprenticeships.education.gov.uk/";
    }
}
