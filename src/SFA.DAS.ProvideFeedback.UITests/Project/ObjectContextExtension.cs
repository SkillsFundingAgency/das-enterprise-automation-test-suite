namespace SFA.DAS.ProvideFeedback.UITests.Project;

public static class ObjectContextExtension
{
    #region Constants
    private const string UniqueSurveyCode = "uniquesurveycode";
    private const string ProviderUkprn = "providerukprn";
    #endregion

    internal static void SetTestData(this ObjectContext objectContext, (string , string ) data)
    {
        objectContext.Set(UniqueSurveyCode, data.Item1?.ToUpper());
        objectContext.SetProviderUkprn(data.Item2);
    }

    internal static void SetProviderUkprn(this ObjectContext objectContext, string providerUkprn) => objectContext.Replace(ProviderUkprn, providerUkprn);

    internal static string GetUniqueSurveyCode(this ObjectContext objectContext) => objectContext.Get(UniqueSurveyCode);

    internal static string GetProviderUkprn(this ObjectContext objectContext) => objectContext.Get(ProviderUkprn);
}
