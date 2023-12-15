using MongoDB.Driver;
using SFA.DAS.UI.FrameworkHelpers;
using System.Threading.Tasks;

namespace SFA.DAS.MongoDb.DataGenerator.Helpers
{
    public class MongoDbConnectionHelper(MongoDbConfig config)
    {
        public async Task AsyncDeleteData<T>(string collectionName, FilterDefinition<T> filter) => await GetCollection<T>(collectionName).DeleteOneAsync(filter);

        public async Task AsyncCreateData<T>(string collectionName, T[] data) => await GetCollection<T>(collectionName).InsertManyAsync(data);

        private IMongoCollection<T> GetCollection<T>(string collectionName) => GetMongoDatabase().GetCollection<T>(collectionName);

        private IMongoDatabase GetMongoDatabase() => new MongoClient(config.Uri).GetDatabase(config.Database);
    }
}
