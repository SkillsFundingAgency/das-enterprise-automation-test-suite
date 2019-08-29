using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.Registration.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string AccountIdKey = "accountid";
        #endregion

        public static void SetAccountId(this ObjectContext objectContext, string accountid)
        {
            objectContext.Set(AccountIdKey, accountid);
        }

        public static string GetAccountId(this ObjectContext objectContext)
        {
            return objectContext.Get(AccountIdKey);
        }
    }
}
