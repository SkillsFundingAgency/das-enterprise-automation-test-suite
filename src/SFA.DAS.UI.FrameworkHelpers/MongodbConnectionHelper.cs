using MongoDB.Bson;
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

        public async Task AsyncDeleteData<T>(string collectionName, FilterDefinition<T> filter)
        {
            await GetCollection<T>(collectionName).DeleteOneAsync(filter);
        }

        public async Task AsyncCreateData<T>(string collectionName, T[] data)
        {
            await GetCollection<T>(collectionName).InsertManyAsync(data);
        }

        private IMongoCollection<T> GetCollection<T>(string collectionName)
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
