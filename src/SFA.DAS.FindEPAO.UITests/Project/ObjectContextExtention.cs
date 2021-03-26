using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.FindEPAO.UITests.Project
{
    public static class ObjectContextExtention
    {
        #region Constants
        private const string EPAOOrganisationNameKey = "epaoorganisationnameKey";
        #endregion

        public static void SetEPAOOrganisationName(this ObjectContext objectContext, string epaoName) => objectContext.Replace(EPAOOrganisationNameKey, epaoName);

        public static string GetEPAOOrganisationName(this ObjectContext objectContext) => objectContext.Get(EPAOOrganisationNameKey);

    }
}
