using System;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class DataHelper
    {
        private readonly DateTime _dateTime;

        public DataHelper(string code, string domainName)
        {
            TwoDigitProjectCode = code;
            _dateTime = DateTime.Now;
            EmpRefDigits = _dateTime.ToString("fffff");
            NextNumber = NextNumberGenerator.GetNextCount();
            RandomUserName = GenerateRandomUserName();
            RandomEmail = GenerateRandomEmail(domainName);
        }

        public string TwoDigitProjectCode { get; }

        public string EmpRefDigits { get; }

        public int NextNumber { get; }

        public string RandomEmail { get; }

        public string RandomUserName { get; }

        private string GenerateRandomEmail(string domainName)
        {
            return $"{RandomUserName}@{domainName}";
        }
        
        private string GenerateRandomUserName()
        {
            return $"{TwoDigitProjectCode}_Test_{NextNumber}_{_dateTime.ToString("ddMMMyyyy_HHmmss")}{EmpRefDigits}";
        }
    }
}
