using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string AccountIdKey = "accountid";
        private const string CommitmentsApprenticeshipIdKey = "commitmentsapprenticeshipid";
        private const string ApprenticeIdKey = "apprenticeid";
        private const string OrganisationNameKey = "organisationname";
        private const string FirstNameKey = "firstname";
        private const string LastNameKey = "lastname";
        private const string TrainingNameKey = "trainingname";
        private const string EmployerAccountLegalEntityIdKey = "employeraccountlegalentityid";
        private const string EmailKey = "emailkey";
        private const string ProviderNameKey = "providername";
        private const string EmployerNameKey = "employername";
        private const string TrainingStartDateKey = "trainingstartdate";
        private const string TrainingEndDateKey = "trainingenddate";
        #endregion

        internal static void SetAccountId(this ObjectContext objectContext, long value) => objectContext.Replace(AccountIdKey, value);
        internal static void SetCommitmentsApprenticeshipId(this ObjectContext objectContext, long value) => objectContext.Replace(CommitmentsApprenticeshipIdKey, value);
        internal static void SetApprenticeId(this ObjectContext objectContext, string value) => objectContext.Replace(ApprenticeIdKey, value);
        internal static void SetOrganisationName(this ObjectContext objectContext, string value) => objectContext.Replace(OrganisationNameKey, value);
        internal static void SetFirstName(this ObjectContext objectContext, string value) => objectContext.Replace(FirstNameKey, value);
        internal static void SetLastName(this ObjectContext objectContext, string value) => objectContext.Replace(LastNameKey, value);
        internal static void SetTrainingName(this ObjectContext objectContext, string value) => objectContext.Replace(TrainingNameKey, value);
        internal static void SetEmployerAccountLegalEntityId(this ObjectContext objectContext, long value) => objectContext.Replace(EmployerAccountLegalEntityIdKey, value);
        internal static void SetApprenticeEmail(this ObjectContext objectContext, string value) => objectContext.Set(EmailKey, value);
        internal static void SetProviderName(this ObjectContext objectContext, string value) => objectContext.Replace(ProviderNameKey, value);
        internal static void SetEmployerName(this ObjectContext objectContext, string value) => objectContext.Replace(EmployerNameKey, value);
        internal static void SetTrainingStartDate(this ObjectContext objectContext, string value) => objectContext.Replace(TrainingStartDateKey, value);
        internal static void SetTrainingEndDate(this ObjectContext objectContext, string value) => objectContext.Replace(TrainingEndDateKey, value);
        public static string GetApprenticeEmail(this ObjectContext objectContext) => objectContext.Get(EmailKey);
        internal static string GetFirstName(this ObjectContext objectContext) => objectContext.Get(FirstNameKey);
        internal static string GetLastName(this ObjectContext objectContext) => objectContext.Get(LastNameKey);
        internal static long GetCommitmentsApprenticeshipId(this ObjectContext objectContext) => objectContext.Get<long>(CommitmentsApprenticeshipIdKey);
        internal static string GetApprenticeId(this ObjectContext objectContext) => objectContext.Get(ApprenticeIdKey);
        public static string GetProviderName(this ObjectContext objectContext) => objectContext.Get(ProviderNameKey);
        public static string GetEmployerName(this ObjectContext objectContext) => objectContext.Get(EmployerNameKey);
        public static string GetTrainingStartDate(this ObjectContext objectContext) => objectContext.Get(TrainingStartDateKey);
        public static string GetTrainingEndDate(this ObjectContext objectContext) => objectContext.Get(TrainingEndDateKey);
    }
}
