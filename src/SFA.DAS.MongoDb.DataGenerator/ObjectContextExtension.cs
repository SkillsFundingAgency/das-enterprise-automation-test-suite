using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.MongoDb.DataGenerator
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string GatewayIdKey = "gatewayid";
        private const string GatewayPasswordKey = "gatewaypassword";
        private const string PayeKey = "paye";
        #endregion

        public static void SetGatewayCreds(this ObjectContext objectContext, string gatewayid,string gatewaypassword, string paye)
        {
            objectContext.Set(GatewayIdKey, gatewayid);
            objectContext.Set(GatewayPasswordKey, gatewaypassword);
            objectContext.Set(PayeKey, paye);
        }

        public static string GetGatewayId(this ObjectContext objectContext)
        {
            return objectContext.Get(GatewayIdKey);
        }

        public static string GetGatewayPassword(this ObjectContext objectContext)
        {
            return objectContext.Get(GatewayPasswordKey);
        }

        public static string GetGatewayPaye(this ObjectContext objectContext)
        {
            return objectContext.Get(PayeKey);
        }
    }
}
