using MongoDB.Driver;
using System.Threading.Tasks;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class MongoDbConnectionHelper
    {
        private readonly MongoDbConfig _config;

        public MongoDbConnectionHelper(MongoDbConfig config)
        {
            _config = config;
        }

        public async Task AsyncDeleteGatewayUserData<T>(string collectionName, FilterDefinition<T> filter)
        {
            await GetGatewayUsersCollection<T>(collectionName).DeleteOneAsync(filter);
        }

        public async Task AsyncCreateGatewayUserData<T>(string collectionName, T[] data)
        {
            await GetGatewayUsersCollection<T>(collectionName).InsertManyAsync(data);
        }

        private IMongoCollection<T> GetGatewayUsersCollection<T>(string collectionName)
        {
            var db = GetMongoDatabase();
            return db.GetCollection<T>(collectionName);
        }
        private IMongoDatabase GetMongoDatabase()
        {
            var client = new MongoClient(_config.Uri);
            return client.GetDatabase(_config.Database);
        }

    }
}
