using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace SFA.DAS.PocProject.UITests.Project.Helpers
{
    public class MongoDbHelper
    {
        private readonly MongoDbConfig _config;
        private readonly MongoDbDataHelper _helper;

        public MongoDbHelper(MongoDbConfig config, MongoDbDataHelper helper)
        {
            _config = config;
            _helper = helper;
        }

        public async Task AsyncCreateData()
        {
            await AsyncCreateGatewayUserData();
        }

        public async Task AsyncDeleteData()
        {
            await AsyncDeleteGatewayUserData();
        }

        private async Task AsyncDeleteGatewayUserData()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("gatewayID", _helper.GatewayId);

            await GetGatewayUsersCollection<BsonDocument>().DeleteOneAsync(filter);
        }
        
        private async Task AsyncCreateGatewayUserData()
        {
            BsonDocument[] data = CreateGatewayUserData();

            await GetGatewayUsersCollection<BsonDocument>().InsertManyAsync(data);
        }

        private BsonDocument[] CreateGatewayUserData()
        {
            BsonDocument addUser = new BsonDocument
            {
                { "gatewayID", _helper.GatewayId},
                { "password", _helper.GatewayPassword},
                { "empref",_helper.EmpRef},
                { "name", _helper.Name},
                { "require2SV", false }
            };

            return new BsonDocument[] { addUser };
        }

        private IMongoCollection<T> GetGatewayUsersCollection<T>()
        {
            var client = new MongoClient(_config.Uri);
            var db = client.GetDatabase(_config.Database);

            return db.GetCollection<T>("gateway_users");
        }
    }
}
