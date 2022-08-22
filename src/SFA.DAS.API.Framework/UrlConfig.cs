namespace SFA.DAS.API.Framework;

public static class UrlConfig
{
    public static string Outer_ApiBaseUrl => GetOuter_ApiBaseUrl($"{EnvironmentConfig.EnvironmentName}-gateway");

    public static string Outer_RAAV2ApiBaseUrl => EnvironmentConfig.IsPPEnvironment ? GetOuter_ApiBaseUrl("pp-api") : Outer_ApiBaseUrl;

    public static string Outer_ApprenticeCommitmentsHealthBaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-apim-acomt-api.apprenticeships.education.gov.uk";

    public static string Inner_CommitmentsApiBaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-commitments-api.apprenticeships.education.gov.uk/";

    public static string Inner_CoursesApiBaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-courses-api.apprenticeships.education.gov.uk/";

    public static string MangeIdentitybaseUrl(string tenant) => $"https://login.microsoftonline.com/{tenant}/oauth2/token/";

    public static string Outer_AssessorCertificationApiBaseUrl => $"https://test-apis.apprenticeships.education.gov.uk/";

    public static string ApprenticeCommitmentsJobs_BaseUrl => $"https://das-{EnvironmentConfig.EnvironmentName}-acomtwkr-fa.azurewebsites.net/";

    private static string GetOuter_ApiBaseUrl(string envname) => $"https://{envname}.apprenticeships.education.gov.uk/";
}
