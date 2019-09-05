using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.Registration.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string AccountIdKey = "accountid";
        private const string LoggedInUserKey = "loggedinuserkey";
        #endregion

        internal static void SetLoginCredentials(this ObjectContext objectContext, string loginusername, string loginpassword)
        {
            objectContext.Set(LoggedInUserKey, new LoggedInUser { Username = loginusername, Password = loginpassword});
        }

        internal static void SetAccountId(this ObjectContext objectContext, string accountid)
        {
            objectContext.Set(AccountIdKey, accountid);
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
