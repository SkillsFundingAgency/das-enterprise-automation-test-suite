namespace SFA.DAS.MongoDb.DataGenerator.Helpers
{
    public class MongoDbDataHelper(DataHelper dataHelper, string empref)
    {
        public string GatewayId => dataHelper.GatewayUsername;

        public string GatewayPassword => dataHelper.GatewayPassword;

        public string EmpRef => string.IsNullOrEmpty(empref) ? $"{dataHelper.NextNumber}/{dataHelper.LevyOrNonLevy}{dataHelper.EmpRefDigits}" : empref;

        public string Name => $"End To End Scenario for {GatewayId}";
    }
}