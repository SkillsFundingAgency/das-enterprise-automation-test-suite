using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.Roatp.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string CreateAccountCredsKey = "createAccountcredskey";
        private const string EmailKey = "emailkey";
        private const string ProviderNameKey = "providernamekey";
        private const string OrganisationTypeKey = "organisationtypekey";
        private const string UkprnKey = "ukprnkey";
        private const string NewUkprnKey = "newukprnkey";
        private const string ApplicationReference = "applicationreference";
        #endregion

        internal static void SetCreateAccountCreds(this ObjectContext objectContext, string email, string password) => objectContext.Set(CreateAccountCredsKey, $"Email : {email}, Password : {password}");
        public static void SetEmail(this ObjectContext objectContext, string email) => objectContext.Replace(EmailKey, email);
        public static void SetProviderName(this ObjectContext objectContext, string providername) => objectContext.Replace(ProviderNameKey, providername);
        internal static void UpdateOrganisationType(this ObjectContext objectContext, string organisationType) => objectContext.Replace(OrganisationTypeKey, organisationType);
        public static void SetUkprn(this ObjectContext objectContext, string Ukprn) => objectContext.Replace(UkprnKey, Ukprn);
        public static void SetNewUkprn(this ObjectContext objectContext, string NewUkprn) => objectContext.Replace(NewUkprnKey, NewUkprn);
        internal static void SetApplicationReference(this ObjectContext objectContext, string applicationReference) => objectContext.Replace(ApplicationReference, applicationReference);
        
        public static string GetProviderName(this ObjectContext objectContext) => objectContext.Get(ProviderNameKey);
        internal static string GetOrganisationType(this ObjectContext objectContext) => objectContext.Get(OrganisationTypeKey);
        internal static string GetEmail(this ObjectContext objectContext) => objectContext.Get(EmailKey);
        public static string GetUkprn(this ObjectContext objectContext) => objectContext.Get(UkprnKey);
        public static string GetNewUkprn(this ObjectContext objectContext) => objectContext.Get(NewUkprnKey);
        internal static string GetApplicationReference(this ObjectContext objectContext) => objectContext.Get(ApplicationReference);
    }
}
