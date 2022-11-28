namespace SFA.DAS.API.Framework;

public static class UrlConfig
{
    public static class OuterApiUrlConfig
    {
        public static string Outer_ApiBaseUrl => GetOuter_ApiBaseUrl($"{EnvironmentConfig.EnvironmentName}-gateway");

        public static string Outer_RAAV2ApiBaseUrl => EnvironmentConfig.IsPPEnvironment ? GetOuter_ApiBaseUrl("pp-api") : Outer_ApiBaseUrl;

        public static string Outer_ApprenticeCommitmentsHealthBaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-apim-acomt-api.apprenticeships.education.gov.uk";
        
        public static string Outer_EmployerFinanceHealthBaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-apim-empfin-api.apprenticeships.education.gov.uk";

        public static string Outer_AssessorCertificationApiBaseUrl => $"https://test-apis.apprenticeships.education.gov.uk/";

        private static string GetOuter_ApiBaseUrl(string envname) => $"https://{envname}.apprenticeships.education.gov.uk/";
    }

    public static class InnerApiUrlConfig
    {
        public static string Inner_ApprenticeAccountsApiBaseUrl => GetInner_ApiBaseUrl("apprentice-accounts");

        public static string Inner_CommitmentsApiBaseUrl => GetInner_ApiBaseUrl("commitments");

        public static string Inner_CoursesApiBaseUrl => GetInner_ApiBaseUrl("courses");

        public static string Inner_EmployerFinanceApiBaseUrl => GetInner_ApiBaseUrl("finance");

        public static string Inner_EmployerAccountsApiBaseUrl => GetInner_ApiBaseUrl("accounts");

        public static string Inner_EmployerAccountsLegacyApiBaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-accounts.apprenticeships.education.gov.uk/";

        public static string MangeIdentitybaseUrl(string tenant) => $"{UriHelper.GetAbsoluteUri(MicrosoftIdentityUri,$"{tenant}/oauth2/token/")}";

        public static string ApprenticeCommitmentsJobs_BaseUrl => $"https://das-{EnvironmentConfig.EnvironmentName}-acomtwkr-fa.azurewebsites.net/";

        private static string GetInner_ApiBaseUrl(string apiname) => $"https://{EnvironmentConfig.EnvironmentName}-{apiname}-api.apprenticeships.education.gov.uk/";
        

        private static string MicrosoftIdentityUri => "https://login.microsoftonline.com/";

    }
}
