using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.PocProject.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string gatewayidkey = "gatewayid";
        private const string gatewaypasswordkey = "gatewaypassword";
        private const string payekey = "paye";
        private const string accountidkey = "accountid";
        #endregion

        public static void SetGatewayCreds(this ObjectContext objectContext, string gatewayid,string gatewaypassword, string paye)
        {
            objectContext.Set(gatewayidkey, gatewayid);
            objectContext.Set(gatewaypasswordkey, gatewaypassword);
            objectContext.Set(payekey, paye);
        }

        public static void SetAccountId(this ObjectContext objectContext, string accountid)
        {
            objectContext.Set(accountidkey, accountid);
        }

        public static string GetGatewayId(this ObjectContext objectContext)
        {
            return objectContext.Get(gatewayidkey);
        }

        public static string GetGatewayPassword(this ObjectContext objectContext)
        {
            return objectContext.Get(gatewaypasswordkey);
        }

        public static string GetGatewayPaye(this ObjectContext objectContext)
        {
            return objectContext.Get(payekey);
        }

        public static string GetAccountId(this ObjectContext objectContext)
        {
            return objectContext.Get(accountidkey);
        }
    }
}
