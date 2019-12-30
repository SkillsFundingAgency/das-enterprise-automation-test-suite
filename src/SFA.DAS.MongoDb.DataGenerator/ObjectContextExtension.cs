using SFA.DAS.Configuration;
using SFA.DAS.MongoDb.DataGenerator.Helpers;
using System.Collections.Generic;

namespace SFA.DAS.MongoDb.DataGenerator
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string GatewayIdKey = "gatewayid";
        private const string GatewayPasswordKey = "gatewaypassword";
        private const string PayeKey = "paye";
        private const string DataHelperKey = "datahelper";
        private static string MongoDbDataHelperKey(string empRef) => $"mongodbdatahelper_{empRef}";
        #endregion

        public static void SetMongoDbDataHelper(this ObjectContext objectContext, MongoDbDataHelper dataHelper, string empRef)
        {
            objectContext.Set<MongoDbDataHelper>(MongoDbDataHelperKey(empRef), dataHelper);
        }

        public static void SetDataHelper(this ObjectContext objectContext, DataHelper dataHelper)
        {
            objectContext.Set<DataHelper>(DataHelperKey, dataHelper);
        }

        public static void UpdateDataHelper(this ObjectContext objectContext, DataHelper dataHelper)
        {
            objectContext.Update(DataHelperKey, dataHelper);
        }

        public static void SetGatewayCreds(this ObjectContext objectContext, string gatewayid,string gatewaypassword, string paye)
        {
            objectContext.Replace(GatewayIdKey, gatewayid);
            objectContext.Replace(GatewayPasswordKey, gatewaypassword);
            objectContext.Replace(PayeKey, paye);
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

        public static DataHelper GetDataHelper(this ObjectContext objectContext)
        {
            return objectContext.Get<DataHelper>(DataHelperKey);
        }

        public static IEnumerable<MongoDbDataHelper> GetMongoDbDataHelpers(this ObjectContext objectContext)
        {
            return objectContext.GetAll<MongoDbDataHelper>();
        }
    }
}
