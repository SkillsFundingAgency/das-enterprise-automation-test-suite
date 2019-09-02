using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.Registration.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string AccountIdKey = "accountid";
        private const string LoginUsername = "loginusername";
        private const string LoginPassword = "loginpassword";
        #endregion

        public static void SetLoginCredentials(this ObjectContext objectContext, string loginusername, string loginpassword)
        {
            objectContext.Set(LoginUsername, loginusername);
            objectContext.Set(LoginPassword, loginpassword);
        }

        public static void SetAccountId(this ObjectContext objectContext, string accountid)
        {
            objectContext.Set(AccountIdKey, accountid);
        }

        public static string GetAccountId(this ObjectContext objectContext)
        {
            return objectContext.Get(AccountIdKey);
        }

        public static string GetLoginUsername(this ObjectContext objectContext)
        {
            return objectContext.Get(LoginUsername);
        }

        public static string GetLoginPassword(this ObjectContext objectContext)
        {
            return objectContext.Get(LoginPassword);
        }
    }
}
