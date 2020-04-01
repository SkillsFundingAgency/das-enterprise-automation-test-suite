using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.MongoDb.DataGenerator.Helpers;
using System.Collections.Generic;

namespace SFA.DAS.MongoDb.DataGenerator
{
    public static class ObjectContextExtension
    {
        #region Constants
        private static string GatewayCredsKey(int index) => $"gatewaycreds_{index}";
        private const string DataHelperKey = "datahelper";

        private static string MongoDbDataHelperKey(string empRef) => $"mongodbdatahelper_{empRef}";
        #endregion

        public static void SetMongoDbDataHelper(this ObjectContext objectContext, MongoDbDataHelper dataHelper, string empRef) => objectContext.Set<MongoDbDataHelper>(MongoDbDataHelperKey(empRef), dataHelper);
        public static void SetDataHelper(this ObjectContext objectContext, DataHelper dataHelper) => objectContext.Replace<DataHelper>(DataHelperKey, dataHelper);
        public static void SetGatewayCreds(this ObjectContext objectContext, string gatewayid, string gatewaypassword, string paye, int index) =>
            objectContext.Replace<GatewayCreds>(GatewayCredsKey(index), new GatewayCreds(gatewayid, gatewaypassword, paye, index));
        
        public static GatewayCreds GetGatewayCreds(this ObjectContext objectContext, int index) => objectContext.Get<GatewayCreds>(GatewayCredsKey(index));
        public static string GetGatewayPaye(this ObjectContext objectContext, int index) => objectContext.GetGatewayCreds(index).Paye;
        public static DataHelper GetDataHelper(this ObjectContext objectContext) => objectContext.Get<DataHelper>(DataHelperKey);
        public static IEnumerable<MongoDbDataHelper> GetMongoDbDataHelpers(this ObjectContext objectContext) => objectContext.GetAll<MongoDbDataHelper>();
    }
}
