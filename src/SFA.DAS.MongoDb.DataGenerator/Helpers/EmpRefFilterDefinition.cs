using MongoDB.Bson;
using MongoDB.Driver;

namespace SFA.DAS.MongoDb.DataGenerator.Helpers
{
    public abstract class EmpRefFilterDefinition
    {
        protected readonly MongoDbDataHelper mongoDbDatahelper;

        public EmpRefFilterDefinition(MongoDbDataHelper helper)
        {
            mongoDbDatahelper = helper;
        }

        public FilterDefinition<BsonDocument> FilterDefinition()
        {
            return Builders<BsonDocument>.Filter.Eq("empref", mongoDbDatahelper.EmpRef);
        }
    }
}
