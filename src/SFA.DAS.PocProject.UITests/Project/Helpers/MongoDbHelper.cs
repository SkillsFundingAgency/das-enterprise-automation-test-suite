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
        
        private async Task AsyncCreateGatewayUserData()
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
                { "gatewayID", _helper.GatewayId},
                { "password", _helper.GatewayPassword},
                { "empref",_helper.EmpRef},
                { "name", _helper.Name},
                { "require2SV", false }
            };

            return new BsonDocument[] { addUser };
        }
    }


    public class MongoDbDataHelper
    {
        private readonly RegisterHelper _registerHelper;

        private int _nextNumber;

        public MongoDbDataHelper(RegisterHelper registerHelper)
        {
            _registerHelper = registerHelper;
            _nextNumber = _registerHelper.NextNumber;
        }

        public string GatewayId => _registerHelper.RandomUserName;

        public string GatewayPassword => "password";

        public string EmpRef => $"{_nextNumber}/AS{_nextNumber}01";

        public string Name => $"End To End Scenario for {GatewayId}";
    }
}
