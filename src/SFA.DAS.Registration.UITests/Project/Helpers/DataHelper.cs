using System;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class DataHelper
    {
        private readonly DateTime dateTime;

        public DataHelper(string code, string domainName)
        {
            TwoDigitProjectCode = code;
            dateTime = DateTime.Now;
            EmpRefDigits = dateTime.ToString("fffff");
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
            return $"{TwoDigitProjectCode}_Test_{NextNumber}_{dateTime.ToString("ddMMMyyyy_HHmmss")}{EmpRefDigits}";
        }
    }
}
