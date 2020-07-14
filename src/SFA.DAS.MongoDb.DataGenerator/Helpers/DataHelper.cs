using System;

namespace SFA.DAS.MongoDb.DataGenerator.Helpers
{
    public class DataHelper
    {
        private readonly DateTime _dateTime;

        public DataHelper(bool isLevy)
        {
            Usernameprefix = isLevy ? "LE" : "NL";
            _dateTime = DateTime.Now;
            EmpRefDigits = _dateTime.ToString("fffff");
            NextNumber = NextNumberGenerator.GetNextCount();
            GatewayUsername = GenerateRandomUserName();
            GatewayPassword = "password";
        }

        public string Usernameprefix { get; }

        public string EmpRefDigits { get; }

        public int NextNumber { get; }

        public string GatewayUsername { get; }

        public string GatewayPassword { get; }

        private string GenerateRandomUserName() => $"{Usernameprefix}_Test_{NextNumber}_{_dateTime:ddMMMyyyy_HHmmss}{EmpRefDigits}";
    }
}
