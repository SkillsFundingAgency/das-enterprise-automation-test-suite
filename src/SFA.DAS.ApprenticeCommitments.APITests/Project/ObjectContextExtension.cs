using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string AccountIdKey = "accountid";
        private const string ApprenticeshipIdKey = "apprenticeshipid";
        private const string OrganisationNameKey = "organisationname";
        private const string FirstNameKey = "firstname";
        private const string LastNameKey = "lastname";
        private const string TrainingNameKey = "trainingname";
        private const string EmailKey = "emailkey";
        #endregion

        internal static void SetAccountId(this ObjectContext objectContext, long value) => objectContext.Replace(AccountIdKey, value);
        internal static void SetApprenticeshipId(this ObjectContext objectContext, long value) => objectContext.Replace(ApprenticeshipIdKey, value);
        internal static void SetOrganisationName(this ObjectContext objectContext, string value) => objectContext.Replace(OrganisationNameKey, value);
        internal static void SetFirstName(this ObjectContext objectContext, string value) => objectContext.Replace(FirstNameKey, value);
        internal static void SetLastName(this ObjectContext objectContext, string value) => objectContext.Replace(LastNameKey, value);
        internal static void SetTrainingName(this ObjectContext objectContext, string value) => objectContext.Replace(TrainingNameKey, value);
        internal static void SetApprenticeEmail(this ObjectContext objectContext, string value) => objectContext.Replace(EmailKey, value);
        public static string GetApprenticeEmail(this ObjectContext objectContext) => objectContext.Get(EmailKey);
        internal static string GetFirstName(this ObjectContext objectContext) => objectContext.Get(FirstNameKey);
        internal static string GetLastName(this ObjectContext objectContext) => objectContext.Get(LastNameKey);
        internal static long GetApprenticeshipId(this ObjectContext objectContext) => objectContext.Get<long>(ApprenticeshipIdKey);
    }
}
