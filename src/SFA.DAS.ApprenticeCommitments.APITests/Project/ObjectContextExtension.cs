using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string AccountIdKey = "accountid";
        private const string ApprenticeshipIdKey = "apprenticeshipid";
        private const string OrganisationNameKey = "organisationname";
        private const string EmailKey = "emailkey";
        #endregion

        internal static void SetAccountId(this ObjectContext objectContext, long value) => objectContext.Replace(AccountIdKey, value);

        internal static void SetApprenticeshipId(this ObjectContext objectContext, long value) => objectContext.Replace(ApprenticeshipIdKey, value);

        internal static void SetOrganisationName(this ObjectContext objectContext, string value) => objectContext.Set(OrganisationNameKey, value);

        internal static void SetEmail(this ObjectContext objectContext, string value) => objectContext.Set(EmailKey, value);
    }
}
