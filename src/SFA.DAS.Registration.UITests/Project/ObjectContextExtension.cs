using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;

namespace SFA.DAS.Registration.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private static string UserCredsKey(int index) => $"usercreds_{index}";
        private const string AccountIdKey = "accountid";
        private const string AgreementIdKey = "agreementid";
        private const string LoggedInUserObject = "loggedinuserobject";
        private const string OrganisationNameKey = "organisationname";
        private const string ReceiverAccountIdkey = "receiveraccountidkey";
        private const string ReceiverPublicAccountIdkey = "receiverpublicaccountidkey";
        private const string RegisteredEmailAddress = "registeredemailaddress";
        private const string FirstAccountOrganisationNameKey = "firstaccountorganisationkamekey";
        private const string SecondAccountOrganisationNameKey = "secondaccountorganisationkamekey";
        private const string AdditionalOrganisationAddedNameKey = "additionalorganisationaddednamekey";
        #endregion

        internal static void SetLoginCredentials(this ObjectContext objectContext, string loginusername, string loginpassword, string organisationName)
        {
            objectContext.SetRegisteredEmail(loginusername);
            objectContext.UpdateOrganisationName(organisationName);
            objectContext.Set(LoggedInUserObject, new LoggedInUser { Username = loginusername, Password = loginpassword, OrganisationName = organisationName });
        }

        internal static void SetAccountId(this ObjectContext objectContext, string accountid) => objectContext.Replace(AccountIdKey, accountid);
        internal static void SetAgreementId(this ObjectContext objectContext, string agreementId) => objectContext.Replace(AgreementIdKey, agreementId);
        public static void SetOrganisationName(this ObjectContext objectContext, string organisationName) => objectContext.Set(OrganisationNameKey, organisationName);
        public static void SetAdditionalOrganisationAddedName(this ObjectContext objectContext, string organisationName) => objectContext.Replace(AdditionalOrganisationAddedNameKey, organisationName);
        public static void UpdateOrganisationName(this ObjectContext objectContext, string organisationName) => objectContext.Update(OrganisationNameKey, organisationName);
        public static void SetFirstAccountOrganisationName(this ObjectContext objectContext, string firstAccountOrganisationName) => objectContext.Set(FirstAccountOrganisationNameKey, firstAccountOrganisationName);
        public static void SetSecondAccountOrganisationName(this ObjectContext objectContext, string secondAccountOrganisationName) => objectContext.Set(SecondAccountOrganisationNameKey, secondAccountOrganisationName);
        internal static void SetReceiverAccountId(this ObjectContext objectContext, string value) => objectContext.Set(ReceiverAccountIdkey, value);
        internal static void SetReceiverPublicAccountId(this ObjectContext objectContext, string value) => objectContext.Set(ReceiverPublicAccountIdkey, value);
        internal static void SetRegisteredEmail(this ObjectContext objectContext, string value) => objectContext.Replace(RegisteredEmailAddress, value);
        internal static void SetUserCreds(this ObjectContext objectContext, string emailaddress, string password, string orgName, int index) =>
            objectContext.Replace<UserCreds>(UserCredsKey(index), new UserCreds(emailaddress, password, orgName, index));
        internal static void UdpateUserCreds(this ObjectContext objectContext, string accountid, int index) => objectContext.Get<UserCreds>(UserCredsKey(index)).Accountid = accountid;

        public static string GetReceiverAccountId(this ObjectContext objectContext) => objectContext.Get(ReceiverAccountIdkey);
        public static string GetAgreementId(this ObjectContext objectContext) => objectContext.Get(AgreementIdKey);
        public static string GetPublicReceiverAccountId(this ObjectContext objectContext) => objectContext.Get(ReceiverPublicAccountIdkey);
        public static string GetOrganisationName(this ObjectContext objectContext) => objectContext.Get(OrganisationNameKey);
        public static string GetAdditionalOrganisationAddedName(this ObjectContext objectContext) => objectContext.Get(AdditionalOrganisationAddedNameKey);
        public static string GetFirstAccountOrganisationName(this ObjectContext objectContext) => objectContext.Get(FirstAccountOrganisationNameKey);
        public static string GetSecondAccountOrganisationName(this ObjectContext objectContext) => objectContext.Get(SecondAccountOrganisationNameKey);
        public static string GetAccountId(this ObjectContext objectContext) => objectContext.Get(AccountIdKey);
        internal static LoginUser GetLoginCredentials(this ObjectContext objectContext) => objectContext.Get<LoginUser>(LoggedInUserObject);
        internal static string GetRegisteredEmail(this ObjectContext objectContext) => objectContext.Get(RegisteredEmailAddress);
    }
}
