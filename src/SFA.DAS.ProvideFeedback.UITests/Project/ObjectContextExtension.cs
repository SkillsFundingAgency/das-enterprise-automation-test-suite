namespace SFA.DAS.ProvideFeedback.UITests.Project;

public static class ObjectContextExtension
{
    #region Constants
    private const string UniqueSurveyCode = "uniquesurveycode";
    private const string ProviderUkprn = "providerukprn";
    #endregion

    public static void SetTestData(this ObjectContext objectContext, (string , string ) data)
    {
        objectContext.Set(UniqueSurveyCode, data.Item1?.ToUpper());
        objectContext.Set(ProviderUkprn, data.Item2);
    }
    public static string GetUniqueSurveyCode(this ObjectContext objectContext) => objectContext.Get(UniqueSurveyCode);

    public static string GetProviderUkprn(this ObjectContext objectContext) => objectContext.Get(ProviderUkprn);
}
