using MongoDB.Bson;
using MongoDB.Driver;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Threading.Tasks;

namespace SFA.DAS.PocProject.UITests.Project.Helpers
{
    public class MongoDbHelper
    {
        private readonly MongoDbConnectionHelper _connectionHelper;
        private readonly MongoDbDataHelper _helper;

        public MongoDbHelper(MongoDbConnectionHelper connectionHelper, MongoDbDataHelper helper)
        {
            _connectionHelper = connectionHelper;
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

            await _connectionHelper.AsyncDeleteGatewayUserData("gateway_users", filter);
        }
        
        private async Task AsyncCreateGatewayUserData()
        {
            BsonDocument[] data = CreateGatewayUserData();

            await _connectionHelper.AsyncCreateGatewayUserData("gateway_users", data);
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
    }
}
