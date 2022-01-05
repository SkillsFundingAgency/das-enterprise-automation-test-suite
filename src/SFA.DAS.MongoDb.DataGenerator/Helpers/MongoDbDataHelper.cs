namespace SFA.DAS.MongoDb.DataGenerator.Helpers
{
    public class MongoDbDataHelper
    {
        private readonly DataHelper _dataHelper;
        private readonly string _empref;

        public MongoDbDataHelper(DataHelper dataHelper, string empref)
        {
            _dataHelper = dataHelper;
            _empref = empref;
        }

        public string GatewayId => _dataHelper.GatewayUsername;

        public string GatewayPassword => _dataHelper.GatewayPassword;

        public string EmpRef => string.IsNullOrEmpty(_empref) ? $"{_dataHelper.NextNumber}/{_dataHelper.LevyOrNonLevy}{_dataHelper.EmpRefDigits}" : _empref;

        public string Name => $"End To End Scenario for {GatewayId}";
    }
}