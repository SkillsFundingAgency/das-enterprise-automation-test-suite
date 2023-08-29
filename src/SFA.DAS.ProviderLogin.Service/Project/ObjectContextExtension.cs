using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.ProviderLogin.Service.Project;

internal static class ObjectContextExtension
{
    #region Constants
    private const string Ukprn = "ukprn";
    #endregion

    internal static void SetUkprn(this ObjectContext objectContext, string value) => objectContext.Replace(Ukprn, value);

    internal static string GetUkprn(this ObjectContext objectContext) => objectContext.Get(Ukprn);
}
