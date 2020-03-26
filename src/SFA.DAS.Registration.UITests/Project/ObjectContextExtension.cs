using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service.Helpers;

namespace SFA.DAS.Registration.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string AccountIdKey = "accountid";
        private const string AgreementIdKey = "agreementid";
        private const string LoggedInUserKey = "loggedinuserkey";
        private const string OrganisationNameKey = "organisationname";
        private const string ReceiverAccountIdkey = "receiveraccountidkey";
        private const string ReceiverPublicAccountIdkey = "receiverpublicaccountidkey";
        private const string RegisteredEmailKey = "registeredemailkey";
        #endregion

        internal static void SetLoginCredentials(this ObjectContext objectContext, string loginusername, string loginpassword)
        {
            objectContext.Set("LoggedInUser", loginusername);
            objectContext.SetRegisteredEmail(loginusername);
            objectContext.Set(LoggedInUserKey, new LoggedInUser { Username = loginusername, Password = loginpassword });
        }

        internal static void SetAccountId(this ObjectContext objectContext, string accountid) => objectContext.Replace(AccountIdKey, accountid);
        internal static void SetAgreementId(this ObjectContext objectContext, string agreementId) => objectContext.Replace(AgreementIdKey, agreementId);
        public static void SetOrganisationName(this ObjectContext objectContext, string organisationName) => objectContext.Set(OrganisationNameKey, organisationName);
        public static void UpdateOrganisationName(this ObjectContext objectContext, string organisationName) => objectContext.Update(OrganisationNameKey, organisationName);
        internal static void SetReceiverAccountId(this ObjectContext objectContext, string value) => objectContext.Set(ReceiverAccountIdkey, value);
        internal static void SetReceiverPublicAccountId(this ObjectContext objectContext, string value) => objectContext.Set(ReceiverPublicAccountIdkey, value);
        internal static void SetRegisteredEmail(this ObjectContext objectContext, string value) => objectContext.Replace(RegisteredEmailKey, value);
        public static string GetReceiverAccountId(this ObjectContext objectContext) => objectContext.Get(ReceiverAccountIdkey);
        public static string GetAgreementId(this ObjectContext objectContext) => objectContext.Get(AgreementIdKey);
        public static string GetPublicReceiverAccountId(this ObjectContext objectContext) => objectContext.Get(ReceiverPublicAccountIdkey);
        public static string GetOrganisationName(this ObjectContext objectContext) => objectContext.Get(OrganisationNameKey);
        public static string GetAccountId(this ObjectContext objectContext) => objectContext.Get(AccountIdKey);
        internal static LoginUser GetLoginCredentials(this ObjectContext objectContext) => objectContext.Get<LoginUser>(LoggedInUserKey);
        internal static string GetRegisteredEmail(this ObjectContext objectContext) => objectContext.Get(RegisteredEmailKey);
    }
}
