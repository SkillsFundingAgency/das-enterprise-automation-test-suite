using System;

namespace SFA.DAS.MongoDb.DataGenerator.Helpers
{
    public class DataHelper
    {
        private readonly DateTime _dateTime;

        public DataHelper(string code)
        {
            TwoDigitProjectCode = code;
            _dateTime = DateTime.Now;
            EmpRefDigits = _dateTime.ToString("fffff");
            NextNumber = NextNumberGenerator.GetNextCount();
            GatewayUsername = GenerateRandomUserName();
            GatewayPassword = "password";
        }

        public string TwoDigitProjectCode { get; }

        public string EmpRefDigits { get; }

        public int NextNumber { get; }

        public string GatewayUsername { get; }

        public string GatewayPassword { get; }
       
        private string GenerateRandomUserName()
        {
            return $"{TwoDigitProjectCode}_Test_{NextNumber}_{_dateTime.ToString("ddMMMyyyy_HHmmss")}{EmpRefDigits}";
        }
    }
}
