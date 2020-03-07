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
        private const string AornNumberKey = "aornnumberkey";
        private const string RegisteredEmailKey = "registeredemailkey";
        #endregion

        internal static void SetLoginCredentials(this ObjectContext objectContext, string loginusername, string loginpassword)
        {
            objectContext.Set("LoggedInUser", loginusername);
            objectContext.Set(LoggedInUserKey, new LoggedInUser { Username = loginusername, Password = loginpassword });
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
            objectContext.Set(OrganisationNameKey, organisationName);
        }

        public static void UpdateOrganisationName(this ObjectContext objectContext, string organisationName)
        {
            objectContext.Update(OrganisationNameKey, organisationName);
        }

        internal static void SetReceiverAccountId(this ObjectContext objectContext, string value)
        {
            objectContext.Set(ReceiverAccountIdkey, value);
        }

        internal static void SetReceiverPublicAccountId(this ObjectContext objectContext, string value)
        {
            objectContext.Set(ReceiverPublicAccountIdkey, value);
        }

        internal static void SetAornNumber(this ObjectContext objectContext, string value)
        {
            objectContext.Set(AornNumberKey, value);
        }

        internal static void SetRegisteredEmail(this ObjectContext objectContext, string value)
        {
            objectContext.Set(RegisteredEmailKey, value);
        }

        public static void UpdateRegisteredEmail(this ObjectContext objectContext, string value)
        {
            objectContext.Update(RegisteredEmailKey, value);
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

        internal static string GetAornNumber(this ObjectContext objectContext)
        {
            return objectContext.Get(AornNumberKey);
        }

        internal static string GetRegisteredEmail(this ObjectContext objectContext)
        {
            return objectContext.Get(RegisteredEmailKey);
        }
    }
}
