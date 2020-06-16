using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.EPAO.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string ApplyOrganisationName = "applyorganisationname";
        private const string ApplyStandardName = "applystandardname";
        private const string OrganisationIdentifier = "organisationidentifier";
        #endregion

        public static void SetApplyOrganisationName(this ObjectContext objectContext, string value) => objectContext.Replace(ApplyOrganisationName, value);
        public static string GetApplyOrganisationName(this ObjectContext objectContext) => objectContext.Get(ApplyOrganisationName);

        public static void SetApplyStandardName(this ObjectContext objectContext, string value) => objectContext.Replace(ApplyStandardName, value);
        public static string GetApplyStandardName(this ObjectContext objectContext) => objectContext.Get(ApplyStandardName);

        public static void SetOrganisationIdentifier(this ObjectContext objectContext, string value) => objectContext.Replace(OrganisationIdentifier, value);
        public static string GetOrganisationIdentifier(this ObjectContext objectContext) => objectContext.Get(OrganisationIdentifier);
    }
}
