using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.EsfaAdmin.Service.Project;

public static class ObjectContextExtension
{
    #region Constants
    private const string ProviderNameKey = "providernamekey";
    private const string OrganisationTypeKey = "organisationtypekey";
    private const string UkprnKey = "ukprnkey";
    #endregion

    public static void SetProviderName(this ObjectContext objectContext, string providername) => objectContext.Replace(ProviderNameKey, providername);
    public static void UpdateOrganisationType(this ObjectContext objectContext, string organisationType) => objectContext.Replace(OrganisationTypeKey, organisationType);
    public static void SetUkprn(this ObjectContext objectContext, string Ukprn) => objectContext.Replace(UkprnKey, Ukprn);

    public static string GetProviderName(this ObjectContext objectContext) => objectContext.Get(ProviderNameKey);
    public static string GetOrganisationType(this ObjectContext objectContext) => objectContext.Get(OrganisationTypeKey);
    public static string GetUkprn(this ObjectContext objectContext) => objectContext.Get(UkprnKey);
}
