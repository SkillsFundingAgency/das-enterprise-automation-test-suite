using MongoDB.Bson;
using MongoDB.Driver;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.PocProject.UITests.Project.Helpers
{
    public class MongoDbHelper
    {
        private readonly MongoDbConfig _config;

        public MongoDbHelper(ScenarioContext context)
        {
            _config = context.GetConfigSection<MongoDbConfig>();
        }
        
        public async Task AsyncCreateGatewayUserData()
        {
            BsonDocument[] data = CreateGatewayUserData();

            var client = new MongoClient(_config.Uri);
            var db = client.GetDatabase(_config.Database);

            var gatewayUsers = db.GetCollection<BsonDocument>("gateway_users");

            await gatewayUsers.InsertManyAsync(data);

        }

        internal BsonDocument[] CreateGatewayUserData()
        {
            BsonDocument addUser = new BsonDocument
            {
                {"gatewayID", "eeuser001"},
                { "password", "password"},
                { "empref","001/EE00001"},
                { "name", "End To End Scenario 001"},
                { "require2SV", false }
            };

            return new BsonDocument[] { addUser };
        }
    }
}
