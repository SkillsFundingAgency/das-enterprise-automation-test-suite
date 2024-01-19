using MongoDB.Bson;
using MongoDB.Driver;

namespace SFA.DAS.MongoDb.DataGenerator.Helpers
{
    public class GatewayUserDataGenerator(MongoDbDataHelper helper) : EmpRefFilterDefinition(helper), IMongoDbDataGenerator
    {
        public string CollectionName() => "gateway_users";

        public BsonDocument[] Data()
        {
            BsonDocument gatewayUser = new()
            {
                { "gatewayID", mongoDbDatahelper.GatewayId},
                { "password", mongoDbDatahelper.GatewayPassword},
                { "empref",mongoDbDatahelper.EmpRef},
                { "name", mongoDbDatahelper.Name},
                { "require2SV", false }
            };

            return [gatewayUser];
        }

        public new FilterDefinition<BsonDocument> FilterDefinition() => Builders<BsonDocument>.Filter.Eq("gatewayID", mongoDbDatahelper.GatewayId);
    }
}
