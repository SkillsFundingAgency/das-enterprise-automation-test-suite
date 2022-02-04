using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;

namespace SFA.DAS.Registration.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private static string UserCredsKey(int index) => $"usercreds_{index}";
        private const string HashedAccountIdKey = "hashedaccountid";
        private const string PublicHashedAccountIdKey = "publichashedaccountid";
        private const string DbAccountIdKey = "dbaccountid";
        private const string AgreementIdKey = "agreementid";
        private const string LoggedInUserObject = "loggedinuserobject";
        private const string OrganisationNameKey = "organisationname";
        private const string SecondAccountHashedIdKey = "secondhashedaccountid";
        private const string SecondAccountPublicHashedIdKey = "publicsecondhashedaccountid";
        private const string ThirdAccountHashedIdKey = "thirdhashedaccountid";
        private const string ThirdAccountPublicHashedIdKey = "publicthirdhashedaccountid";
        private const string RegisteredEmailAddress = "registeredemailaddress";
        private const string FirstAccountOrganisationNameKey = "firstaccountorganisationkamekey";
        private const string SecondAccountOrganisationNameKey = "secondaccountorganisationkamekey";
        private const string AdditionalOrganisationAddedNameKey = "additionalorganisationaddednamekey";
        #endregion

        internal static void SetLoginCredentials(this ObjectContext objectContext, string loginusername, string loginpassword, string organisationName)
        {
            objectContext.SetRegisteredEmail(loginusername);
            objectContext.UpdateOrganisationName(organisationName);
            objectContext.Replace(LoggedInUserObject, new LoggedInAccountUser { Username = loginusername, Password = loginpassword, OrganisationName = organisationName });
        }

        internal static void SetHashedAccountId(this ObjectContext objectContext, string accountId) => objectContext.Replace(HashedAccountIdKey, accountId);
        internal static void SetPublicHashedAccountId(this ObjectContext objectContext, string publicAccountId) => objectContext.Replace(PublicHashedAccountIdKey, publicAccountId);
        internal static void SetDBAccountId(this ObjectContext objectContext, string accountId) => objectContext.Replace(DbAccountIdKey, accountId);
        internal static void SetAgreementId(this ObjectContext objectContext, string agreementId) => objectContext.Replace(AgreementIdKey, agreementId);
        public static void SetOrganisationName(this ObjectContext objectContext, string organisationName) => objectContext.Set(OrganisationNameKey, organisationName);
        public static void SetAdditionalOrganisationAddedName(this ObjectContext objectContext, string organisationName) => objectContext.Replace(AdditionalOrganisationAddedNameKey, organisationName);
        public static void UpdateOrganisationName(this ObjectContext objectContext, string organisationName) => objectContext.Update(OrganisationNameKey, organisationName);
        public static void SetFirstAccountOrganisationName(this ObjectContext objectContext, string firstAccountOrganisationName) => objectContext.Set(FirstAccountOrganisationNameKey, firstAccountOrganisationName);
        public static void SetSecondAccountOrganisationName(this ObjectContext objectContext, string secondAccountOrganisationName) => objectContext.Set(SecondAccountOrganisationNameKey, secondAccountOrganisationName);
        internal static void SetSecondAccountHashedId(this ObjectContext objectContext, string value) => objectContext.Set(SecondAccountHashedIdKey, value);
        internal static void SetSecondAccountPublicHashedId(this ObjectContext objectContext, string value) => objectContext.Set(SecondAccountPublicHashedIdKey, value);
        internal static void SetThirdAccountHashedId(this ObjectContext objectContext, string value) => objectContext.Set(ThirdAccountHashedIdKey, value);
        internal static void SetThirdAccountPublicHashedId(this ObjectContext objectContext, string value) => objectContext.Set(ThirdAccountPublicHashedIdKey, value);
        internal static void SetRegisteredEmail(this ObjectContext objectContext, string value) => objectContext.Replace(RegisteredEmailAddress, value);
        internal static void SetUserCreds(this ObjectContext objectContext, string emailaddress, string password, string orgName, int index) =>
            objectContext.Replace<UserCreds>(UserCredsKey(index), new UserCreds(emailaddress, password, orgName, index));

        internal static void UpdateUserCreds(this ObjectContext objectContext, (string accountId, string hashedId, string orgName, string publicHashedId) accDetails, int index)
        {
            var usercreds = objectContext.Get<UserCreds>(UserCredsKey(index));
            usercreds.AccountId = accDetails.accountId;
            usercreds.HashedId = accDetails.hashedId;
            usercreds.OrgName = accDetails.orgName;
            usercreds.PublicHashedid = accDetails.publicHashedId;
        }

        public static string GetHashedAccountId(this ObjectContext objectContext) => objectContext.Get(HashedAccountIdKey);
        public static string GetPublicHashedAccountId(this ObjectContext objectContext) => objectContext.Get(PublicHashedAccountIdKey);
        public static string GetDBAccountId(this ObjectContext objectContext) => objectContext.Get(DbAccountIdKey);
        public static string GetAgreementId(this ObjectContext objectContext) => objectContext.Get(AgreementIdKey);
        public static string GetSecondAccountHashedId(this ObjectContext objectContext) => objectContext.Get(SecondAccountHashedIdKey);
        public static string GetSecondAccountPublicHashedId(this ObjectContext objectContext) => objectContext.Get(SecondAccountPublicHashedIdKey);
        public static string GetThirdAccountHashedId(this ObjectContext objectContext) => objectContext.Get(ThirdAccountHashedIdKey);
        public static string GetThirdAccountPublicHashedId(this ObjectContext objectContext) => objectContext.Get(ThirdAccountPublicHashedIdKey);
        public static string GetOrganisationName(this ObjectContext objectContext) => objectContext.Get(OrganisationNameKey);
        public static string GetAdditionalOrganisationAddedName(this ObjectContext objectContext) => objectContext.Get(AdditionalOrganisationAddedNameKey);
        public static string GetFirstAccountOrganisationName(this ObjectContext objectContext) => objectContext.Get(FirstAccountOrganisationNameKey);
        public static string GetSecondAccountOrganisationName(this ObjectContext objectContext) => objectContext.Get(SecondAccountOrganisationNameKey);
        internal static LoggedInAccountUser GetLoginCredentials(this ObjectContext objectContext) => objectContext.Get<LoggedInAccountUser>(LoggedInUserObject);
        public static string GetRegisteredEmail(this ObjectContext objectContext) => objectContext.Get(RegisteredEmailAddress);
    }
}
