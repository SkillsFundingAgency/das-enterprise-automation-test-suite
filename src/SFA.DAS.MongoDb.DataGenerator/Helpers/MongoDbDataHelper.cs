namespace SFA.DAS.MongoDb.DataGenerator.Helpers
{
    public class MongoDbDataHelper
    {
        private readonly DataHelper _dataHelper;

        public MongoDbDataHelper(DataHelper dataHelper)
        {
            _dataHelper = dataHelper;
        }

        public string GatewayId => _dataHelper.GatewayUsername;

        public string GatewayPassword => _dataHelper.GatewayPassword;

        public string EmpRef => $"{_dataHelper.NextNumber}/{_dataHelper.TwoDigitProjectCode}{_dataHelper.EmpRefDigits}";

        public string Name => $"End To End Scenario for {GatewayId}";
    }
}
