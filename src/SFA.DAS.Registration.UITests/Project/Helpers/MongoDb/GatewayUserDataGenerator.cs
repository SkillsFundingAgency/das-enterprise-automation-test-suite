using MongoDB.Bson;
using MongoDB.Driver;

namespace SFA.DAS.Registration.UITests.Project.Helpers.MongoDb
{
    public class GatewayUserDataGenerator : EmpRefFilterDefinition, IMongoDbDataGenerator
    {
        public GatewayUserDataGenerator(MongoDbDataHelper helper) : base(helper) { }

        public string CollectionName() => "gateway_users";

        public BsonDocument[] Data()
        {
            BsonDocument gatewayUser = new BsonDocument
            {
                { "gatewayID", mongoDbDatahelper.GatewayId},
                { "password", mongoDbDatahelper.GatewayPassword},
                { "empref",mongoDbDatahelper.EmpRef},
                { "name", mongoDbDatahelper.Name},
                { "require2SV", false }
            };

            return new BsonDocument[] { gatewayUser };
        }

        public new FilterDefinition<BsonDocument> FilterDefinition()
        {
            return Builders<BsonDocument>.Filter.Eq("gatewayID", mongoDbDatahelper.GatewayId);
        }
    }
}
