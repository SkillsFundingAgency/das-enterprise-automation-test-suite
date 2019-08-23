using MongoDB.Bson;
using MongoDB.Driver;

namespace SFA.DAS.Registration.UITests.Project.Helpers.MongoDb
{
    public interface IMongoDbDataGenerator
    {
        string CollectionName();

        BsonDocument[] Data();

        FilterDefinition<BsonDocument> FilterDefinition();
    }
}
