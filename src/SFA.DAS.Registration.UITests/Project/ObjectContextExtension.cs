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
        private const string DbAccountIdKey = "dbaccountid";
        private const string AgreementIdKey = "agreementid";
        private const string LoggedInUserObject = "loggedinuserobject";
        private const string OrganisationNameKey = "organisationname";
        private const string RegisteredEmailAddress = "registeredemailaddress";
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
        internal static void SetDBAccountId(this ObjectContext objectContext, string accountId) => objectContext.Replace(DbAccountIdKey, accountId);
        internal static void SetAgreementId(this ObjectContext objectContext, string agreementId) => objectContext.Replace(AgreementIdKey, agreementId);
        public static void SetOrganisationName(this ObjectContext objectContext, string organisationName) => objectContext.Set(OrganisationNameKey, organisationName);
        public static void SetAdditionalOrganisationAddedName(this ObjectContext objectContext, string organisationName) => objectContext.Replace(AdditionalOrganisationAddedNameKey, organisationName);
        public static void UpdateOrganisationName(this ObjectContext objectContext, string organisationName) => objectContext.Update(OrganisationNameKey, organisationName);
        public static void SetSecondAccountOrganisationName(this ObjectContext objectContext, string secondAccountOrganisationName) => objectContext.Set(SecondAccountOrganisationNameKey, secondAccountOrganisationName);
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
        public static string GetDBAccountId(this ObjectContext objectContext) => objectContext.Get(DbAccountIdKey);
        public static string GetAgreementId(this ObjectContext objectContext) => objectContext.Get(AgreementIdKey);
        public static string GetOrganisationName(this ObjectContext objectContext) => objectContext.Get(OrganisationNameKey);
        public static string GetAdditionalOrganisationAddedName(this ObjectContext objectContext) => objectContext.Get(AdditionalOrganisationAddedNameKey);
        public static string GetSecondAccountOrganisationName(this ObjectContext objectContext) => objectContext.Get(SecondAccountOrganisationNameKey);
        internal static LoggedInAccountUser GetLoginCredentials(this ObjectContext objectContext) => objectContext.Get<LoggedInAccountUser>(LoggedInUserObject);
        public static string GetRegisteredEmail(this ObjectContext objectContext) => objectContext.Get(RegisteredEmailAddress);
    }
}
