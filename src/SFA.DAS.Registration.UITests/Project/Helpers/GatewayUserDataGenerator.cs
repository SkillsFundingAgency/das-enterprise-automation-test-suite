using MongoDB.Bson;
using MongoDB.Driver;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class GatewayUserDataGenerator : IMongoDbDataGenerator
    {
        private readonly MongoDbDataHelper _helper;

        public GatewayUserDataGenerator(MongoDbDataHelper helper)
        {
            _helper = helper;
        }

        public string CollectionName() => "gateway_users";

        public BsonDocument[] Data()
        {
            BsonDocument gatewayUser = new BsonDocument
            {
                { "gatewayID", _helper.GatewayId},
                { "password", _helper.GatewayPassword},
                { "empref",_helper.EmpRef},
                { "name", _helper.Name},
                { "require2SV", false }
            };

            return new BsonDocument[] { gatewayUser };
        }

        public FilterDefinition<BsonDocument> FilterDefinition()
        {
            return Builders<BsonDocument>.Filter.Eq("gatewayID", _helper.GatewayId);
        }
    }
}
