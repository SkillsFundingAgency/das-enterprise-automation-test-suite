using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string AccountId = "accountid";
        private const string ApprenticeshipId = "apprenticeshipid";
        private const string OrganisationName = "organisationname";
        #endregion

        internal static void SetAccountId(this ObjectContext objectContext, long value) => objectContext.Replace(AccountId, value);

        internal static void SetApprenticeshipId(this ObjectContext objectContext, long value) => objectContext.Replace(ApprenticeshipId, value);

        internal static void SetOrganisationName(this ObjectContext objectContext, string value) => objectContext.Set(OrganisationName, value);
    }
}
