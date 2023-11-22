namespace SFA.DAS.FrameworkHelpers;

public static class ScenarioTagsExtension
{
    public static bool IsRplWhiteListedProvider(this string[] tags) => tags.Contains("rplwhitelistedprovider");

    public static bool IsSelectStandardWithMultipleOptions(this string[] tags) => tags.Contains("selectstandardwithmultipleoptions");

    public static bool IsPortableFlexiJob(this string[] tags) => tags.Contains("portableflexijob");

    public static bool IsAsListedEmployer(this string[] tags) => tags.Contains("aslistedemployer");
}