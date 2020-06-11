using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.EPAO.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string ApplyOrganisationName = "applyorganisationname";
        #endregion

        public static void SetApplyOrganisationName(this ObjectContext objectContext, string applyOrganisationName) => objectContext.Replace(ApplyOrganisationName, applyOrganisationName);
        public static string GetApplyOrganisationName(this ObjectContext objectContext) => objectContext.Get(ApplyOrganisationName);
    }
}
