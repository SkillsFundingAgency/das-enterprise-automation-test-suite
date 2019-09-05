using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.Registration.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string AccountIdKey = "accountid";
        private const string LoggedInUserKey = "loggedinuserkey";
        #endregion

        public static void SetLoginCredentials(this ObjectContext objectContext, string loginusername, string loginpassword, bool isLevy)
        {
            objectContext.Set(LoggedInUserKey, new LoggedInUser { Username = loginusername, Password = loginpassword, isLevy = isLevy });
        }

        public static void SetAccountId(this ObjectContext objectContext, string accountid)
        {
            objectContext.Set(AccountIdKey, accountid);
        }

        public static string GetAccountId(this ObjectContext objectContext)
        {
            return objectContext.Get(AccountIdKey);
        }

        public static LoggedInUser GetLoginCredentials(this ObjectContext objectContext)
        {
            return objectContext.Get<LoggedInUser>(LoggedInUserKey);
        }
    }
}
