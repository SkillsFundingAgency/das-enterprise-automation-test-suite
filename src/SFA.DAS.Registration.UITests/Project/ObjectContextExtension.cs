using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Registration.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private static string UserCredsKey(int index) => $"usercreds_{index}";
        private const string HashedAccountIdKey = "hashedaccountid";
        private const string AgreementIdKey = "agreementid";
        private const string LoggedInUserObject = "loggedinuserobject";
        private const string OrganisationNameKey = "organisationname";
        private const string RegisteredEmailAddress = "registeredemailaddress";
        private static string AdditionalOrganisation(int index) => $"additionalorganisationkey_{index}";
        private const string RecentlyAddedOrganisationName = "recentlyaddedorganisationname";
        #endregion

        internal static void SetLoginCredentials(this ObjectContext objectContext, string loginusername, string loginpassword, string organisationName)
        {
            objectContext.SetRegisteredEmail(loginusername);
            objectContext.UpdateOrganisationName(organisationName);
            objectContext.Replace(LoggedInUserObject, new LoggedInAccountUser { Username = loginusername, Password = loginpassword, OrganisationName = organisationName });
        }

        internal static void SetHashedAccountId(this ObjectContext objectContext, string accountId) => objectContext.Replace(HashedAccountIdKey, accountId);
        internal static void SetAgreementId(this ObjectContext objectContext, string agreementId) => objectContext.Replace(AgreementIdKey, agreementId);
        public static void SetOrganisationName(this ObjectContext objectContext, string organisationName) => objectContext.Set(OrganisationNameKey, organisationName);
        public static void SetRecentlyAddedOrganisationName(this ObjectContext objectContext, string organisationName) => objectContext.Replace(RecentlyAddedOrganisationName, organisationName);
        public static void UpdateOrganisationName(this ObjectContext objectContext, string organisationName) => objectContext.Update(OrganisationNameKey, organisationName);
        public static void SetAdditionalOrganisationName(this ObjectContext objectContext, string secondAccountOrganisationName, int index) => objectContext.Set(AdditionalOrganisation(index), secondAccountOrganisationName);
        internal static void SetRegisteredEmail(this ObjectContext objectContext, string value) => objectContext.Replace(RegisteredEmailAddress, value);
        internal static void SetUserCreds(this ObjectContext objectContext, string emailaddress, string password, int index) =>
            objectContext.Replace(UserCredsKey(index), new UserCreds(emailaddress, password, index));

        internal static void UpdateUserCreds(this ObjectContext objectContext, string emailaddress, string password, List<(string accountId, string hashedId, string orgName, string publicHashedId)> accDetails, int index)
        {
            if (objectContext.GetUserCreds(index) is null) objectContext.SetUserCreds(emailaddress, password, index);
            
            objectContext.UpdateUserCreds(accDetails, index);
        }

        internal static void UpdateUserCreds(this ObjectContext objectContext, string emailaddress, List<(string accountId, string hashedId, string orgName, string publicHashedId)> accDetails)
        {
            var userCreds = objectContext.GetAll<UserCreds>().SingleOrDefault(x => x.EmailAddress == emailaddress);

            objectContext.UpdateUserCreds(accDetails, userCreds.UserIndex);
        }

        internal static void UpdateUserCreds(this ObjectContext objectContext, List<(string accountId, string hashedId, string orgName, string publicHashedId)> accDetails, int index)
        {
            var usercreds = objectContext.GetUserCreds(index);

            foreach (var (accountId, hashedId, orgName, publicHashedId) in accDetails)
            {
                var userAccountDetails = usercreds.AccountDetails;

                if (userAccountDetails.Any(x => x.AccountId == accountId)) continue;

                usercreds.AccountDetails.Add(new AccountDetails
                {
                    AccountId = accountId,
                    HashedId = hashedId,
                    OrgName = orgName,
                    PublicHashedid = publicHashedId
                });
            }
        }

        public static string GetRegisteredEmail(this ObjectContext objectContext) => objectContext.Get(RegisteredEmailAddress);
        public static string GetHashedAccountId(this ObjectContext objectContext) => objectContext.GetUserCreds(0).AccountDetails[0].HashedId;
        public static string GetDBAccountId(this ObjectContext objectContext) => objectContext.GetUserCreds(0).AccountDetails[0].AccountId;
        public static string GetAgreementId(this ObjectContext objectContext) => objectContext.Get(AgreementIdKey);
        public static string GetOrganisationName(this ObjectContext objectContext) => objectContext.Get(OrganisationNameKey);
        public static string GetRecentlyAddedOrganisationName(this ObjectContext objectContext) => objectContext.Get(RecentlyAddedOrganisationName);
        public static string GetAdditionalOrganisationName(this ObjectContext objectContext,int index) => objectContext.Get(AdditionalOrganisation(index));
        internal static LoggedInAccountUser GetLoginCredentials(this ObjectContext objectContext) => objectContext.Get<LoggedInAccountUser>(LoggedInUserObject);
        private static UserCreds GetUserCreds(this ObjectContext objectContext, int index) => objectContext.Get<UserCreds>(UserCredsKey(index));
    }
}
