using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.Registration.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string AccountIdKey = "accountid";
        private const string LoggedInUserKey = "loggedinuserkey";
        private const string OrganisationNameKey = "organisationname";
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

        public static void SetOrganisationName(this ObjectContext objectContext, string organisationName)
        {
            objectContext.Set(OrganisationNameKey, organisationName.ToUpper());
        }

        public static void UpdateOrganisationName(this ObjectContext objectContext, string organisationName)
        {
            objectContext.Update(OrganisationNameKey, organisationName.ToUpper());
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
