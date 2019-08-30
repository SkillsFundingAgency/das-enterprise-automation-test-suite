namespace SFA.DAS.PocProject.UITests.Project.Helpers
{
    public class MongoDbDataHelper
    {
        private readonly DataHelper _registerHelper;

        private int _nextNumber;

        public MongoDbDataHelper(DataHelper registerHelper)
        {
            _registerHelper = registerHelper;
            _nextNumber = _registerHelper.NextNumber;
        }

        public string GatewayId => _registerHelper.RandomUserName;

        public string GatewayPassword => "password";

        public string EmpRef => $"{_nextNumber}/{_registerHelper.TwoDigitProjectCode}{_registerHelper.EmpRefDigits}";

        public string Name => $"End To End Scenario for {GatewayId}";
    }
}
