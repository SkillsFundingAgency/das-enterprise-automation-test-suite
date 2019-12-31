using SFA.DAS.ConfigurationBuilder;

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
        #endregion

        internal static void SetLoginCredentials(this ObjectContext objectContext, string loginusername, string loginpassword)
        {
            objectContext.Set("LoggedInUser", loginusername);
            objectContext.Set(LoggedInUserKey, new LoggedInUser { Username = loginusername, Password = loginpassword});
        }

        internal static void SetAccountId(this ObjectContext objectContext, string accountid)
        {
            objectContext.Replace(AccountIdKey, accountid);
        }

        internal static void SetAgreementId(this ObjectContext objectContext, string agreementId)
        {
            objectContext.Replace(AgreementIdKey, agreementId);
        }

        public static void SetOrganisationName(this ObjectContext objectContext, string organisationName)
        {
            objectContext.Set(OrganisationNameKey, organisationName.ToUpper());
        }

        public static void UpdateOrganisationName(this ObjectContext objectContext, string organisationName)
        {
            objectContext.Update(OrganisationNameKey, organisationName.ToUpper());
        }

        internal static void SetReceiverAccountId(this ObjectContext objectContext, string value)
        {
            objectContext.Set(ReceiverAccountIdkey, value);
        }

        internal static void SetReceiverPublicAccountId(this ObjectContext objectContext, string value)
        {
            objectContext.Set(ReceiverPublicAccountIdkey, value);
        }
        public static string GetReceiverAccountId(this ObjectContext objectContext)
        {
            return objectContext.Get(ReceiverAccountIdkey);
        }

        public static string GetAgreementId(this ObjectContext objectContext)
        {
            return objectContext.Get(AgreementIdKey);
        }

        public static string GetPublicReceiverAccountId(this ObjectContext objectContext)
        {
            return objectContext.Get(ReceiverPublicAccountIdkey);
        }

        public static string GetOrganisationName(this ObjectContext objectContext)
        {
            return objectContext.Get(OrganisationNameKey);
        }

        public static string GetAccountId(this ObjectContext objectContext)
        {
            return objectContext.Get(AccountIdKey);
        }

        internal static LoginUser GetLoginCredentials(this ObjectContext objectContext)
        {
            return objectContext.Get<LoginUser>(LoggedInUserKey);
        }
    }
}
