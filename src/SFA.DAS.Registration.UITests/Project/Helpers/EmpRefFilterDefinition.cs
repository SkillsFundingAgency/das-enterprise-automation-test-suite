using MongoDB.Bson;
using MongoDB.Driver;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public abstract class EmpRefFilterDefinition
    {
        private readonly MongoDbDataHelper _helper;

        public EmpRefFilterDefinition(MongoDbDataHelper helper)
        {
            _helper = helper;
        }

        public FilterDefinition<BsonDocument> FilterDefinition()
        {
            return Builders<BsonDocument>.Filter.Eq("empref", _helper.EmpRef);
        }
    }
}
