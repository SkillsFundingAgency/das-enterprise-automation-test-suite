using SFA.DAS.ConfigurationBuilder;
using System;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string AccountIdKey = "accountid";
        private const string CommitmentsApprenticeshipIdKey = "commitmentsapprenticeshipid";
        private const string ApprenticeIdKey = "apprenticeid";
        private const string RegistrationIdKey = "registrationidkey";
        private const string OrganisationNameKey = "organisationname";
        private const string FirstNameKey = "firstname";
        private const string LastNameKey = "lastname";
        private const string DateOfBirthKey = "dateofbirth";
        private const string TrainingNameKey = "trainingname";
        private const string EmployerAccountLegalEntityIdKey = "employeraccountlegalentityid";
        private const string EmailKey = "emailkey";
        private const string PasswordKey = "passwordKey";
        private const string ProviderNameKey = "providername";
        private const string EmployerNameKey = "employername";
        private const string TrainingStartDateKey = "trainingstartdate";
        private const string TrainingEndDateKey = "trainingenddate";
        #endregion

        internal static void SetAccountId(this ObjectContext objectContext, long value) => objectContext.Replace(AccountIdKey, value);
        internal static void SetCommitmentsApprenticeshipId(this ObjectContext objectContext, long value) => objectContext.Replace(CommitmentsApprenticeshipIdKey, value);
        internal static void SetApprenticeId(this ObjectContext objectContext, string value) => objectContext.Replace(ApprenticeIdKey, value);
        public static void SetRegistrationId(this ObjectContext objectContext, string value) => objectContext.Replace(RegistrationIdKey, value);
        internal static void SetOrganisationName(this ObjectContext objectContext, string value) => objectContext.Replace(OrganisationNameKey, value);
        public static void SetFirstName(this ObjectContext objectContext, string value) => objectContext.Replace(FirstNameKey, value);
        public static void SetLastName(this ObjectContext objectContext, string value) => objectContext.Replace(LastNameKey, value);
        internal static void SetDateOfBirth(this ObjectContext objectContext, DateTime value) => objectContext.Replace(DateOfBirthKey, value);
        public static void SetTrainingName(this ObjectContext objectContext, string value) => objectContext.Replace(TrainingNameKey, value);
        internal static void SetEmployerAccountLegalEntityId(this ObjectContext objectContext, long value) => objectContext.Replace(EmployerAccountLegalEntityIdKey, value);
        internal static void SetApprenticeDetail(this ObjectContext objectContext, string fName, string lName, DateTime dob, string email)
        {
            objectContext.SetFirstName(fName);
            objectContext.SetLastName(lName);
            objectContext.SetDateOfBirth(dob);
            objectContext.Set(EmailKey, email);
        }
        public static void UpdateApprenticeEmail(this ObjectContext objectContext, string value) => objectContext.Update(EmailKey, value);
        public static void SetApprenticePassword(this ObjectContext objectContext, string value) => objectContext.Set(PasswordKey, value);
        public static void UpdateApprenticePassword(this ObjectContext objectContext, string value) => objectContext.Update(PasswordKey, value);
        internal static void SetProviderName(this ObjectContext objectContext, string value) => objectContext.Replace(ProviderNameKey, value);
        internal static void SetEmployerName(this ObjectContext objectContext, string value) => objectContext.Replace(EmployerNameKey, value);
        public static void SetTrainingStartDate(this ObjectContext objectContext, string value) => objectContext.Replace(TrainingStartDateKey, value);
        internal static void SetTrainingEndDate(this ObjectContext objectContext, string value) => objectContext.Replace(TrainingEndDateKey, value);
        public static string GetCommitmentsApprenticeshipId(this ObjectContext objectContext) => objectContext.Get(CommitmentsApprenticeshipIdKey);
        public static string GetApprenticeEmail(this ObjectContext objectContext) => objectContext.Get(EmailKey);
        public static string GetApprenticePassword(this ObjectContext objectContext) => objectContext.Get(PasswordKey);
        public static string GetFirstName(this ObjectContext objectContext) => objectContext.Get(FirstNameKey);
        public static string GetLastName(this ObjectContext objectContext) => objectContext.Get(LastNameKey);
        public static DateTime GetDateOfBirth(this ObjectContext objectContext) => objectContext.Get<DateTime>(DateOfBirthKey);
        internal static string GetApprenticeId(this ObjectContext objectContext) => objectContext.Get(ApprenticeIdKey);
        public static string GetProviderName(this ObjectContext objectContext) => objectContext.Get(ProviderNameKey);
        public static string GetEmployerName(this ObjectContext objectContext) => objectContext.Get(EmployerNameKey);
        public static string GetTrainingName(this ObjectContext objectContext) => objectContext.Get(TrainingNameKey);
        public static string GetTrainingStartDate(this ObjectContext objectContext) => objectContext.Get(TrainingStartDateKey);
    }
}
