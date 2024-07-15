namespace SFA.DAS.FrameworkHelpers;

public static class ScenarioTagsExtension
{
    public static bool IsTestDataDeleteCohortViaProviderPortal(this string[] tags) => tags.Contains("deletecohortviaproviderportal");

    public static bool IsTestDataDeleteCohortViaEmployerPortal(this string[] tags) => tags.Contains("deletecohortviaemployerportal");

    public static bool IsAddRplDetails(this string[] tags) => tags.Contains("addrpldetails");

    public static bool IsSelectStandardWithMultipleOptions(this string[] tags) => tags.Contains("selectstandardwithmultipleoptions");

    public static bool IsSelectStandardWithMultipleOptionsAndVersions(this string[] tags)
    {
        if (tags == null) return false;
        return tags.Contains("selectstandardwithmultipleoptionsandversions");
    }

    public static bool IsPortableFlexiJob(this string[] tags) => tags.Contains("portableflexijob");

    public static bool IsAsListedEmployer(this string[] tags) => tags.Contains("aslistedemployer");
}